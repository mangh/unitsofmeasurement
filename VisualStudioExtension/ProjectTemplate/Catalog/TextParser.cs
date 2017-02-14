/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Globalization;

namespace $safeprojectname$
{
    public class TextParser : ITextParser
    {
        #region Constants
        private const string s_exponentUpperCase = "E";
        private const string s_exponentLowerCase = "e";
        private const string s_leftParenthesis = "(";
        private const string s_rightParenthesis = ")";
        #endregion

        #region Methods
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out string number, out string symbol)
        {
            NumberFormatInfo nfi = fp.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo;
            int index = FindUnitSymbolIndex(input, nfi, style);
            if ((0 <= index) && (index < input.Length))
            {
                number = input.Substring(0, index);
                symbol = input.Substring(index).Trim();
                return true;
            }
            number = symbol = null;
            return false;
        }

        private int FindUnitSymbolIndex(string input, NumberFormatInfo nfi, NumberStyles style)
        {
            int index = 0;
            if ((style & NumberStyles.AllowLeadingWhite) != 0)
            {
                while ((index < input.Length) && IsWhiteSpace(input[index])) index++;
            }

            if (index >= input.Length)
                return index;

            if (String.CompareOrdinal(input, index, nfi.NaNSymbol, 0, nfi.NaNSymbol.Length) == 0)
                return index + nfi.NaNSymbol.Length;

            if (String.CompareOrdinal(input, index, nfi.PositiveInfinitySymbol, 0, nfi.PositiveInfinitySymbol.Length) == 0)
                return index + nfi.PositiveInfinitySymbol.Length;

            if (String.CompareOrdinal(input, index, nfi.NegativeInfinitySymbol, 0, nfi.NegativeInfinitySymbol.Length) == 0)
                return index + nfi.NegativeInfinitySymbol.Length;

            while (index < input.Length)
            {
                int digitIndex = Array.FindIndex(nfi.NativeDigits, digit => String.CompareOrdinal(input, index, digit, 0, digit.Length) == 0);
                if (digitIndex >= 0)
                {
                    index += nfi.NativeDigits[digitIndex].Length;
                }
                else if (String.CompareOrdinal(input, index, nfi.NumberDecimalSeparator, 0, nfi.NumberDecimalSeparator.Length) == 0)
                {
                    if ((style & NumberStyles.AllowDecimalPoint) != 0) index += nfi.NumberDecimalSeparator.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, nfi.NumberGroupSeparator, 0, nfi.NumberGroupSeparator.Length) == 0)
                {
                    if ((style & NumberStyles.AllowThousands) != 0) index += nfi.NumberGroupSeparator.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, nfi.NegativeSign, 0, nfi.NegativeSign.Length) == 0)
                {
                    if ((style & (NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowExponent)) != 0) index += nfi.NegativeSign.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, nfi.PositiveSign, 0, nfi.PositiveSign.Length) == 0)
                {
                    if ((style & (NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowExponent)) != 0) index += nfi.PositiveSign.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, s_exponentUpperCase, 0, s_exponentUpperCase.Length) == 0)
                {
                    if ((style & NumberStyles.AllowExponent) != 0) index += s_exponentUpperCase.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, s_exponentLowerCase, 0, s_exponentLowerCase.Length) == 0)
                {
                    if ((style & NumberStyles.AllowExponent) != 0) index += s_exponentLowerCase.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, s_leftParenthesis, 0, s_leftParenthesis.Length) == 0)
                {
                    if ((style & NumberStyles.AllowParentheses) != 0) index += s_leftParenthesis.Length; else break;
                }
                else if (String.CompareOrdinal(input, index, s_rightParenthesis, 0, s_rightParenthesis.Length) == 0)
                {
                    if ((style & NumberStyles.AllowParentheses) != 0) index += s_rightParenthesis.Length; else break;
                }
                else
                {
                    break;
                }
            }
            return index;
        }

        private bool IsWhiteSpace(char c)
        {
            return (c == '\u0020') || (c == '\u0009') || (c == '\u000A') || (c == '\u000B') || (c == '\u000C') || (c == '\u000D');
        }
        #endregion Methods
    }
}
