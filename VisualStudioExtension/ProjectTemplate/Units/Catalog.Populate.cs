/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public static partial class Catalog
    {
        #region Constructor
        static Catalog()
        {
            // 15 units + 1 extra entry for each of 11 families for possible late units
            // 3 scales + 1 extra entry for each of 1 families for possible late scales
            Allocate(15 + 11, 3 + 1);
            Populate();
        }
        #endregion

        #region Populate
        public static void Populate()
        {
            // units:
            Add(Meter.Proxy);               // Meter [L] Meter {"m"} : 1
            Add(Second.Proxy);              // Second [T] Second {"s"} : 1
            Add(Kilogram.Proxy);            // Kilogram [M] Kilogram {"kg"} : 1
            Add(DegKelvin.Proxy);           // DegKelvin [ϴ] DegKelvin {"K", "deg.K"} : 1
            Add(DegCelsius.Proxy);          // DegKelvin [ϴ] DegCelsius {"\u00B0C", "deg.C"} : 1
            Add(DegFahrenheit.Proxy);       // DegKelvin [ϴ] DegFahrenheit {"\u00B0F", "deg.F"} : 1.8
            Add(EUR.Proxy);                 // EUR [¤] EUR {"EUR"} : 1
            Add(PLN.Proxy);                 // EUR [¤] PLN {"PLN"} : 4.1437
            Add(Radian.Proxy);              // Radian [1] Radian {"rad"} : 1
            Add(Degree.Proxy);              // Radian [1] Degree {"\u00B0", "deg"} : (180d / System.Math.PI) * Radian.Factor
            Add(Meter_Sec.Proxy);           // Meter_Sec [LT-1] Meter_Sec {"m/s"} : 1
            Add(Meter_Sec2.Proxy);          // Meter_Sec2 [LT-2] Meter_Sec2 {"m/s2"} : 1
            Add(Newton.Proxy);              // Newton [LT-2M] Newton {"N"} : 1
            Add(Joule.Proxy);               // Joule [L2T-2M] Joule {"J"} : 1
            Add(NewtonMeter.Proxy);         // NewtonMeter [L2T-2M] NewtonMeter {"N\u00B7m", "N*m"} : 1

            // scales:
            Add(Kelvin.Proxy);              // Kelvin [ϴ] Kelvin : AbsoluteZero = DegKelvin 0
            Add(Celsius.Proxy);             // Kelvin [ϴ] Celsius : AbsoluteZero = DegCelsius -273.15
            Add(Fahrenheit.Proxy);          // Kelvin [ϴ] Fahrenheit : AbsoluteZero = DegFahrenheit -459.66999999999996
        }
        #endregion
    }
}
