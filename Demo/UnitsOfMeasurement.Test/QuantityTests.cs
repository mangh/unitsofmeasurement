/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Linq;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.UnitsOfMeasurement;

namespace UnitOfMeasureTest
{
    [TestClass]
    public class QuantityTests
    {
        [TestClass]
        public class Conversions
        {
            [TestMethod]
            [ExpectedException(typeof(System.InvalidOperationException))]
            public void CastingInconvertibleThrowsException()
            {
                Meter meters = (Meter)5.0;

                // The following is rejected at compile time with error message: Cannot convert type 'Meter' to 'Kilogram'
                //var badSyntax = (Kilogram)meters;

                // The following is rejected at compile time too with error message: Operator '/' cannot be applied to operands of type 'Meter' and 'Kilogram'
                //var badSyntax = meters / (Kilogram)10.0;

                // But the following fails only at runtime throwing InvalidOperationException: Cannot convert type "Meter" to "Kilogram"
                var badCast = Kilogram.From(meters);
            }

            [TestMethod]
            [ExpectedException(typeof(System.InvalidCastException))]
            public void InvalidCastingThrowsException()
            {
                IQuantity<double> quantity = (Meter)10.0;

                // The following is a valid conversion:
                Yard yards = (Yard)(Meter)quantity;
                Assert.AreEqual((Yard)10.936132983377078, yards, "Meter-to-Yard conversion failed");

                // ... and the following is a valid conversion:
                yards = Yard.From(quantity);
                Assert.AreEqual((Yard)10.936132983377078, yards, "IQuantity-to-Yard conversion failed");

                // ... but the following fails at runtime throwing InvalidCastException: Specified cast is not valid
                var badCast = (Yard)quantity;
            }

            [TestMethod]
            public void TemperatureUnits()
            {
                DegCelsius celsius = new DegCelsius(100.0);
                DegFahrenheit fahrenheit = (DegFahrenheit)celsius;
                DegRankine rankine = (DegRankine)fahrenheit;
                DegKelvin kelvin = (DegKelvin)rankine;
                celsius = (DegCelsius)kelvin;

                Assert.AreEqual((DegFahrenheit)180.0, fahrenheit, "Celsius-to-Fahrenheit conversion failed");
                Assert.AreEqual((DegRankine)180.0, rankine, "Fahrenheit-to-Rankine conversion failed");
                Assert.AreEqual((DegKelvin)100.0, kelvin, "Rankine-to-Kelvin conversion failed");
                Assert.AreEqual((DegCelsius)100.0, celsius, "Kelvin-to-Celsius conversion failed");
            }

            [TestMethod]
            public void LengthUnits()
            {
                Meter meters = new Meter(100.0);
                Centimeter centimeters = (Centimeter)meters;
                Inch inches = (Inch)centimeters;
                Foot feet = (Foot)inches;
                Yard yards = (Yard)feet;
                meters = (Meter)yards;

                Assert.AreEqual((Centimeter)10000.0, centimeters, "Meter-to-Centimeter conversion failed");
                Assert.AreEqual((Inch)3937.0078740157483, inches, "Centimeter-to-Inch conversion failed");
                Assert.AreEqual((Foot)328.08398950131232, feet, "Inch-to-Feet conversion failed");
                Assert.AreEqual((Yard)109.36132983377077, yards, "Feet-to-Yard conversion failed");
                Assert.AreEqual((Meter)99.999999999999986, meters, "Yard-to-Meter conversion failed");
            }

            [TestMethod]
            public void PlaneAngleUnits()
            {
                Cycles cycles = (Cycles)1.0;
                Radian radians = (Radian)cycles;
                Degree degrees = (Degree)radians;
                Grad grads = (Grad)degrees;

                cycles = (Cycles)grads;

                Assert.AreEqual((Radian)(2.0 * Math.PI), radians, "Cycles-to-Radian conversion failed");
                Assert.AreEqual((Degree)360.0, degrees, "Radian-to-Degree conversion failed");
                Assert.AreEqual((Grad)400.0, grads, "Degree-to-Grad conversion failed");
                Assert.AreEqual((Cycles)1.0, cycles, "Grad-to-Cycles conversion failed");
            }

            [TestMethod]
            public void MassUnits()
            {
                Kilogram kilograms = (Kilogram)1.0;
                Gram grams = (Gram)kilograms;
                Tonne tonnes = (Tonne)grams;
                Pound pounds = (Pound)tonnes;
                Ounce ounces = (Ounce)pounds;

                kilograms = (Kilogram)ounces;

                Assert.AreEqual((Gram)1000.0, grams, "Kilogram-to-Gram conversion failed (1)");
                Assert.AreEqual((Tonne)0.001, tonnes, "Gram-to-Tonne conversion failed (1)");
                Assert.AreEqual((Pound)2.2046226218487757, pounds, "Tonne-to-Pound conversion failed (1)");
                Assert.AreEqual((Ounce)35.273961949580411, ounces, "Pound-to-Ounce conversion failed (1)");
                Assert.AreEqual((Kilogram)1.0, kilograms, "Ounce-to-Kilogram conversion failed (1)");

                Assert.AreEqual(16.0, ounces.Value / pounds.Value, "Incorrect Ounce-to-Pound conversion factor (1)");

                pounds = (Pound)1.0;
                kilograms = (Kilogram)pounds;
                grams = (Gram)kilograms;
                tonnes = (Tonne)grams;
                ounces = (Ounce)tonnes;

                pounds = (Pound)ounces;

                Assert.AreEqual((Kilogram)0.45359237, kilograms, "Pound-to-Kilogram conversion failed (2)");
                Assert.AreEqual((Gram)453.59237, grams, "Kilogram-to-Gram conversion failed (2)");
                Assert.AreEqual((Tonne)0.00045359237, tonnes, "Gram-to-Tonne conversion failed (2)");
                Assert.AreEqual((Ounce)15.999999999999996, ounces, "Tonne-to-Ounce conversion failed (2)");
                Assert.AreEqual((Pound)0.99999999999999978, pounds, "Ounce-to-Pound conversion failed (2)");

                Assert.AreEqual(16.0, ounces.Value / pounds.Value, "Incorrect Ounce-to-Pound conversion factor (2)");
            }

            [TestMethod]
            public void FrequencyUnits()
            {
                RPM rpm = (RPM)7200;
                Hertz frequency = (Hertz)rpm;
                Radian_Sec angularvelocity = (Radian_Sec)frequency;

                rpm = (RPM)angularvelocity;

                Assert.AreEqual((Hertz)120.0, frequency, "RPM-to-Hetrz conversion failed");
                Assert.AreEqual((Radian_Sec)(240.0 * Math.PI), angularvelocity, "Hertz-to-Radian_Sec conversion failed");
                Assert.AreEqual((RPM)7200.0, rpm, "Radian_Sec-to-RPM conversion failed");

                Second duration = (Second)1.0;
                Cycles revolutions = frequency * duration;
                Assert.AreEqual((Cycles)120.0, revolutions, "revolutions = frequency * duration conversion failed");
            }

            [TestMethod]
            public void TorqueAndEnergy()
            {
                Assert.AreEqual(Joule.Sense, NewtonMeter.Sense, "Joule and NewtonMeter dimension are different");
                Assert.AreNotEqual(Joule.Family, NewtonMeter.Family, "Joule and NewtonMeter families are the same");

                Meter distance = (Meter)10.0;
                Newton force = (Newton)100.0;

                Joule energy = force * distance;
                Assert.AreEqual((Joule)1000.0, energy, "Energy calculation failed");

                NewtonMeter torque = force ^ distance;
                Assert.AreEqual((NewtonMeter)1000.0, torque, "Torque calculation failed");

                Meter distanceFromEnergy = energy / force;
                Meter distanceFromTorque = torque / force;
                Assert.AreEqual(distanceFromEnergy, distanceFromTorque, "Distances from Energy and Torque are different");

                Newton forceFromEnergy = energy / distance;
                Newton forceFromTorque = torque / distance;
                Assert.AreEqual(forceFromEnergy, forceFromTorque, "Forces from Energy and Torque are different");

                var catalog = new UnitCatalog<double>();
                catalog.Add(typeof(Joule));
                catalog.Add(typeof(NewtonMeter));
                Assert.AreEqual(1, catalog.Items(Joule.Family).Count(), "Selection by Family failed");
                Assert.AreEqual(2, catalog.Items(Joule.Sense).Count(), "Selection by Dimension failed");
            }

            [TestMethod]
            public void ElectricUnits()
            {
                // Hearing aid (typically 1 mW at 1.4 V): 0.7 mA
                Volt haVoltage = (Volt)1.4;
                Ampere haAmps = (Watt)0.001 / haVoltage;
                Assert.AreEqual((Ampere)0.00071428571428571439, haAmps, "Hearing aid amperage calculation failed");
                Ohm haOhms = haVoltage / haAmps;
                Assert.AreEqual((Ohm)1959.9999999999995, haOhms, "Hearing aid resistance calculation failed");

                // A typical motor vehicle has a 12 V battery.
                Volt batteryVoltage = (Volt)12.0;

                // The various accessories that are powered by the battery might include:

                // Instrument panel light (typically 2 W): 166 mA.
                Ampere panelAmps = (Watt)2.0 / batteryVoltage;
                Assert.AreEqual((Ampere)0.16666666666666666, panelAmps, "Car instrument panel amperage calculation failed");

                Ohm panelOhms = batteryVoltage / panelAmps;
                Assert.AreEqual((Ohm)72.0, panelOhms, "Car instrument panel resistance calculation failed");

                // Headlights (typically 60 W): 5 A each.
                Ampere lightsAmps = (Watt)60.0 / batteryVoltage;
                Assert.AreEqual((Ampere)5.0, lightsAmps, "Car headlights amperage calculation failed");

                Ohm lightsOhms = batteryVoltage / lightsAmps;
                Assert.AreEqual((Ohm)2.4, lightsOhms, "Car headlights resistance calculation failed");

                // Starter Motor (typically 1–2 kW): 80-160 A
                Ampere starterAmps = (Watt)1500.0 / batteryVoltage;
                Assert.AreEqual((Ampere)125.0, starterAmps, "Car starter motor amperage calculation failed");

                Ohm starterOhms = batteryVoltage / starterAmps;
                Assert.AreEqual((Ohm)0.096, starterOhms, "Car starter motor resistance calculation failed");
            }
        }

        [TestClass]
        public class ComaprisonOperators
        {
            [TestMethod]
            public void FloatingPointMangle()
            {
                var expected = (Meter)100.0;
                var calculated = (Meter)(Yard)(Foot)(Inch)(Centimeter)expected;
                // unfortunately, due to whimsical floating-point accuracy...:
                Assert.AreNotEqual(expected, calculated);
                // but...:
                Assert.AreEqual((Meter)99.999999999999986, calculated);
            }

            [TestMethod]
            public void CompareQuantities()
            {
                {
                    // 5.0 tonnes == 5000 kilograms
                    Tonne tonnes = (Tonne)5.0;
                    Kilogram kilograms = (Kilogram)5000.0;
                    Assert.IsTrue((tonnes.Value != kilograms.Value) && (tonnes == (Tonne)kilograms));
                }
                {
                    // 5 pounds < 5 kilograms
                    Pound pounds = (Pound)5.0;
                    Kilogram kilograms = (Kilogram)5.0;
                    Assert.IsTrue((kilograms.Value == pounds.Value) && ((Kilogram)pounds != kilograms) && (pounds < (Pound)kilograms) && (kilograms >= (Kilogram)pounds));
                }
                {
                    // 5 tonnes > 3000 kilograms
                    Tonne tonnes = (Tonne)5.0;
                    Kilogram kilograms = (Kilogram)3000.0;
                    Assert.IsTrue((tonnes.Value < kilograms.Value) && (tonnes != (Tonne)kilograms) && ((Kilogram)tonnes > kilograms) && ((Tonne)kilograms <= tonnes));
                }
            }
        }


        [TestClass]
        public class AdditiveOperators
        {
            [TestMethod]
            public void AddSubtract()
            {
                Meter meters = (Meter)5.0;  // 5 meters
                Centimeter centimeters = (Centimeter)25.0;  // 25 centimeters

                Meter m = meters + (Meter)centimeters;
                Assert.AreEqual((Meter)5.25, m);

                Centimeter cm = (Centimeter)meters + centimeters;
                Assert.AreEqual((Centimeter)525.0, cm);

                m = meters - (Meter)centimeters;
                Assert.AreEqual((Meter)4.75, m);

                cm = (Centimeter)meters - centimeters; ;
                Assert.AreEqual((Centimeter)475.0, cm);
            }

            [TestMethod]
            public void IncrementDecrement()
            {
                Meter meters = (Meter)5.0;
                Meter post = meters++;
                Assert.IsTrue(meters == (Meter)6.0);
                Meter pre = --meters;
                Assert.IsTrue((post == pre) && (pre == meters) && (meters == (Meter)5.0));
            }
        }

        [TestClass]
        public class MultiplicativeOperators
        {
            [TestMethod]
            public void MultiplyDivide()
            {
                MPH speed = (MPH)100.0; // 100 mph
                Minute duration = (Minute)30.0;     // 30 minutes

                Mile miles = speed * (Hour)duration;
                Assert.AreEqual((Mile)50.0, miles);
                Assert.AreEqual("50 mil", miles.ToString(CultureInfo.InvariantCulture));

                Kilometer kilometers = (Kilometer)miles;
                Assert.AreEqual((Kilometer)80.467199999999991, kilometers);
                Assert.AreEqual("80.4672 km", kilometers.ToString(CultureInfo.InvariantCulture));

                speed = miles / (Hour)duration;
                Assert.AreEqual((MPH)100.0, speed);
                Assert.AreEqual("100 mph", speed.ToString(CultureInfo.InvariantCulture));
                Assert.AreEqual("160.9344 km/h", ((Kilometer_Hour)speed).ToString(CultureInfo.InvariantCulture));
                Assert.AreEqual("44.704 m/s", ((Meter_Sec)speed).ToString(CultureInfo.InvariantCulture));
            }

            [TestMethod]
            public void MultiplyDivideByNumber()
            {
                Meter meters = (Meter)5.0;  // 5 meters

                meters *= 2.0;  // 10 meters
                Assert.AreEqual((Meter)10.0, meters);

                meters /= 5.0;  // 2 meters
                Assert.AreEqual((Meter)2.0, meters);
            }
        }

        [TestClass]
        public class UnitProxies
        {
            [TestMethod]
            [ExpectedException(typeof(System.ArgumentException))]
            public void UnitConstructorThrowsExceptionOnIncompatibleArgument()
            {
                // Unit<T> constructor requires: 1) value type argument 2) implementing IQuantity<T>, otherwise it throws exception.
                var test = new Unit<double>(typeof(EUR));   // EUR implements IQuantity<decimal> (incompatible with Unit<double>)
            }
        }
    }
}
