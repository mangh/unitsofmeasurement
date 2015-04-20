/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;

namespace $safeprojectname$
{
    public interface ITextParser
    {
        bool TryParse(string input, IFormatProvider fp, out string number, out string symbol);
    }
}
