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
            Allocate(
                63 + 29, // 63 units  + 29 entries for possible late units (1 for each family)
                4 + 1 // 4 scales + 1 entries for possible late scales (1 for each family)
            );
            Populate();
        }
        #endregion

        #region Populate
        public static void Populate()
        {
            // units:
            Add(Meter.Proxy);            // [L] Meter {"m"} : 1  (Meter)
            Add(Centimeter.Proxy);            // [L] Centimeter {"cm"} : 100  (Meter)
            Add(Millimeter.Proxy);            // [L] Millimeter {"mm"} : 1000  (Meter)
            Add(Kilometer.Proxy);            // [L] Kilometer {"km"} : 0.001  (Meter)
            Add(Inch.Proxy);            // [L] Inch {"in"} : 39.370078740157481  (Meter)
            Add(Foot.Proxy);            // [L] Foot {"ft"} : 3.2808398950131235  (Meter)
            Add(Yard.Proxy);            // [L] Yard {"yd"} : 1.0936132983377078  (Meter)
            Add(Mile.Proxy);            // [L] Mile {"mil"} : 0.000621371192237334  (Meter)
            Add(Second.Proxy);            // [T] Second {"s"} : 1  (Second)
            Add(Minute.Proxy);            // [T] Minute {"min"} : 0.016666666666666666  (Second)
            Add(Hour.Proxy);            // [T] Hour {"h"} : 0.00027777777777777778  (Second)
            Add(Kilogram.Proxy);            // [M] Kilogram {"kg"} : 1  (Kilogram)
            Add(Gram.Proxy);            // [M] Gram {"g"} : 1000  (Kilogram)
            Add(Tonne.Proxy);            // [M] Tonne {"t"} : 0.001  (Kilogram)
            Add(Pound.Proxy);            // [M] Pound {"lb"} : 2.2046226218487757  (Kilogram)
            Add(Ounce.Proxy);            // [M] Ounce {"ou"} : 35.273961949580411  (Kilogram)
            Add(DegKelvin.Proxy);            // [ϴ] DegKelvin {"K", "deg.K"} : 1  (DegKelvin)
            Add(DegCelsius.Proxy);            // [ϴ] DegCelsius {"\u00B0C", "deg.C"} : 1  (DegKelvin)
            Add(DegRankine.Proxy);            // [ϴ] DegRankine {"\u00B0R", "deg.R"} : 1.8  (DegKelvin)
            Add(DegFahrenheit.Proxy);            // [ϴ] DegFahrenheit {"\u00B0F", "deg.F"} : 1.8  (DegKelvin)
            Add(Ampere.Proxy);            // [I] Ampere {"A"} : 1  (Ampere)
            Add(Mole.Proxy);            // [N] Mole {"mol"} : 1  (Mole)
            Add(Candela.Proxy);            // [J] Candela {"cd"} : 1  (Candela)
            Add(EUR.Proxy);            // [¤] EUR {"EUR"} : 1  (EUR)
            Add(USD.Proxy);            // [¤] USD {"USD"} : 1.3433  (EUR)
            Add(GBP.Proxy);            // [¤] GBP {"GBP"} : 0.79055  (EUR)
            Add(PLN.Proxy);            // [¤] PLN {"PLN"} : 4.1437  (EUR)
            Add(Radian.Proxy);            // [1] Radian {"rad"} : 1  (Radian)
            Add(Degree.Proxy);            // [1] Degree {"\u00B0", "deg"} : (180d / Math.PI) * Radian.Factor  (Radian)
            Add(Grad.Proxy);            // [1] Grad {"grad"} : (200d / Math.PI) * Radian.Factor  (Radian)
            Add(Cycles.Proxy);            // [1] Cycles {"c"} : Radian.Factor / (2d * Math.PI)  (Radian)
            Add(Steradian.Proxy);            // [1] Steradian {"sr"} : 1  (Steradian)
            Add(Hertz.Proxy);            // [T-1] Hertz {"Hz"} : Cycles.Factor / Second.Factor  (Hertz)
            Add(Radian_Sec.Proxy);            // [T-1] Radian_Sec {"rad/s"} : 1  (Hertz)
            Add(RPM.Proxy);            // [T-1] RPM {"rpm"} : Cycles.Factor / Minute.Factor  (Hertz)
            Add(SquareMeter.Proxy);            // [L2] SquareMeter {"m\u00B2", "m2"} : 1  (SquareMeter)
            Add(SquareFoot.Proxy);            // [L2] SquareFoot {"ft\u00B2", "sq ft"} : 10.763910416709724  (SquareMeter)
            Add(CubicMeter.Proxy);            // [L3] CubicMeter {"m\u00B3", "m3"} : 1  (CubicMeter)
            Add(Meter_Sec.Proxy);            // [LT-1] Meter_Sec {"m/s"} : 1  (Meter_Sec)
            Add(Kilometer_Hour.Proxy);            // [LT-1] Kilometer_Hour {"km/h"} : 3.6  (Meter_Sec)
            Add(MPH.Proxy);            // [LT-1] MPH {"mph", "mi/h"} : 2.2369362920544025  (Meter_Sec)
            Add(Meter_Sec2.Proxy);            // [LT-2] Meter_Sec2 {"m/s2"} : 1  (Meter_Sec2)
            Add(Newton.Proxy);            // [LT-2M] Newton {"N"} : 1  (Newton)
            Add(PoundForce.Proxy);            // [LT-2M] PoundForce {"lbf"} : 0.2248089430997105  (Newton)
            Add(Poundal.Proxy);            // [LT-2M] Poundal {"pdl"} : 7.2330138512098943  (Newton)
            Add(Dyne.Proxy);            // [LT-2M] Dyne {"dyn"} : 100000  (Newton)
            Add(Joule.Proxy);            // [L2T-2M] Joule {"J"} : 1  (Joule)
            Add(Watt.Proxy);            // [L2T-3M] Watt {"W"} : 1  (Watt)
            Add(NewtonMeter.Proxy);            // [L2T-2M] NewtonMeter {"N\u00B7m", "N*m"} : 1  (NewtonMeter)
            Add(Joule_Kelvin.Proxy);            // [L2T-2Mϴ-1] Joule_Kelvin {"J/K"} : 1  (Joule_Kelvin)
            Add(Joule_Kelvin_Kilogram.Proxy);            // [L2T-2ϴ-1] Joule_Kelvin_Kilogram {"J/kg/K"} : 1  (Joule_Kelvin_Kilogram)
            Add(Pascal.Proxy);            // [L-1T-2M] Pascal {"Pa"} : 1  (Pascal)
            Add(Bar.Proxy);            // [L-1T-2M] Bar {"bar"} : 1E-05  (Pascal)
            Add(AtmTechnical.Proxy);            // [L-1T-2M] AtmTechnical {"at"} : 1.0197162129779282E-05  (Pascal)
            Add(AtmStandard.Proxy);            // [L-1T-2M] AtmStandard {"atm"} : 9.8692326671601285E-06  (Pascal)
            Add(MillimeterHg.Proxy);            // [L-1T-2M] MillimeterHg {"mmHg"} : 133.322387415  (Pascal)
            Add(Coulomb.Proxy);            // [TI] Coulomb {"C"} : 1  (Coulomb)
            Add(Volt.Proxy);            // [L2T-3MI-1] Volt {"V"} : 1  (Volt)
            Add(Ohm.Proxy);            // [L2T-3MI-2] Ohm {"\u03A9", "ohm"} : 1  (Ohm)
            Add(Siemens.Proxy);            // [L-2T3M-1I2] Siemens {"S"} : 1  (Siemens)
            Add(Farad.Proxy);            // [L-2T4M-1I2] Farad {"F"} : 1  (Farad)
            Add(Weber.Proxy);            // [L2T-2MI-1] Weber {"Wb"} : 1  (Weber)
            Add(Meter2_Sec2.Proxy);            // [L2T-2] Meter2_Sec2 {"m2/s2"} : 1  (Meter2_Sec2)

            // scales:
            Add(Kelvin.Proxy);            // [ϴ] Kelvin : AbsoluteZero = DegKelvin 0  (Kelvin)
            Add(Celsius.Proxy);            // [ϴ] Celsius : AbsoluteZero = DegCelsius -273.15  (Kelvin)
            Add(Rankine.Proxy);            // [ϴ] Rankine : AbsoluteZero = DegRankine 0  (Kelvin)
            Add(Fahrenheit.Proxy);            // [ϴ] Fahrenheit : AbsoluteZero = DegFahrenheit -459.66999999999996  (Kelvin)
        }
        #endregion
    }
}
