/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System.Collections;   // IEnumerable.GetEnumerator()
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ScaleType : MeasureType
    {
        #region Properties
        public UnitType Unit { get; private set; }
        public NumExpr Offset { get; set; }
        public string Format { get; set; }
        #endregion

        #region Constructor(s)
        public ScaleType(string nameSpace, string name, UnitType unit) :
            base(nameSpace, name)
        {
            Unit = unit;
        }
        #endregion
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ScaleTypes : IEnumerable<ScaleType>
    {
        #region Fields
        private List<ScaleType> m_collection;
        #endregion

        #region Properties
        #endregion

        #region Constructor(s)
        public ScaleTypes()
        {
            m_collection = new List<ScaleType>();
        }
        #endregion

        #region Methods
        public ScaleType Find(string nameSpace, string name)
        {
            return m_collection.Find(t => (t.Namespace == nameSpace) && (t.Name == name));
        }
        public void Add(ScaleType scale)
        {
            ScaleType relative = m_collection.Find(s => s.Unit.Family == scale.Unit.Family);
            if (relative != null) relative.AddRelative(scale);
            m_collection.Add(scale);
        }
        // IEnumerable<T> interface
        public IEnumerator<ScaleType> GetEnumerator() { return m_collection.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return m_collection.GetEnumerator(); }
        #endregion
    }
}
