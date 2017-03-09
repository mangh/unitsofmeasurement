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
    internal delegate bool NumericParserDelegate<T>(string input, NumberStyles style, IFormatProvider fp, out T result) where T : struct;

    internal static class NumericParser
    {
        public static NumericParserDelegate<double> TryParseDouble =
            delegate(string input, NumberStyles style, IFormatProvider fp, out double result)
            { return double.TryParse(input, style, fp, out result); };

        public static NumericParserDelegate<decimal> TryParseDecimal =
            delegate(string input, NumberStyles style, IFormatProvider fp, out decimal result)
            { return decimal.TryParse(input, style, fp, out result); };

        public static NumericParserDelegate<float> TryParseFloat =
            delegate(string input, NumberStyles style, IFormatProvider fp, out float result)
            { return float.TryParse(input, style, fp, out result); };

        public static System.Delegate SelectDelegate(Type type)
        {
            if (type == typeof(double)) return TryParseDouble;
            if (type == typeof(decimal)) return TryParseDecimal;
            if (type == typeof(float)) return TryParseFloat;

            throw new NotImplementedException(String.Format("Not implemented numeric parser for type \"{0}\"", type.Name));
        }
    }
}
