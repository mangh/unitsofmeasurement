/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

namespace Demo.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IQuantity<T> where T : struct
    {
        // Instance/quantity property 
        T Value { get; }

        // Type/unit properties & methods 
        Dimension UnitSense { get; }
        int UnitFamily { get; }
        T UnitFactor { get; }
        string UnitFormat { get; }
        SymbolCollection UnitSymbol { get; }
    }
}
