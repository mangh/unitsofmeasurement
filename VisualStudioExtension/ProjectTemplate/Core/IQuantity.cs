/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

namespace $safeprojectname$
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IQuantity<T> where T : struct
    {
        T Value { get; }
    }
}
