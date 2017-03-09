/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Parser
    {
        #region Methods

        // <Unit> ::= 'unit'<ValueType> Identifier <Tags> <Format> '=' <Dim Expr> ';'
        private bool ParseUnit()
        {
            // <ValueType>
            NumericType numType = GetUnitNumericType();
            if (numType == null) return false;

            // Identifier (unit name)
            string unitName = GetEntityName("unit");
            if (unitName == null) return false;

            UnitType candidate = new UnitType(unitName);

            // Tags
            if (!GetUnitTags(candidate)) return false;

            // Format
            candidate.Format = GetFormat(candidate.Name, "{0} {1}");
            if (candidate.Format == null) return false;

            // "="
            if (m_symbol == Lexer.Symbol.EQ)
                GetToken();
            else
            {
                Note("{0}: \"{1}\" found while expected equal sign \"=\".", candidate.Name, m_token);
                return false;
            }

            // <Dim Expr>
            if (!GetDimExpr(candidate, numType)) return false;

            // Semicolon ";"
            bool done = GetSemicolon(candidate.Name);
            if (done)
            {
                m_units.Add(candidate);
            }
            return done;
        }

        private NumericType GetUnitNumericType()
        {
            NumericType type;
            if (m_symbol != Lexer.Symbol.LT)
            {
                type = NumericType.Double;
            }
            else if ((GetToken() != Lexer.Symbol.Identifier) || ((type = NumericType.Factory(m_token)) == null))
            {
                Note("\"{0}\" found while expected numeric type name: \"double\" | \"float\" | \"decimal\".", m_token);
                type = null;
            }
            else if (GetToken() == Lexer.Symbol.GT)
            {
                GetToken();
            }
            else
            {
                Note("\"{0}\" found while expected closing bracket \">\".", m_token);
            }
            return type;
        }

        // <Tags> ::= <Tags> StringLiteral
        //         | StringLiteral
        private bool GetUnitTags(UnitType candidate)
        {
            while (m_symbol != Lexer.Symbol.EOF)
            {
                if (m_symbol != Lexer.Symbol.StringLiteral)
                    break;

                UnitType other = FindUnitOfTag(m_token);
                if (other == null)
                    candidate.Tags.Add(m_token);
                else
                    Note("{0}: symbol \"{1}\" rejected as already used for {2} unit.", candidate.Name, m_token, other.Name);

                GetToken();
            }
            if (candidate.Tags.Count > 0) return true;

            Note("{0}: missing unit symbol(s).", candidate.Name);
            return false;
        }

        // <Format> ::= ':' StringLiteral
        //           |  ! No format -> default format: "{0} {1}" ("value symbol" e.g. "100 mph")
        private string GetFormat(string candidateName, string defaultFormat)
        {
            if (m_symbol != Lexer.Symbol.Colon)
            {
                return defaultFormat;
            }
            else if (GetToken() != Lexer.Symbol.StringLiteral)
            {
                Note("{0}: \"{1}\" found while expected format string e.g. \"{{0}} {{1}}\".", candidateName, m_token);
            }
            else if (String.IsNullOrWhiteSpace(m_token))
            {
                Note("{0}: empty format string.", candidateName);
            }
            else
            {
                string format = m_token;
                GetToken();
                return format;
            }
            return null;
        }

        //<Dim Expr> ::= <Dim Expr> '|' <Dim Term>
        //           |   <Dim Term>
        public bool GetDimExpr(UnitType candidate, NumericType numType)
        {
            ASTNode basic = GetDimTerm(candidate, numType);

            if (basic == null) return false;

            candidate.Sense = m_senseEncoder.Encode(basic);
            candidate.Factor = m_exprEncoder.Encode(basic, numType);
            basic.Normalized().Bind(candidate);

            while (m_symbol == Lexer.Symbol.Pipe)
            {
                GetToken();

                ASTNode alternate = GetDimTerm(candidate, numType);
                if (alternate == null) return false;

                SenseExpr sense = m_senseEncoder.Encode(alternate);
                if (sense.Value != candidate.Sense.Value)
                {
                    Note("{0}: inconsistent dimensions: {1} == {2} != {3} == {4}.",
                        candidate.Name, candidate.Sense.Code, candidate.Sense.Value, sense.Value, sense.Code);
                    return false;
                }
                NumExpr factor = m_exprEncoder.Encode(alternate, numType);
                if (factor.IsTrueValue && candidate.Factor.IsTrueValue && (factor.Value != candidate.Factor.Value))
                {
                    Note("{0}: inconsistent conversion factors: {1} == {2} != {3} == {4}.",
                        candidate.Name, candidate.Factor.Code, candidate.Factor.Value, factor.Value, factor.Code);
                    return false;
                }
                alternate.Normalized().Bind(candidate);
            }
            return true;
        }

        //<Dim Term> ::= <Dim Term> '*' <Dim Factor>
        //            |  <Dim Term> '^' <Dim Factor>
        //            |  <Dim Term> '/' <Dim Factor>
        //            |  <Dim Factor>
        private ASTNode GetDimTerm(UnitType candidate, NumericType numType)
        {
            ASTNode lhs = GetDimFactor(candidate, numType);
            if (lhs == null)
                return null;

            while ((m_symbol == Lexer.Symbol.Times) || (m_symbol == Lexer.Symbol.Div) || (m_symbol == Lexer.Symbol.Wedge))
            {
                Lexer.Symbol operatorSymbol = m_symbol;
                string operatorToken = m_token;
                int operatorLine = m_lexer.TokenLine;
                int operatorColumn = m_lexer.TokenColumn;

                GetToken();

                ASTNode rhs = GetDimFactor(candidate, numType);
                if (rhs == null)
                    return null;

                else if (operatorSymbol == Lexer.Symbol.Div)
                    lhs = new ASTQuotient(lhs, rhs);

                else if (operatorSymbol == Lexer.Symbol.Times)
                    lhs = new ASTProduct(lhs, rhs, iswedgeproduct: false);

                else if (lhs.IsWedgeCompatible && rhs.IsWedgeCompatible)
                    lhs = new ASTProduct(lhs, rhs, iswedgeproduct: true);

                else
                {
                    string denote = "\u02C7\u02C7\u02C7{0}\u02C7\u02C7\u02C7";   //  ˇˇˇexprˇˇˇ
                    Note(operatorLine, operatorColumn, operatorToken,
                        String.Format("{0}: wedge product incompatible factor(s): {1} ^ {2}.", candidate.Name,
                            lhs.IsWedgeCompatible ? lhs.ToString() : String.Format(denote, lhs),
                            rhs.IsWedgeCompatible ? rhs.ToString() : String.Format(denote, rhs)
                        )
                    );
                    return null;
                }
            }
            return lhs;
        }

        //<Dim Factor> ::= '<' <Magnitude> '>'
        //             |    Identifier        ! Unit name (e.g. Meter)
        //             |    <Num Literal>
        //             |   '(' <Dim Term> ')'
        //
        // <Num Literal> ::= IntLiteral | RealLiteral | StringLiteral  ! Member-access (e.g. "Math.PI")
        private ASTNode GetDimFactor(UnitType candidate, NumericType numType)
        {
            // '<' Magnitude '>'?
            if (m_symbol == Lexer.Symbol.LT)
            {
                GetToken();
                return GetDimMagnitude(candidate);
            }

            // '(' <Dim Term> ')'?
            else if (m_symbol == Lexer.Symbol.Lparen)
            {
                GetToken();
                ASTNode factor = GetDimTerm(candidate, numType);
                if (factor != null)
                {
                    if (m_symbol != Lexer.Symbol.Rparen)
                    {
                        Note("{0}: \"{1}\" found while expected closing parenthesis \")\".", candidate.Name, m_token);
                    }
                    else
                    {
                        GetToken();
                        return new ASTParenthesized(factor);
                    }
                }
            }

            // <Num Literal>?
            else if ((m_symbol == Lexer.Symbol.IntNumber) || (m_symbol == Lexer.Symbol.RealNumber))
            {
                Number number = numType.TryParse(m_token);
                if (number == null)
                {
                    Note("{0}: invalid number \"{1}\".", candidate.Name, m_token);
                }
                else
                {
                    GetToken();
                    return new ASTNumber(number);
                }
            }

            // <String Literal> e.g. "Math.PI"?
            else if (m_symbol == Lexer.Symbol.StringLiteral)
            {
                ASTNode factor = new ASTLiteral(m_token);
                GetToken();
                return factor;
            }

            // Unit identifier?
            else if (m_symbol == Lexer.Symbol.Identifier)
            {
                UnitType u = FindUnit(m_token);
                if (u == null)
                {
                    Note("{0}: undefined unit \"{1}\".", candidate.Name, m_token);
                }
                else if (u.Factor.Value.Type != numType)
                {
                    Note("{0}: unit \"{1}\" is of type <{2}> != <{3}>.", candidate.Name, m_token, u.Factor.Value.Type.Name, numType.Name);
                }
                else
                {
                    GetToken();
                    return new ASTUnit(u);
                }
            }

            else
            {
                Note("{0}: \"{1}\" found while expected: <dimension> | unit | number | \"literal\" | (expression).", candidate.Name, m_token);
            }

            return null;
        }

        //<Magnitude> ::= Length
        //             |  Time
        //             |  Mass
        //             |  Temperature
        //             |  ElectricCurrent
        //             |  AmountOfSubstance
        //             |  LuminousIntensity
        //             |  Other | Money ! Other and Money represent the same magnitude
        //             |    ! Dimensionless
        private ASTMagnitude GetDimMagnitude(UnitType candidate)
        {
            if (m_symbol == Lexer.Symbol.GT)
            {
                GetToken();
                return new ASTMagnitude();
            }

            Magnitude m;
            if ((m_symbol != Lexer.Symbol.Identifier) || !Enum.TryParse(m_token, false, out m))
            {
                Note("{0}: \"{1}\" found while expected dimension keyword: <{2}> or <> for dimensionless unit.",
                    candidate.Name, m_token, String.Join(">, <", Enum.GetNames(typeof(Magnitude))));
            }
            else if (GetToken() == Lexer.Symbol.GT)
            {
                GetToken();
                return new ASTMagnitude(m);
            }
            else
            {
                Note("{0}: \"{1}\" found while expected closing bracket \">\".", candidate.Name, m_token);
            }
            return null;
        }
        #endregion
    }
}
