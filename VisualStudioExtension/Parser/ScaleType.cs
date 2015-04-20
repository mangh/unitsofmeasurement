/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections;   // IEnumerable.GetEnumerator()
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ScaleType : MeasureType
    {
        public static readonly string DefaultRefPoint = "<common reference point>";

        #region Properties
        public UnitType Unit { get; private set; }
        public NumExpr Offset { get; private set; }
        public string RefPoint { get; private set; }
        public string RefPointNormalized { get { return String.IsNullOrWhiteSpace(RefPoint) ? ScaleType.DefaultRefPoint : RefPoint; } }
        public string Format { get; set; }
        #endregion

        #region Constructor(s)
        public ScaleType(string name, string refpoint, UnitType unit, NumExpr offset) :
            base(MeasureType.DefaultNamespace, name)
        {
            RefPoint = refpoint;
            Unit = unit;
            Offset = offset;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("[{0}] {1} : {2} = {3} {4}", Unit.Sense.Value, Name, RefPointNormalized, Unit.Name, Offset.Value);
        }
        #endregion
    }
}
