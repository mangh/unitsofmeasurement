/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;   // IEnumerable.GetEnumerator()
using System.Linq;

namespace Demo.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SymbolCollection : IEnumerable<string>
    {
        #region Fields
        private string[] m_collection;
        #endregion

        #region Properties
        public int Count { get { return m_collection.Length; } }
        #endregion

        #region Constructor(s)
        public SymbolCollection(params string[] symbols)
        {
            if ((symbols == null) || (symbols.Length < 1) || (Array.FindIndex(symbols, s => String.IsNullOrWhiteSpace(s)) >= 0))
                throw new ArgumentException("Symbol collection can neither be empty/null nor contain empty/null items.");

            m_collection = symbols;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<string> GetEnumerator() { return m_collection.Cast<string>().GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return m_collection.GetEnumerator(); }
        #endregion

        #region Indexer, Intersection
        public string this[int index]
        {
            get { return m_collection[index]; }
        }
        public int IndexOf(string symbol)
        {
            return Array.FindIndex(m_collection, s => SymbolCollection.Comparer.Equals(s, symbol));
        }
        public bool Intersects(IEnumerable<string> symbols)
        {
            return symbols.Any(s => this.IndexOf(s) >= 0);
        }
        #endregion

        #region Defaults
        private static IEqualityComparer<string> s_comparer = StringComparer.Ordinal;
        public static IEqualityComparer<string> Comparer { get { return s_comparer; } set { s_comparer = value; } }
        #endregion
    }
}
