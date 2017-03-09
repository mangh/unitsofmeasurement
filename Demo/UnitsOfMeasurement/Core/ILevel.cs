/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

namespace Demo.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface ILevel<T> where T : struct
    {
        // Level (instance) properties
        IQuantity<T> Level { get; }             // Level relative to scale zero level
        IQuantity<T> NormalizedLevel { get; }   // Level relative to family (common) reference point

        // Scale (class) properties
        Scale<T> Scale { get; }
    }
}
