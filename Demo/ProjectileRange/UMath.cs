/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.UnitsOfMeasurement
{
    public static class UMath
    {
        public static double Sin(Radian angle) { return Math.Sin(angle.Value); }
        public static double Cos(Radian angle) { return Math.Cos(angle.Value); }
        public static Meter_Sec Sqrt(Meter2_Sec2 squaredVelocity) { return new Meter_Sec(Math.Sqrt(squaredVelocity.Value)); }
    }
}
