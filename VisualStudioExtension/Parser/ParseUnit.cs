/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


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
        private void ParseUnit()
        {
            // <ValueType>
            NumericType numType = GetUnitNumericType(); if (numType == null) return;

            // Identifier (unit name)
            string unitName = GetUnitName(); if (unitName == null) return;

            UnitType unit = new UnitType(m_currentNamespace, unitName);

            // Tags
            if (!GetUnitTags(unit)) return;

            // Format
            if ((unit.Format = GetFormat("{0} {1}")) == null) return;

            // "="
            if (m_symbol == Lexer.Symbol.EQ) GetToken(); else { Note("\"{0}\": expected equal sign \"=\"", m_lexer.TokenText); return; }

            // <Dim Expr>
            if (!GetDimExpr(unit, numType)) return;

            m_units.Add(unit);

            CheckSemicolon();
        }

        private NumericType GetUnitNumericType()
        {
            NumericType type;
            if (m_symbol != Lexer.Symbol.LT)
            {
                type = NumericType.Double;
            }
            else if ((GetToken() != Lexer.Symbol.Identifier) || ((type = NumericType.Factory(m_lexer.TokenText)) == null))
            {
                Note("\"{0}\": expected numeric value type name: \"double\" | \"float\" | \"decimal\"", m_lexer.TokenText);
                type = null;
            }
            else
            {
                if (GetToken() == Lexer.Symbol.GT) GetToken(); else Note("\"{0}\": expected closing bracket \">\"", m_lexer.TokenText);
            }
            return type;
        }

        private string GetUnitName()
        {
            if (m_symbol != Lexer.Symbol.Identifier)
                Note("\"{0}\": expected unit name", m_lexer.TokenText);
            else
            {
                string name = m_lexer.TokenText;
                if ((m_units.Find(m_currentNamespace, name) == null) &&
                    (m_scales.Find(m_currentNamespace, name) == null))
                {
                    GetToken();
                    return name;
                }
                Note("Duplicate \"{0}\" definition", name);
            }
            return null;
        }

        // <Tags> ::= <Tags> StringLiteral
        //         | StringLiteral
        private bool GetUnitTags(UnitType unit)
        {
            while (m_symbol != Lexer.Symbol.EOF)
            {
                if (m_symbol == Lexer.Symbol.Error)
                    return false;
                if (m_symbol != Lexer.Symbol.StringLiteral)
                    break;
                unit.Tags.Add(m_lexer.TokenText); 
                GetToken();
            }
            if (unit.Tags.Count > 0) return true;

            Note("\"{0}\": expected unit symbols (string literals)", m_lexer.TokenText);
            return false;
        }

        // <Format> ::= ':' StringLiteral
        //           |  ! No format -> default format: "{0} {1}" ("value symbol" e.g. "100 mph")
        private string GetFormat(string defaultFormat)
        {
            string format;
            if (m_symbol != Lexer.Symbol.Colon)
            {
                format = defaultFormat;
            }
            else if (GetToken() != Lexer.Symbol.StringLiteral)
            {
                Note("\"{0}\": expected format string e.g. \"{0} {1}\"", m_lexer.TokenText);
                format = null;
            }
            else
            {
                format = m_lexer.TokenText;
                if (String.IsNullOrWhiteSpace(format))
                {
                    Note("Empty format string");
                    format = null;
                }
                GetToken();
            }
            return format;
        }

        //<Dim Expr> ::= <Dim Expr> '|' <Dim Term>
        //           |   <Dim Term>
        public bool GetDimExpr(UnitType unit, NumericType numType)
        {
            ASTNode basic, alternate;

            if ((basic = GetDimTerm(numType)) == null) return false;

            unit.Sense = m_senseEncoder.Encode(basic, unit.Namespace);
            unit.Factor = m_exprEncoder.Encode(basic, numType, unit.Namespace);
            basic.Normalized().Bind(unit);

            while (m_symbol == Lexer.Symbol.Pipe)
            {
                GetToken();
                if ((alternate = GetDimTerm(numType)) == null) return false;

                SenseExpr sense = m_senseEncoder.Encode(alternate, unit.Namespace);
                if (sense.Value != unit.Sense.Value)
                {
                    Note("Inconsistent dimensions: \"{0}\" -> {1} != {2} <- \"{3}\"", 
                        unit.Sense.Code, unit.Sense.Value, sense.Value, sense.Code);
                    return false;
                }
                NumExpr factor = m_exprEncoder.Encode(alternate, numType, unit.Namespace);
                if (factor.IsTrueValue && (factor.Value != unit.Factor.Value))
                {
                    Note("Inconsistent conversion factors: \"{0}\" -> {1} != {2} <- \"{3}\"",
                        unit.Factor.Code, unit.Factor.Value, factor.Value, factor.Code);
                    return false;
                }
                alternate.Normalized().Bind(unit);
            }
            return true;
        }

        //<Dim Term> ::= <Dim Term> '*' <Dim Factor>
        //            |  <Dim Term> '/' <Dim Factor>
        //            |  <Dim Factor>
        private ASTNode GetDimTerm(NumericType numType)
        {
            ASTNode lhs, rhs;

            if ((lhs = GetDimFactor(numType)) == null) return lhs;

            while ((m_symbol == Lexer.Symbol.Times) || (m_symbol == Lexer.Symbol.Div))
            {
                Lexer.Symbol operation = m_symbol;

                GetToken();
                if ((rhs = GetDimFactor(numType)) == null) return rhs;

                if (operation == Lexer.Symbol.Times) 
                    lhs = new ASTProduct(lhs, rhs);
                else
                    lhs = new ASTQuotient(lhs, rhs);
            }
            return lhs;
        }

        //<Dim Factor> ::= '<' <Magnitude> '>'
        //             |    Identifier        ! Unit name (e.g. Meter)
        //             |    <Num Literal>
        //             |   '(' <Dim Term> ')'
        //
        // <Num Literal> ::= IntLiteral | RealLiteral | StringLiteral  ! Member-access (e.g. "Math.PI")
        private ASTNode GetDimFactor(NumericType numType)
        {
            ASTNode factor = null;

            // '<' Magnitude '>'?
            if (m_symbol == Lexer.Symbol.LT)    
            {
                GetToken();
                factor = GetDimMagnitude();
            }

            // '(' <Dim Term> ')'?
            else if (m_symbol == Lexer.Symbol.Lparen)
            {
                GetToken();
                if ((factor = GetDimTerm(numType)) != null)
                {
                    if (m_symbol == Lexer.Symbol.Rparen) { GetToken(); factor = new ASTParenthesized(factor); }
                    else { Note("\"{0}\": expected closing parenthesis \")\"", m_lexer.TokenText); factor = null; }
                }
            }

            // <Num Literal>?
            else if ((m_symbol == Lexer.Symbol.IntNumber) || (m_symbol == Lexer.Symbol.RealNumber))
            {
                Number number = numType.TryParse(m_lexer.TokenText);
                if (number == null) Note("\"{0}\": invalid number", m_lexer.TokenText);
                else { GetToken(); factor = new ASTNumber(number); }
            }

            else if (m_symbol == Lexer.Symbol.StringLiteral)
            {
                factor = new ASTLiteral(m_lexer.TokenText); GetToken();
            }

            // Unit identifier?
            else if (m_symbol == Lexer.Symbol.Identifier)
            {
                UnitType u = m_units.Find(m_currentNamespace, m_lexer.TokenText);
                if (u == null)
                    Note("Undefined unit \"{0}\"", m_lexer.TokenText);
                else if (u.Factor.Value.Type != numType)
                    Note("Unit \"{0}\" is of type <{1}> != <{2}>", m_lexer.TokenText, u.Factor.Value.Type.Name, numType.Name);
                else
                {
                    factor = new ASTUnit(u);
                    GetToken();
                }
            }

            else 
            {
                Note("\"{0}\": expected: <dimension> | unit | number | \"literal\" | (expression)", m_lexer.TokenText);
            }

            return factor;
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
        private ASTMagnitude GetDimMagnitude()
        {
            if (m_symbol == Lexer.Symbol.GT)
            {
                GetToken(); 
                return new ASTMagnitude();
            }

            Magnitude m;
            ASTMagnitude factor;
            if ((m_symbol != Lexer.Symbol.Identifier) || !Enum.TryParse(m_lexer.TokenText, false, out m))
            {
                factor = null;
                Note("\"{0}\": expecting dimension keyword: <" + 
                    String.Join("> | <", Enum.GetNames(typeof(Magnitude))) +
                    "> or \"<>\" for dimensionless unit", m_lexer.TokenText);
            }
            else
            {
                factor = new ASTMagnitude(m);
                if (GetToken() == Lexer.Symbol.GT) GetToken(); else Note("\"{0}\": expected closing bracket \">\"", m_lexer.TokenText);
            }
            return factor;
        }
        #endregion
    }
}
