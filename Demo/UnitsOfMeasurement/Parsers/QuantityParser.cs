/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Demo.UnitsOfMeasurement
{
    public class QuantityParser<T>
        where T : struct
    {
        #region Quantity tokenizer delegate
        public delegate Unit<T> Tokenizer(string quantity, IEnumerable<Unit<T>> units, out string number, out string symbol);
        #endregion

        #region Properties
        public IEnumerable<Unit<T>> Units { get; private set; }
        public NumberStyles NumberStyle { get; set; }
        public Tokenizer TryTokenize { get; set; }
        #endregion

        #region Constructor(s)
        public QuantityParser(IEnumerable<Unit<T>> allowedUnits)
        {
            Units = allowedUnits;
            NumberStyle = NumberStyles.Float;
            TryTokenize = TokenizePostfixed;
        }
        public QuantityParser(IEnumerable<Scale<T>> allowedScales) :
            this(Catalog.Units<T>(allowedScales))
        {
        }
        public QuantityParser(int family) :
            this(Catalog.Units<T>(family))
        {
        }
        #endregion

        #region Parsing
        public bool TryParse(string input, out IQuantity<T> result)
        {
            return TryParse(input, CultureInfo.CurrentCulture, this.NumberStyle, out result);
        }
        public bool TryParse(string input, IFormatProvider fp, out IQuantity<T> result)
        {
            return TryParse(input, fp, this.NumberStyle, out result);
        }
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out IQuantity<T> result)
        {
            string number;
            string symbol;
            T value;
            Unit<T> unit = TryTokenize(input, Units, out number, out symbol);
            if((unit != null) && TryParseNumber(number, style, fp, out value))
            {
                result = unit.Create(value);
                return true;
            }
            result = null;
            return false;
        }
        #endregion

        #region Tokenizers
        public static Unit<T> TokenizePrefixed(string quantity, IEnumerable<Unit<T>> units, out string number, out string symbol)
        {
            return QuantityTokenizer.Tokenize(quantity, units, u => quantity.StartsWith(u, StringComparison.Ordinal), out number, out symbol) as Unit<T>;
        }
        public static Unit<T> TokenizePostfixed(string quantity, IEnumerable<Unit<T>> units, out string number, out string symbol)
        {
            return QuantityTokenizer.Tokenize(quantity, units, u => quantity.EndsWith(u, StringComparison.Ordinal), out number, out symbol) as Unit<T>;
        }
        private static readonly NumericParserDelegate<T> TryParseNumber = NumericParser.SelectDelegate(typeof(T)) as NumericParserDelegate<T>;
        #endregion
    }

    public static class QuantityTokenizer
    {
        /// <summary>Tokenize quantity string into number and unit symbol substrings.</summary>
        /// <param name="quantity">Input string to be tokenized.</param>
        /// <param name="units">Units allowed in the input string (providing allowed unit symbols).</param>
        /// <param name="matchunitsymbol">Predicate to check whether given unit symbol is part of the input string.</param>
        /// <param name="number">Number found in the input string.</param>
        /// <param name="symbol">Unit symbol found in the input string.</param>
        /// <returns>Unit representing unit symbol found in the input string --or-- null if no allowed unit has been found.</returns>
        public static Unit Tokenize(string quantity, IEnumerable<Unit> units, Predicate<string> matchunitsymbol, out string number, out string symbol)
        {
            Unit unit = null;
            symbol = string.Empty;
            foreach(var u in units)
            {
                foreach(var s in u.Symbol)
                {
                    if((symbol.Length < s.Length) && matchunitsymbol(s))
                    {
                        symbol = s;
                        unit = u;
                    }
                }
            }
            number = (unit == null) ? null : quantity.Substring(0, quantity.Length - symbol.Length).Trim();
            return unit;
        }
    }
}
