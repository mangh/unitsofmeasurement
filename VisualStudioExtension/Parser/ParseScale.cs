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
        // <Scale> ::= 'scale' Identifier <Format> '=' Identifier <Num Expr> ';'
        //      1st identifier = scale identifier, 
        //      2nd identifier = unit identifier, 
        private void ParseScale()
		{
			// Identifier (scale name)
			string scaleName = GetScaleName(); if (scaleName == null) return;

			// Format
			string format = GetFormat(String.Empty); if (format == null) return;

			// "="
            if (m_symbol == Lexer.Symbol.EQ) GetToken(); else { Note("\"{0}\": expected equal sign \"=\"", m_lexer.TokenText); return; }

			// Identifier (unit)
			UnitType unit = GetScaleUnit(); if (unit == null) return;

			// Scale offset <Num Expr>
            ASTNode offset = GetNumExpr(unit.Factor.Value.Type); if (offset == null) return;

            ScaleType scale = new ScaleType(m_currentNamespace, scaleName, unit);
            scale.Format = String.IsNullOrWhiteSpace(format) ? unit.Format : format;
            scale.Offset = m_exprEncoder.Encode(offset, scale.Unit.Factor.Value.Type, scale.Namespace);
            m_scales.Add(scale);

            CheckSemicolon();
        }

        private string GetScaleName()
        {
            if (m_symbol != Lexer.Symbol.Identifier)
            {
                Note("\"{0}\": expected scale name", m_lexer.TokenText);
            }
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

        private UnitType GetScaleUnit()
		{
			UnitType unit;
			if (m_symbol != Lexer.Symbol.Identifier)
			{
                Note("\"{0}\": expected unit name", m_lexer.TokenText);
				unit = null;
			}
			else
			{
				unit = m_units.Find(m_currentNamespace, m_lexer.TokenText);
                if (unit == null) Note("\"{0}\": undefined unit", m_lexer.TokenText);
				else GetToken();
			}
			return unit;
		}

		//<Num Expr> ::= <Num Expr> '+' <Num Term>
		//            |  <Num Expr> '-' <Num Term>
		//            |  <Num Term>
        private ASTNode GetNumExpr(NumericType numType)
        {
            ASTNode lhs, rhs;

            if ((lhs = GetNumTerm(numType)) == null) return lhs;
            while ((m_symbol == Lexer.Symbol.Plus) || (m_symbol == Lexer.Symbol.Minus))
            {
                Lexer.Symbol operation = m_symbol;

                GetToken();
                if ((rhs = GetNumTerm(numType)) == null) return rhs;

                if (operation == Lexer.Symbol.Plus) lhs = new ASTSum(lhs, rhs); else lhs = new ASTDifference(lhs, rhs);
            }
            return lhs;
        }

		//<Num Term> ::= <Num Term> '*' <Num Unary>
		//            |  <Num Term> '/' <Num Unary>
		//            |  <Num Unary>
		private ASTNode GetNumTerm(NumericType numType)
		{
			ASTNode lhs, rhs;

			if ((lhs = GetNumUnary(numType)) == null) return lhs;
			while ((m_symbol == Lexer.Symbol.Times) || (m_symbol == Lexer.Symbol.Div))
			{
                Lexer.Symbol operation = m_symbol;
                GetToken();
				if ((rhs = GetNumUnary(numType)) == null) return rhs;
                if (operation == Lexer.Symbol.Times) lhs = new ASTProduct(lhs, rhs); else lhs = new ASTQuotient(lhs, rhs); 
			}
			return lhs;
		}

		//<Num Unary> ::= <Num Factor>
		//             | '+' <Num Unary>
		//             | '-' <Num Unary>
		private ASTNode GetNumUnary(NumericType numType)
		{
			ASTNode factor;
			if (m_symbol == Lexer.Symbol.Plus)
			{
				GetToken();
				if ((factor = GetNumFactor(numType)) != null) factor = new ASTUnary(true, factor);
			}
			else if (m_symbol == Lexer.Symbol.Minus)
			{
				GetToken();
				if ((factor = GetNumFactor(numType)) != null) factor = new ASTUnary(false, factor);
			}
			else
			{
				factor = GetNumFactor(numType);
			}
			return factor;
		}

        // <Num Factor> ::= <Num Literal>
        //              | '(' <Num Expr> ')'
        //
        // <Num Literal> ::= IntLiteral | RealLiteral | StringLiteral  ! Member-access (e.g. "Math.PI")
		private ASTNode GetNumFactor(NumericType numType)
		{
			ASTNode factor = null;
			if (m_symbol == Lexer.Symbol.Lparen)
			{
				GetToken();
				if ((factor = GetNumExpr(numType)) != null)
				{
					if (m_symbol == Lexer.Symbol.Rparen) { GetToken(); factor = new ASTParenthesized(factor); }
                    else Note("\"{0}\": expected closing parenthesis \")\"", m_lexer.TokenText);
				}
			}
			else if ((m_symbol == Lexer.Symbol.IntNumber) || (m_symbol == Lexer.Symbol.RealNumber))
			{
				Number number = numType.TryParse(m_lexer.TokenText);
				if (number == null) Note("\"{0}\": invalid number", m_lexer.TokenText);
				else { GetToken(); factor = new ASTNumber(number); }
			}
			else if (m_symbol == Lexer.Symbol.StringLiteral)
			{
				factor = new ASTLiteral(m_lexer.TokenText);
				GetToken();
			}
			else
			{
                Note("\"{0}\": expected numeric factor: number | (numeric expression) | \"stringliteral\"", m_lexer.TokenText);
			}
			return factor;
        }
        #endregion
    }
}
