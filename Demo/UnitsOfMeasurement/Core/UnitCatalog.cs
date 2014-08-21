/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Demo.UnitsOfMeasurement
{
    public class UnitCatalog
    {
        #region Fields
        private Dictionary<string, UnitProxy> m_dictionary;
        #endregion

        #region Properties
        public ITextParser Parser { get; set; }
        public NumberStyles NumberStyle { get; set; }
        #endregion

        #region Constructor(s)
        public UnitCatalog(int capacity)
        {
            NumberStyle = NumberStyles.Number;
            Parser = new TextParser();
            m_dictionary = new Dictionary<string, UnitProxy>(capacity, SymbolCollection.Comparer);
        }
        public UnitCatalog() :
            this(s_defaultCapacity)
        {
        }
        #endregion

        #region Methods
        public void Add(UnitProxy proxy)
        {
            SymbolCollection collection = proxy.Symbol;
            foreach (string symbol in collection) m_dictionary.Add(symbol, proxy);
        }
        public void Add(Type unit)
        {
            Add(new UnitProxy(unit));
        }
        public int Count()
        {
            return m_dictionary.Count();
        }
        public void Clear()
        {
            m_dictionary.Clear();
        }
        public void AppendFromAssembly(string assemblyPath, Predicate<UnitProxy> match)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            foreach (Type t in assembly.GetExportedTypes())
            {
                if (UnitProxy.IsAssignableFrom(t))
                {
                    UnitProxy proxy = new UnitProxy(t);
                    if ((match == null) || match(proxy))
                    {
                        Add(proxy);
                    }
                }
            }
        }
        public void AppendFromAssembly(string assemblyPath, int family) { AppendFromAssembly(assemblyPath, u => u.Family == family); }
        public void AppendFromAssembly(string assemblyPath, Dimension sense) { AppendFromAssembly(assemblyPath, u => u.Sense == sense); }
        public void LoadFromAssembly(string assemblyPath) { Clear(); AppendFromAssembly(assemblyPath, null); }
        #endregion

        #region Indexer(s)
        public UnitProxy this[string symbol]
        {
            get { UnitProxy proxy; return (m_dictionary.TryGetValue(symbol, out proxy) ? proxy : null); }
        }
        #endregion

        #region IEnumerable(s)
        public IEnumerable<UnitProxy> Units(Magnitude magnitude)
        {
            return Units(new Dimension(magnitude));
        }

        public IEnumerable<UnitProxy> Units(Dimension dimension)
        {
            return (from kv in m_dictionary where kv.Value.Sense == dimension select kv.Value).Distinct();
        }

        public IEnumerable<UnitProxy> Units(int family)
        {
            return (from kv in m_dictionary where kv.Value.Family == family select kv.Value).Distinct();
        }

        public IEnumerable<string> Symbols(Magnitude magnitude)
        {
            return Symbols(new Dimension(magnitude));
        }

        public IEnumerable<string> Symbols(Dimension dimension)
        {
            return (from kv in m_dictionary where kv.Value.Sense == dimension select kv.Key).Distinct();
        }

        public IEnumerable<string> Symbols(int family)
        {
            return (from kv in m_dictionary where kv.Value.Family == family select kv.Key).Distinct();
        }
        #endregion

        #region Parsing
        public bool TryParse(string input, out IQuantity<double> result) { return TryParse(input, CultureInfo.CurrentCulture, out result); }
        public bool TryParse(string input, IFormatProvider fp, out IQuantity<double> result) { return TryParse(input, fp, this.NumberStyle, out result); }
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out IQuantity<double> result)
        {
            result = null;
            string[] token; double value; UnitProxy proxy;
            if (((token = this.Parser.TryParse(input, fp)) != null) &&
                double.TryParse(token[0], style, fp, out value) &&
                ((proxy = this[token[1]]) != null))
            {
                result = (IQuantity<double>)proxy.CreateInstance(value);
            }
            return (result != null);
        }

        public bool TryParse(string input, out IQuantity<float> result) { return TryParse(input, CultureInfo.CurrentCulture, out result); }
        public bool TryParse(string input, IFormatProvider fp, out IQuantity<float> result) { return TryParse(input, fp, this.NumberStyle, out result); }
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out IQuantity<float> result)
        {
            result = null;
            string[] token; float value; UnitProxy proxy;
            if (((token = this.Parser.TryParse(input, fp)) != null) &&
                float.TryParse(token[0], style, fp, out value) &&
                ((proxy = this[token[1]]) != null))
            {
                result = (IQuantity<float>)proxy.CreateInstance(value);
            }
            return (result != null);
        }

        public bool TryParse(string input, out IQuantity<decimal> result) { return TryParse(input, CultureInfo.CurrentCulture, out result); }
        public bool TryParse(string input, IFormatProvider fp, out IQuantity<decimal> result) { return TryParse(input, fp, this.NumberStyle, out result); }
        public bool TryParse(string input, IFormatProvider fp, NumberStyles style, out IQuantity<decimal> result)
        {
            result = null;
            string[] token; decimal value; UnitProxy proxy;
            if (((token = this.Parser.TryParse(input, fp)) != null) &&
                decimal.TryParse(token[0], style, fp, out value) &&
                ((proxy = this[token[1]]) != null))
            {
                result = (IQuantity<decimal>)proxy.CreateInstance(value);
            }
            return (result != null);
        }
        #endregion

        #region Defaults
        private static int s_defaultCapacity = 16;
        public static int DefaultCapacity { get { return s_defaultCapacity; } set { s_defaultCapacity = value; } }
        #endregion
    }
}
