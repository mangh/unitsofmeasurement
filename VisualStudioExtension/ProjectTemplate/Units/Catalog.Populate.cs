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
            Allocate(
                15 + 11, // 15 units  + 11 entries for possible late units (1 for each family)
                3 + 1 // 3 scales + 1 entries for possible late scales (1 for each family)
            );
            Populate();
        }
        #endregion

        #region Populate
        public static void Populate()
        {
            // units:
            Add(Meter.Proxy);            // [L] Meter {"m"} : 1  (Meter)
            Add(Second.Proxy);            // [T] Second {"s"} : 1  (Second)
            Add(Kilogram.Proxy);            // [M] Kilogram {"kg"} : 1  (Kilogram)
            Add(DegKelvin.Proxy);            // [ϴ] DegKelvin {"K", "deg.K"} : 1  (DegKelvin)
            Add(DegCelsius.Proxy);            // [ϴ] DegCelsius {"\u00B0C", "deg.C"} : 1  (DegKelvin)
            Add(DegFahrenheit.Proxy);            // [ϴ] DegFahrenheit {"\u00B0F", "deg.F"} : 1.8  (DegKelvin)
            Add(EUR.Proxy);            // [¤] EUR {"EUR"} : 1  (EUR)
            Add(PLN.Proxy);            // [¤] PLN {"PLN"} : 4.1437  (EUR)
            Add(Radian.Proxy);            // [1] Radian {"rad"} : 1  (Radian)
            Add(Degree.Proxy);            // [1] Degree {"\u00B0", "deg"} : (180d / Math.PI) * Radian.Factor  (Radian)
            Add(Meter_Sec.Proxy);            // [LT-1] Meter_Sec {"m/s"} : 1  (Meter_Sec)
            Add(Meter_Sec2.Proxy);            // [LT-2] Meter_Sec2 {"m/s2"} : 1  (Meter_Sec2)
            Add(Newton.Proxy);            // [LT-2M] Newton {"N"} : 1  (Newton)
            Add(Joule.Proxy);            // [L2T-2M] Joule {"J"} : 1  (Joule)
            Add(NewtonMeter.Proxy);            // [L2T-2M] NewtonMeter {"N\u00B7m", "N*m"} : 1  (NewtonMeter)

            // scales:
            Add(Kelvin.Proxy);            // [ϴ] Kelvin : AbsoluteZero = DegKelvin 0  (Kelvin)
            Add(Celsius.Proxy);            // [ϴ] Celsius : AbsoluteZero = DegCelsius -273.15  (Kelvin)
            Add(Fahrenheit.Proxy);            // [ϴ] Fahrenheit : AbsoluteZero = DegFahrenheit -459.66999999999996  (Kelvin)
        }
        #endregion
    }
}
