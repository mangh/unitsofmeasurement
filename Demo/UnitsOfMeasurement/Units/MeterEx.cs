/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;
using System.Globalization;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter
    {
        private static ITextParser s_parser = new TextParser();
        public static ITextParser Parser { get { return s_parser; } set { s_parser = value; } }

        public static bool TryParse(string input, out Meter result) { return TryParse(input, CultureInfo.CurrentCulture, out result); }
        public static bool TryParse(string input, IFormatProvider fp, out Meter result) { return TryParse(input, fp, NumberStyles.Number, out result); }
        public static bool TryParse(string input, IFormatProvider fp, NumberStyles style, out Meter result)
        {
            double value;
            string[] token = s_parser.TryParse(input, fp);
            if ((token != null) && (Meter.Symbol.Index(token[1]) >= 0) && double.TryParse(token[0], style, fp, out value))
            {
                result = new Meter(value);
                return true;
            }
            result = Meter.Zero;
            return false;
        }
    }
}
