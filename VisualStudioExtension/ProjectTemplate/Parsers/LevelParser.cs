/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;

namespace $safeprojectname$
{
    public class LevelParser<T>
        where T : struct
    {
        #region Level tokenizer delegate
        public delegate Scale<T> Tokenizer(string level, IEnumerable<Scale<T>> scales, out string number, out string symbol);
        #endregion

        #region Properties
        public IEnumerable<Scale<T>> Scales { get; private set; }
        public NumberStyles NumberStyle { get; set; }
        public Tokenizer TryTokenize { get; set; }
        #endregion

        #region Constructor(s)
        public LevelParser(IEnumerable<Scale<T>> allowedScales)
        {
            Scales = allowedScales;
            NumberStyle = NumberStyles.Float;
            TryTokenize = TokenizePostfixed;
        }
        public LevelParser(int family) :
            this(Catalog.Scales<T>(family))
        {
        }
        #endregion

        #region Parsing
        public bool TryParse(string input, out ILevel<T> result)
        {
            return TryParse(input, CultureInfo.CurrentCulture, this.NumberStyle, out result);
        }
        public bool TryParse(string input, IFormatProvider fp, out ILevel<T> result)
        {
            return TryParse(input, fp, this.NumberStyle, out result);
        }
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out ILevel<T> result)
        {
            string number;
            string symbol;
            T value;
            Scale<T> scale = TryTokenize(input, Scales, out number, out symbol);
            if((scale != null) && TryParseNumber(number, style, fp, out value))
            {
                result = scale.Create(value);
                return true;
            }
            result = null;
            return false;
        }
        #endregion

        #region Tokenizers
        public static Scale<T> TokenizePrefixed(string level, IEnumerable<Scale<T>> scales, out string number, out string symbol)
        {
            return LevelTokenizer.Tokenize(level, scales, u => level.StartsWith(u, StringComparison.Ordinal), out number, out symbol) as Scale<T>;
        }
        public static Scale<T> TokenizePostfixed(string level, IEnumerable<Scale<T>> scales, out string number, out string symbol)
        {
            return LevelTokenizer.Tokenize(level, scales, u => level.EndsWith(u, StringComparison.Ordinal), out number, out symbol) as Scale<T>;
        }
        private static readonly NumericParserDelegate<T> TryParseNumber = NumericParser.SelectDelegate(typeof(T)) as NumericParserDelegate<T>;
        #endregion
    }

    public static class LevelTokenizer
    {
        /// <summary>Tokenize level string into number and scale-unit symbol substrings.</summary>
        /// <param name="level">Input string to be tokenized.</param>
        /// <param name="scales">Scales allowed in the input string (providing allowed unit symbols).</param>
        /// <param name="matchunitsymbol">Predicate to check whether given scale-unit symbol is part of the input string.</param>
        /// <param name="number">Number string found in the input, or null if no allowed symbol has been found.</param>
        /// <param name="symbol">Scale-unit symbol string found in the input, or null if no allowed symbol has been found.</param>
        /// <returns>Scale representing scale-unit symbol found in the input string --or-- null if no allowed symbol has been found.</returns>
        public static Scale Tokenize(string level, IEnumerable<Scale> scales, Predicate<string> matchunitsymbol, out string number, out string symbol)
        {
            Scale scale = null;
            symbol = string.Empty;
            foreach(var sc in scales)
            {
                foreach(var s in sc.Unit.Symbol)
                {
                    if((symbol.Length < s.Length) && matchunitsymbol(s))
                    {
                        symbol = s;
                        scale = sc;
                    }
                }
            }
            number = (scale == null) ? null : level.Substring(0, level.Length - symbol.Length).Trim();
            return scale;
        }
    }
}
