/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System.IO;

namespace Man.UnitsOfMeasurement
{
	public partial class Lexer
	{
		/// <summary>
		/// TODO: Update summary.
		/// </summary>
		private class TokenReader
		{
			#region Fields
			private TextReader m_reader;
			private int m_lineIndex;
			private int m_charIndex;
			private char m_char;
			private int m_charcode;
			#endregion

			#region Properties
			public bool EOF { get { return (m_charcode == -1); } }
			public char Char { get { return m_char; } }
			public int Line { get { return m_lineIndex; } }
			public int Column { get { return m_charIndex; } }
			#endregion

			#region Constructor(s)
			public TokenReader(TextReader reader)
			{
				m_reader = reader;
				m_lineIndex = 1;
				m_charIndex = 0;
			}
			#endregion

			#region Methods
            public bool Read()
            {
                m_char = (char)(m_charcode = m_reader.Read());

                if (EOF) return false;

                m_charIndex++;
                if (m_char == '\n')
                {
                    m_charIndex = 0; 
                    m_lineIndex++;
                }
                return true;
            }
            #endregion
		}
	}
}
