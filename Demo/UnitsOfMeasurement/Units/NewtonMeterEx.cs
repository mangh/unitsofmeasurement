/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

namespace Demo.UnitsOfMeasurement
{
    public partial struct NewtonMeter
    {
        public static Newton operator /(NewtonMeter lhs, Meter rhs) { return new Newton(lhs.Value / rhs.Value); }
        public static Meter operator /(NewtonMeter lhs, Newton rhs) { return new Meter(lhs.Value / rhs.Value); }
    }
}
