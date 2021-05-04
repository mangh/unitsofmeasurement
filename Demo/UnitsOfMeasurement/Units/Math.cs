/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

namespace Demo.UnitsOfMeasurement
{
    public static class Math
    {
        public static double Sin(Radian angle) => System.Math.Sin(angle.Value);
        public static double Cos(Radian angle) => System.Math.Cos(angle.Value);

        public static Meter_Sec Sqrt(Meter2_Sec2 squaredVelocity) => new Meter_Sec(System.Math.Sqrt(squaredVelocity.Value));
    }
}
