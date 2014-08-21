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
    public interface ILevel<T> where T : struct
    {
        // Instance properties
        IQuantity<T> Level { get; }
        IQuantity<T> Extent { get; }

        // Scale properties
        IQuantity<T> ScaleOffset { get; }
        string ScaleFormat { get; }
    }
}
