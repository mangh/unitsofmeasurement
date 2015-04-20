/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace $safeprojectname$
{
    public class UnitCatalog<T> where T : struct
    {
        #region Fields
        private List<Unit<T>> m_catalog;

        private string m_lastParsedNumber;
        private string m_lastParsedSymbol;
        private Unit<T> m_lastParsedMeasure;
        #endregion

        #region Properties
        public ITextParser TextParser { get; set; }
        public NumberStyles NumberStyle { get; set; }

        public string LastParsedNumber { get { return m_lastParsedNumber; } }
        public string LastParsedSymbol { get { return m_lastParsedSymbol; } }
        public Unit<T> LastParsedMeasure { get { return m_lastParsedMeasure; } }
        #endregion

        #region Constructor(s)
        public UnitCatalog(int capacity)
        {
            m_catalog = new List<Unit<T>>(capacity);
            NumberStyle = NumberStyles.Number;
            TextParser = new TextParser();
        }
        public UnitCatalog() :
            this(s_defaultCapacity)
        {
        }
        private static int s_defaultCapacity = 16;
        public static int DefaultCapacity { get { return s_defaultCapacity; } set { s_defaultCapacity = value; } }
        #endregion

        #region Populating
        public void Add(Type t)
        {
            Add(new Unit<T>(t));
        }
        public void Add(Unit<T> proxy)
        {
            if (this.Intersects(proxy.Symbol))
            {
                throw new ArgumentException(String.Format("{0}: duplicate item. All item symbols must be unique across the catalog.", proxy));
            }
            m_catalog.Add(proxy);
        }

        public void AppendFromAssembly(Assembly assembly, params int[] families) { AppendFromAssembly(assembly, m => Array.FindIndex(families, f => m.Family == f) >= 0); }
        public void AppendFromAssembly(Assembly assembly, params Dimension[] senses) { AppendFromAssembly(assembly, m => Array.FindIndex(senses, s => m.Sense == s) >= 0); }
        public void AppendFromAssembly(Assembly assembly, Predicate<Unit<T>> match = null)
        {
            foreach (Type t in assembly.GetExportedTypes())
            {
                if (Unit<T>.IsAssignableFrom(t))
                {
                    Unit<T> proxy = new Unit<T>(t);
                    if (((match == null) || match(proxy)))
                    {
                        Add(proxy);
                    }
                }
            }
        }
        #endregion

        #region Indexer(s)
        public Unit<T> this[string symbol] { get { return m_catalog.Find(proxy => proxy.Symbol.IndexOf(symbol) >= 0); } }
        public Unit<T> this[int index] { get { return m_catalog[index]; } }
        public int IndexOf(string symbol) { return m_catalog.FindIndex(proxy => proxy.Symbol.IndexOf(symbol) >= 0); }
        #endregion

        #region IEnumerable(s)
        public IEnumerable<Unit<T>> Items(Magnitude magnitude) { return Items(new Dimension(magnitude)); }
        public IEnumerable<Unit<T>> Items(Dimension dimension) { return Items(m => m.Sense == dimension); }
        public IEnumerable<Unit<T>> Items(int family) { return Items(m => m.Family == family); }
        public IEnumerable<Unit<T>> Items(Predicate<Unit<T>> match = null)
        {
            return match == null ? m_catalog : m_catalog.Where(m => match(m));
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
            if (TextParser.TryParse(input, fp, out m_lastParsedNumber, out m_lastParsedSymbol))
            {
                if ((m_lastParsedMeasure = this[m_lastParsedSymbol]) != null)
                {
                    T value;
                    if (UnitCatalog<T>.TryParseNumber(m_lastParsedNumber, style, fp, out value))
                    {
                        result = m_lastParsedMeasure.CreateQuantity(value);
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }
        private static readonly NumericParserDelegate<T> TryParseNumber = NumericParser.SelectDelegate(typeof(T)) as NumericParserDelegate<T>;
        #endregion

        #region Other methods
        public bool Intersects(IEnumerable<string> symbols)
        {
            return m_catalog.Any(measure => measure.Symbol.Intersects(symbols));
        }
        public int Count()
        {
            return m_catalog.Count();
        }
        public void Clear()
        {
            m_catalog.Clear();
        }
        #endregion

        #region Statics
        public static UnitCatalog<T> LoadFromAssembly(Assembly assembly, params int[] families) { return LoadFromAssembly(assembly, m => Array.FindIndex(families, f => m.Family == f) >= 0); }
        public static UnitCatalog<T> LoadFromAssembly(Assembly assembly, params Dimension[] senses) { return LoadFromAssembly(assembly, m => Array.FindIndex(senses, s => m.Sense == s) >= 0); }
        public static UnitCatalog<T> LoadFromAssembly(Assembly assembly, Predicate<Unit<T>> match = null)
        {
            UnitCatalog<T> catalog = new UnitCatalog<T>();
            catalog.AppendFromAssembly(assembly, match);
            return catalog;
        }
        #endregion
    }
}
