/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SenseExpr
    {
        public Dimension Value { get; private set; }
        public string Code { get; private set; }
        public bool IsSenseless { get { return Value == Dimension.None; } }

        public SenseExpr(Dimension value, string code)
        {
            Value = value;
            Code = code;
        }
    }
}
