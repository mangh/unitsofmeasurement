/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public static partial class Catalog
    {
        #region Constructor
        static Catalog()
        {
            // 63 units + 1 extra entry for each of 29 families for possible late units
            // 4 scales + 1 extra entry for each of 1 families for possible late scales
            Allocate(63 + 29, 4 + 1);
            Populate();
        }
        #endregion

        #region Populate
        public static void Populate()
        {
            // units:
            Add(Meter.Proxy);               // Meter [L] Meter {"m"} : 1
            Add(Centimeter.Proxy);          // Meter [L] Centimeter {"cm"} : 100
            Add(Millimeter.Proxy);          // Meter [L] Millimeter {"mm"} : 1000
            Add(Kilometer.Proxy);           // Meter [L] Kilometer {"km"} : 0.001
            Add(Inch.Proxy);                // Meter [L] Inch {"in"} : 39.370078740157481
            Add(Foot.Proxy);                // Meter [L] Foot {"ft"} : 3.2808398950131235
            Add(Yard.Proxy);                // Meter [L] Yard {"yd"} : 1.0936132983377078
            Add(Mile.Proxy);                // Meter [L] Mile {"mil"} : 0.000621371192237334
            Add(Second.Proxy);              // Second [T] Second {"s"} : 1
            Add(Minute.Proxy);              // Second [T] Minute {"min"} : 0.016666666666666666
            Add(Hour.Proxy);                // Second [T] Hour {"h"} : 0.00027777777777777778
            Add(Kilogram.Proxy);            // Kilogram [M] Kilogram {"kg"} : 1
            Add(Gram.Proxy);                // Kilogram [M] Gram {"g"} : 1000
            Add(Tonne.Proxy);               // Kilogram [M] Tonne {"t"} : 0.001
            Add(Pound.Proxy);               // Kilogram [M] Pound {"lb"} : 2.2046226218487757
            Add(Ounce.Proxy);               // Kilogram [M] Ounce {"ou"} : 35.273961949580411
            Add(DegKelvin.Proxy);           // DegKelvin [ϴ] DegKelvin {"K", "deg.K"} : 1
            Add(DegCelsius.Proxy);          // DegKelvin [ϴ] DegCelsius {"\u00B0C", "deg.C"} : 1
            Add(DegRankine.Proxy);          // DegKelvin [ϴ] DegRankine {"\u00B0R", "deg.R"} : 1.8
            Add(DegFahrenheit.Proxy);       // DegKelvin [ϴ] DegFahrenheit {"\u00B0F", "deg.F"} : 1.8
            Add(Ampere.Proxy);              // Ampere [I] Ampere {"A"} : 1
            Add(Mole.Proxy);                // Mole [N] Mole {"mol"} : 1
            Add(Candela.Proxy);             // Candela [J] Candela {"cd"} : 1
            Add(EUR.Proxy);                 // EUR [¤] EUR {"EUR"} : 1
            Add(USD.Proxy);                 // EUR [¤] USD {"USD"} : 1.3433
            Add(GBP.Proxy);                 // EUR [¤] GBP {"GBP"} : 0.79055
            Add(PLN.Proxy);                 // EUR [¤] PLN {"PLN"} : 4.1437
            Add(Radian.Proxy);              // Radian [1] Radian {"rad"} : 1
            Add(Degree.Proxy);              // Radian [1] Degree {"\u00B0", "deg"} : (180d / System.Math.PI) * Radian.Factor
            Add(Grad.Proxy);                // Radian [1] Grad {"grad"} : (200d / System.Math.PI) * Radian.Factor
            Add(Cycles.Proxy);              // Radian [1] Cycles {"c"} : Radian.Factor / (2d * System.Math.PI)
            Add(Steradian.Proxy);           // Steradian [1] Steradian {"sr"} : 1
            Add(Hertz.Proxy);               // Hertz [T-1] Hertz {"Hz"} : Cycles.Factor / Second.Factor
            Add(Radian_Sec.Proxy);          // Hertz [T-1] Radian_Sec {"rad/s"} : 1
            Add(RPM.Proxy);                 // Hertz [T-1] RPM {"rpm"} : Cycles.Factor / Minute.Factor
            Add(SquareMeter.Proxy);         // SquareMeter [L2] SquareMeter {"m\u00B2", "m2"} : 1
            Add(SquareFoot.Proxy);          // SquareMeter [L2] SquareFoot {"ft\u00B2", "sq ft"} : 10.763910416709724
            Add(CubicMeter.Proxy);          // CubicMeter [L3] CubicMeter {"m\u00B3", "m3"} : 1
            Add(Meter_Sec.Proxy);           // Meter_Sec [LT-1] Meter_Sec {"m/s"} : 1
            Add(Kilometer_Hour.Proxy);      // Meter_Sec [LT-1] Kilometer_Hour {"km/h"} : 3.6
            Add(MPH.Proxy);                 // Meter_Sec [LT-1] MPH {"mph", "mi/h"} : 2.2369362920544025
            Add(Meter_Sec2.Proxy);          // Meter_Sec2 [LT-2] Meter_Sec2 {"m/s2"} : 1
            Add(Newton.Proxy);              // Newton [LT-2M] Newton {"N"} : 1
            Add(PoundForce.Proxy);          // Newton [LT-2M] PoundForce {"lbf"} : 0.2248089430997105
            Add(Poundal.Proxy);             // Newton [LT-2M] Poundal {"pdl"} : 7.2330138512098943
            Add(Dyne.Proxy);                // Newton [LT-2M] Dyne {"dyn"} : 100000
            Add(Joule.Proxy);               // Joule [L2T-2M] Joule {"J"} : 1
            Add(Watt.Proxy);                // Watt [L2T-3M] Watt {"W"} : 1
            Add(NewtonMeter.Proxy);         // NewtonMeter [L2T-2M] NewtonMeter {"N\u00B7m", "N*m"} : 1
            Add(Joule_Kelvin.Proxy);        // Joule_Kelvin [L2T-2Mϴ-1] Joule_Kelvin {"J/K"} : 1
            Add(Joule_Kelvin_Kilogram.Proxy); // Joule_Kelvin_Kilogram [L2T-2ϴ-1] Joule_Kelvin_Kilogram {"J/kg/K"} : 1
            Add(Pascal.Proxy);              // Pascal [L-1T-2M] Pascal {"Pa"} : 1
            Add(Bar.Proxy);                 // Pascal [L-1T-2M] Bar {"bar"} : 1E-05
            Add(AtmTechnical.Proxy);        // Pascal [L-1T-2M] AtmTechnical {"at"} : 1.0197162129779282E-05
            Add(AtmStandard.Proxy);         // Pascal [L-1T-2M] AtmStandard {"atm"} : 9.8692326671601285E-06
            Add(MillimeterHg.Proxy);        // Pascal [L-1T-2M] MillimeterHg {"mmHg"} : 133.322387415
            Add(Coulomb.Proxy);             // Coulomb [TI] Coulomb {"C"} : 1
            Add(Volt.Proxy);                // Volt [L2T-3MI-1] Volt {"V"} : 1
            Add(Ohm.Proxy);                 // Ohm [L2T-3MI-2] Ohm {"\u03A9", "ohm"} : 1
            Add(Siemens.Proxy);             // Siemens [L-2T3M-1I2] Siemens {"S"} : 1
            Add(Farad.Proxy);               // Farad [L-2T4M-1I2] Farad {"F"} : 1
            Add(Weber.Proxy);               // Weber [L2T-2MI-1] Weber {"Wb"} : 1
            Add(Meter2_Sec2.Proxy);         // Meter2_Sec2 [L2T-2] Meter2_Sec2 {"m2/s2"} : 1

            // scales:
            Add(Kelvin.Proxy);              // Kelvin [ϴ] Kelvin : AbsoluteZero = DegKelvin 0
            Add(Celsius.Proxy);             // Kelvin [ϴ] Celsius : AbsoluteZero = DegCelsius -273.15
            Add(Rankine.Proxy);             // Kelvin [ϴ] Rankine : AbsoluteZero = DegRankine 0
            Add(Fahrenheit.Proxy);          // Kelvin [ϴ] Fahrenheit : AbsoluteZero = DegFahrenheit -459.66999999999996
        }
        #endregion
    }
}
