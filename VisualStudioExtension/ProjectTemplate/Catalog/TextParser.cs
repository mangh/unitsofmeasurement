/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Globalization;

namespace $safeprojectname$
{
    public class TextParser : ITextParser
    {
        #region Methods
        public bool TryParse(string input, IFormatProvider fp, out string number, out string symbol)
        {
            NumberFormatInfo nfi = fp.GetFormat(typeof(NumberFormatInfo)) as NumberFormatInfo;
            if (nfi == null)
                throw new ArgumentException(String.Format("{0}: missing NumberFormatInfo required for parsing.", fp.GetType().FullName));

            int index = FindUnitSymbolIndex(input, nfi);
            if ((0 <= index) && (index < input.Length))
            {
                number = /* number */ input.Substring(0, index);
                symbol = /* symbol */ input.Substring(index).Trim();
                return true;
            }
            number = symbol = null;
            return false;
        }

        private int FindUnitSymbolIndex(string input, NumberFormatInfo nfi)
        {
            if (input.StartsWith(nfi.NaNSymbol, StringComparison.OrdinalIgnoreCase)) return nfi.NaNSymbol.Length;
            if (input.StartsWith(nfi.PositiveInfinitySymbol, StringComparison.OrdinalIgnoreCase)) return nfi.PositiveInfinitySymbol.Length;
            if (input.StartsWith(nfi.NegativeInfinitySymbol, StringComparison.OrdinalIgnoreCase)) return nfi.NegativeInfinitySymbol.Length;

            int index = 0;
            while (index < input.Length)
            {
                int digitIndex = Array.FindIndex(nfi.NativeDigits, digit => String.CompareOrdinal(input, index, digit, 0, digit.Length) == 0);
                if (digitIndex >= 0)
                    index += nfi.NativeDigits[digitIndex].Length;
                else if (String.CompareOrdinal(input, index, nfi.NumberDecimalSeparator, 0, nfi.NumberDecimalSeparator.Length) == 0)
                    index += nfi.NumberDecimalSeparator.Length;
                else if (String.CompareOrdinal(input, index, nfi.NumberGroupSeparator, 0, nfi.NumberGroupSeparator.Length) == 0)
                    index += nfi.NumberGroupSeparator.Length;
                else if (String.CompareOrdinal(input, index, nfi.NegativeSign, 0, nfi.NegativeSign.Length) == 0)
                    index += nfi.NegativeSign.Length;
                else if (String.CompareOrdinal(input, index, nfi.PositiveSign, 0, nfi.PositiveSign.Length) == 0)
                    index += nfi.PositiveSign.Length;
                else
                    break;
            }
            return index;
        }
        #endregion Methods
    }
}
