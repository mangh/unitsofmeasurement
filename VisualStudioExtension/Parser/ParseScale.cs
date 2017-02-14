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
        // <Scale> ::= 'scale' Identifier <Format> Identifier '=' Identifier <Num Expr> ';'
        //      1st identifier = scale identifier, 
        //      2nd identifier = ref.point identifier, 
        //      3rd identifier = unit identifier, 
        private void ParseScale()
        {
            // Identifier (scale name)
            string scaleName = GetEntityName("scale"); if (scaleName == null) return;

            // Format
            string format = GetFormat(scaleName, String.Empty); if (format == null) return;

            // Identifier (refpoint)
            string refpoint = GetReferencePoint(scaleName); if (refpoint == null) return;

            // "="
            if (m_symbol == Lexer.Symbol.EQ) GetToken(); else { Note("{0}: \"{1}\" found while expected equal sign \"=\".", scaleName, m_token); return; }

            // Identifier (unit)
            UnitType unit = GetScaleUnit(scaleName); if (unit == null) return;

            // Scale offset <Num Expr>
            ASTNode offsetAST = GetNumExpr(scaleName, unit.Factor.Value.Type); if (offsetAST == null) return;
            NumExpr offsetExpr = m_exprEncoder.Encode(offsetAST, unit.Factor.Value.Type);

            ScaleType scale = new ScaleType(scaleName, refpoint, unit, offsetExpr);

            scale.Format = String.IsNullOrWhiteSpace(format) ? unit.Format : format;

            ScaleType relative = GetRelativeScale(scale);
            if (relative != null)
                relative.AddRelative(scale);

            m_scales.Add(scale);
        }

        private string GetReferencePoint(string scaleName)
        {
            if (m_symbol == Lexer.Symbol.EQ)
                return String.Empty;

            if (m_symbol == Lexer.Symbol.Identifier)
            {
                string refpoint = m_token;
                GetToken();
                return refpoint;
            }
            Note("{0}: \"{1}\" found while expected reference-point name or equal sign \"=\".", scaleName, m_token);
            return null;
        }

        private UnitType GetScaleUnit(string scaleName)
        {
            UnitType unit;
            if (m_symbol != Lexer.Symbol.Identifier)
            {
                Note("{0}: \"{1}\" found while expected unit name.", scaleName, m_token);
            }
            else if ((unit = FindUnit(m_token)) == null)
            {
                Note("{0}: undefined unit \"{1}\".", scaleName, m_token);
            }
            else
            {
                GetToken();
                return unit;
            }
            return null;
        }

        //<Num Expr> ::= <Num Expr> '+' <Num Term>
        //            |  <Num Expr> '-' <Num Term>
        //            |  <Num Term>
        private ASTNode GetNumExpr(string scaleName, NumericType numType)
        {
            ASTNode lhs = GetNumTerm(scaleName, numType);
            if (lhs == null)
                return null;

            while ((m_symbol == Lexer.Symbol.Plus) || (m_symbol == Lexer.Symbol.Minus))
            {
                Lexer.Symbol operation = m_symbol;

                GetToken();

                ASTNode rhs = GetNumTerm(scaleName, numType);
                if (rhs == null)
                    return null;
                else if (operation == Lexer.Symbol.Plus)
                    lhs = new ASTSum(lhs, rhs);
                else
                    lhs = new ASTDifference(lhs, rhs);
            }
            return lhs;
        }

        //<Num Term> ::= <Num Term> '*' <Num Unary>
        //            |  <Num Term> '/' <Num Unary>
        //            |  <Num Unary>
        private ASTNode GetNumTerm(string scaleName, NumericType numType)
        {
            ASTNode lhs = GetNumUnary(scaleName, numType);

            if (lhs == null)
                return null;

            while ((m_symbol == Lexer.Symbol.Times) || (m_symbol == Lexer.Symbol.Div))
            {
                Lexer.Symbol operation = m_symbol;
                GetToken();

                ASTNode rhs = GetNumUnary(scaleName, numType);
                if (rhs == null)
                    return null;
                else if (operation == Lexer.Symbol.Times)
                    lhs = new ASTProduct(lhs, rhs);
                else
                    lhs = new ASTQuotient(lhs, rhs); 
            }
            return lhs;
        }

        //<Num Unary> ::= <Num Factor>
        //             | '+' <Num Unary>
        //             | '-' <Num Unary>
        private ASTNode GetNumUnary(string scaleName, NumericType numType)
        {
            if (m_symbol == Lexer.Symbol.Plus)
            {
                GetToken();
                ASTNode factor = GetNumFactor(scaleName, numType);
                return (factor == null) ? null : new ASTUnary(true, factor);
            }
            else if (m_symbol == Lexer.Symbol.Minus)
            {
                GetToken();
                ASTNode factor = GetNumFactor(scaleName, numType);
                return (factor == null) ? null : new ASTUnary(false, factor);
            }
            else
            {
                return GetNumFactor(scaleName, numType);
            }
        }

        // <Num Factor> ::= <Num Literal>
        //              | '(' <Num Expr> ')'
        //
        // <Num Literal> ::= IntLiteral | RealLiteral | StringLiteral  ! Member-access (e.g. "Math.PI")
        private ASTNode GetNumFactor(string scaleName, NumericType numType)
        {
            if (m_symbol == Lexer.Symbol.Lparen)
            {
                GetToken();
                ASTNode factor = GetNumExpr(scaleName, numType);
                if (factor != null)
                {
                    if (m_symbol != Lexer.Symbol.Rparen)
                    {
                        Note("{0}: \"{1}\" found while expected closing parenthesis \")\".", scaleName, m_token);
                    }
                    else
                    {
                        GetToken();
                        return new ASTParenthesized(factor);
                    }
                }
            }
            else if ((m_symbol == Lexer.Symbol.IntNumber) || (m_symbol == Lexer.Symbol.RealNumber))
            {
                Number number = numType.TryParse(m_token);
                if (number == null)
                {
                    Note("{0}: invalid number \"{1}\".", scaleName, m_token);
                }
                else
                {
                    GetToken();
                    return new ASTNumber(number);
                }
            }
            else if (m_symbol == Lexer.Symbol.StringLiteral)
            {
                string literal = m_token;
                GetToken();
                return new ASTLiteral(literal);
            }
            else
            {
                Note("{0}: \"{1}\" found while expected numeric factor: number | (numeric expression) | \"stringliteral\".", scaleName, m_token);
            }
            return null;
        }

        public ScaleType GetRelativeScale(ScaleType scale)
        {
            return m_scales.Find(s => 
                object.ReferenceEquals(s.Unit.FamilyPrime(), scale.Unit.FamilyPrime()) &&
                String.Equals(s.RefPoint, scale.RefPoint, StringComparison.Ordinal)
            );
        }
        #endregion
    }
}
