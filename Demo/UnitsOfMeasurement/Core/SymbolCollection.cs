/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;	// IEnumerable.GetEnumerator()

namespace Demo.UnitsOfMeasurement
{
	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class SymbolCollection
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
				throw new ArgumentException("Unit symbol collection cannot be empty/null or contain empty/null items.");

			m_collection = symbols;
		}
        #endregion

        #region IEnumerator, Indexer
        public IEnumerator GetEnumerator() { return m_collection.GetEnumerator(); }
        public string this[int index] { get { return m_collection[index]; } }
        public int Index(string symbol)
        {
            return Array.FindIndex(m_collection, s => SymbolCollection.Comparer.Equals(s, symbol));
        }
        #endregion

        #region Defaults
        private static IEqualityComparer<string> s_comparer = StringComparer.Ordinal;
        public static IEqualityComparer<string> Comparer { get { return s_comparer; } set { s_comparer = value; } }
        #endregion
    }
}
