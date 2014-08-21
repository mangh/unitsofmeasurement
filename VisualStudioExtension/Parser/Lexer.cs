/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.IO;

namespace Man.UnitsOfMeasurement
{
	public partial class Lexer
	{
		#region Fields
		private Token m_token;
		private TokenReader m_input;
        private Action<bool, int, int, string, string> m_logger;
		#endregion

		#region Properties
		public Symbol TokenSymbol { get { return m_token.Symbol; } }
		public string TokenText { get { return m_token.Text; } }
		#endregion

		#region Constructor(s)
		public Lexer(TextReader input, Action<bool, int, int, string, string> logger)
		{
			m_token = new Token();
			m_input = new TokenReader(input);
			m_logger = logger;

			m_input.Read();
		}
		#endregion

		#region Methods
		public Symbol GetToken()
		{
			if ((m_token.Symbol = FindToken()) != Symbol.Unknown)
				return m_token.Symbol;

			// "A" .. "Z", "a" .. "z", "_", "@"
			else if (Char.IsLetter(m_input.Char) || (m_input.Char == '_') || (m_input.Char == '@'))
				return GetQualifiedName();

			// "0" .. "9", "."
			else if (Char.IsDigit(m_input.Char) || (m_input.Char == '.'))
				return GetPositiveNumber();

			else if (m_input.Char == '"')
				return GetStringLiteral();

			else if (m_input.Char == '<') { m_token.Symbol = Symbol.LT; }
            else if (m_input.Char == '>') { m_token.Symbol = Symbol.GT; }
            else if (m_input.Char == '=') { m_token.Symbol = Symbol.EQ; }
            else if (m_input.Char == '(') { m_token.Symbol = Symbol.Lparen; }
			else if (m_input.Char == ')') { m_token.Symbol = Symbol.Rparen; }
			else if (m_input.Char == '|') { m_token.Symbol = Symbol.Pipe; }
			else if (m_input.Char == '+') { m_token.Symbol = Symbol.Plus; }
			else if (m_input.Char == '-') { m_token.Symbol = Symbol.Minus; }
			else if (m_input.Char == '*') { m_token.Symbol = Symbol.Times; }
			else if (m_input.Char == ':') { m_token.Symbol = Symbol.Colon; }
			else if (m_input.Char == ';') { m_token.Symbol = Symbol.Semicolon; }
            else
            {
                CopyChar(); 
                Note("\"{0}\": unrecognized token", m_token.Text);
                return m_token.Symbol = Symbol.Error;
            }

			CopyChar();
			return m_token.Symbol;
		}

		private bool CopyChar()
		{
			m_token.Append(m_input.Char);
			return m_input.Read();
		}

        private Symbol FindToken()
        {
            while (true)
            {
                SkipWhitespace();

                m_token.Clear();
                m_token.SavePosition(m_input.Line, m_input.Column);

                if (m_input.EOF) return Symbol.EOF;
                if (m_input.Char != '/') return Symbol.Unknown;

                if (!CopyChar()) return Symbol.Div;

                if (m_input.Char == '/') SkipLineComment();
                else if (m_input.Char == '*') SkipBlockComment();
                else return Symbol.Div;
            }
        }

        private void SkipWhitespace()
		{
			while (!m_input.EOF && Char.IsWhiteSpace(m_input.Char)) m_input.Read();
		}

		private void SkipLineComment()
		{
            m_token.Append(m_input.Char);
            m_token.Symbol = Symbol.Comment;
            while (!m_input.EOF && m_input.Char != '\n') m_input.Read();
		}

        private void SkipBlockComment()
        {
            m_token.Append(m_input.Char);
            m_token.Symbol = Symbol.Comment;

            bool escape = false;
            while (m_input.Read())
            {
                if (escape && (m_input.Char == '/')) 
                {
                    m_input.Read();
                    return;
                }
                escape = (m_input.Char == '*');
            }
            Note("Unexpected EOF while looking for the closing token \"*/\"");
        }

		// StringLiteral = '"'( {String Ch} | '\'{Printable} )* '"'
		private Symbol GetStringLiteral()
		{
            string noteUnexpectedEOL = "Unexpected EOL while looking for the closing quotation mark (\")";
            m_token.Symbol = Symbol.StringLiteral;
            int escape = 0;
            while (m_input.Read())
			{
				escape--;
				if (m_input.Char == '"')
                {
                    if (escape > 0) m_token.Append(m_input.Char);
                    else { m_input.Read(); return Symbol.StringLiteral; }
                }
				else if (m_input.Char == '\\')
                {
                    m_token.Append(m_input.Char);
                    escape = (escape > 0) ? 0 : 2;
                }
                else if (Char.IsControl(m_input.Char))
                {
                    Note(((m_input.Char == '\r') || (m_input.Char == '\n')) ? noteUnexpectedEOL : "Control characters within string literal");
                    return Symbol.Error;
                }
                else
                {
                    m_token.Append(m_input.Char);
                }
			}
            Note(noteUnexpectedEOL);
            return Symbol.Error;
		}

		// <QualifiedName> ::= <QualifiedName> '.' Identifier |  Identifier
		// Identifier      = [@]? {ID Head} {ID Tail}*   !The @ is an override char
		// {ID Head}     = {Letter} + [_]
		// {ID Tail}     = {Alphanumeric} + [_]
		private Symbol GetQualifiedName()
		{
            m_token.Symbol = Symbol.Identifier;
            do
			{
				while (CopyChar() && (Char.IsLetterOrDigit(m_input.Char) || (m_input.Char == '_'))) ;
                if (m_input.Char != '.') return m_token.Symbol;
                m_token.Symbol = Symbol.Qualifiedname;
			}
			while (CopyChar() && (Char.IsLetter(m_input.Char) || (m_input.Char == '_') || (m_input.Char == '@')));

            Note("\"{0}\": badly formed (qualified) identifier", m_token.Text);
            return Symbol.Error;
		}

		// <Positive Number> ::= IntLiteral | RealLiteral
		// IntLiteral    = {Digit}+
		// RealLiteral   = {Digit}*'.'{Digit}+(('e'|'E')('+'|'-')*{Digit}+)*('f'|'F'|'d'|'D'|'m'|'M')*
		private Symbol GetPositiveNumber()
		{
            // {Digit}* ...
            int integers = GetDigits();
            m_token.Symbol = Symbol.IntNumber;

            // {Digit}*'.' ...
            if (m_input.Char == '.')
            {
                m_token.Symbol = Symbol.RealNumber;

                CopyChar();	// '.' --> token
                // {Digit}*'.'{Digit}+ ...
                if (GetDigits() <= 0)
                {
                    if (integers > 0) return m_token.Symbol;
                    Note("\"{0}\": expecting number {Digit}+ | {Digit}*'.'{Digit}+(('e'|'E')('+'|'-')*{Digit}+)*", m_token.Text);
                    return Symbol.Error;
                }
            }

            // {Digit}*'.'{Digit}+(('e'|'E') ...)*
            if ((m_input.Char == 'e') || (m_input.Char == 'E'))
            {
                m_token.Symbol = Symbol.RealNumber;

                CopyChar();	// 'e|E' --> token

                // {Digit}*'.'{Digit}+(('e'|'E')('+'|'-')* ...)*
                if ((m_input.Char == '+') || (m_input.Char == '-'))
                    CopyChar();

                // {Digit}*'.'{Digit}+(('e'|'E')('+'|'-')*{Digit}+)*...
                if (GetDigits() <= 0)
                {
                    Note("\"{0}\": no digits in exponent part", m_token.Text);
                    return Symbol.Error;
                }
            }

            return m_token.Symbol;
        }

        // digits --> token
        private int GetDigits()
        {
            int digits = 0;
            while (!m_input.EOF && Char.IsDigit(m_input.Char)) { digits++; CopyChar(); }
            return digits;
        }

        public void Note(string info)
        {
            m_logger(true, m_token.Line, m_token.Column, m_token.Text, info);
        }
        public void Note(string format, params object[] info)
        {
            m_logger(true, m_token.Line, m_token.Column, m_token.Text, String.Format(format, info));
        }
        #endregion
	}
}
