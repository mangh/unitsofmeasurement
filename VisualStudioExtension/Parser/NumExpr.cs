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
    public class NumExpr
    {
        public Number Value { get; private set; }
        public string Code { get; private set; }
        public bool IsTrueValue { get; private set; }

        public NumExpr(bool isTrueValue, Number value, string code)
        {
            IsTrueValue = isTrueValue;
            Value = value;
            Code = code;
        }
    }
}
