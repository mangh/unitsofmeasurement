/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;

namespace Demo.UnitsOfMeasurement
{
    public interface ITextParser
    {
        string[] TryParse(string input, IFormatProvider fp);
    }
}
