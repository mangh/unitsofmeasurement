/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System.Text;

namespace Man.UnitsOfMeasurement
{
    public partial class Lexer
    {
        /// <summary>
        /// TODO: Update summary.
        /// </summary>
        private class Token
        {
            #region Fields
            private StringBuilder m_chars;
            private Symbol m_symbol;
            private int m_linIndex;
            private int m_colIndex;
            #endregion

            #region Properties
            public Symbol Symbol { get { return m_symbol; } set { m_symbol = value; } }
            public string Text { get { return m_chars.ToString(); } }
            public int Line { get { return m_linIndex; } }
            public int Column { get { return m_colIndex; } }
            public int Length { get { return m_chars.Length; } }
            #endregion

            #region Constructor(s)
            public Token()
            {
                m_chars = new StringBuilder(1024);
                m_linIndex = 0;
                m_colIndex = 0;
            }
            #endregion

            #region Methods
            public void Clear() { m_symbol = Symbol.Unknown; m_chars.Clear(); }
            public void SavePosition(int line, int col) { m_linIndex = line; m_colIndex = col; }
            public void Append(char c) { m_chars.Append(c); }
            public void Append(string s) { m_chars.Append(s); }
            public void Remove(int startIndex, int length) { m_chars.Remove(startIndex, length); }
            #endregion
        }
    }
}
