/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.UnitsOfMeasurement;

namespace UnitOfMeasureTest
{
    [TestClass]
    public class LevelTests
    {
        [TestClass]
        public class Conversions
        {
            [TestMethod]
            public void TemperatureLevels()
            {
                var celsius = (Celsius)100.0;   // == new Celsius(100.0) == new Celsius((DegCelsius)100.0)
                var fahrenheit = (Fahrenheit)celsius;
                var rankine = (Rankine)fahrenheit;
                var kelvin = (Kelvin)rankine;
                celsius = (Celsius)kelvin;

                Assert.AreEqual((Fahrenheit)212.0, fahrenheit, "Celsius-to-Fahrenheit conversion (double) failed");
                Assert.AreEqual((Rankine)671.67, rankine, "Fahrenheit-to-Rankine conversion (double) failed");
                Assert.AreEqual((Kelvin)373.15, kelvin, "Rankine-to-Kelvin conversion (double) failed");
                Assert.AreEqual((Celsius)100.0, celsius, "Kelvin-to-Celsius conversion (double) failed");
            }

            [TestMethod]
            public void Casting()
            {
                Celsius celsius = new Celsius(100.0);
                Fahrenheit fahrenheit = Fahrenheit.From(celsius);
                Rankine rankine = Rankine.From(fahrenheit);
                Kelvin kelvin = Kelvin.From(rankine);
                celsius = Celsius.From(kelvin);

                Assert.AreEqual((Fahrenheit)212.0, fahrenheit, "Celsius-to-Fahrenheit conversion (double) failed");
                Assert.AreEqual((Rankine)671.67, rankine, "Fahrenheit-to-Rankine conversion (double) failed");
                Assert.AreEqual((Kelvin)373.15, kelvin, "Rankine-to-Kelvin conversion (double) failed");
                Assert.AreEqual((Celsius)100.0, celsius, "Kelvin-to-Celsius conversion (double) failed");
            }
        }

        [TestClass]
        public class ComaprisonOperators
        {
            [TestMethod]
            public void FloatingPointMangle()
            {
                var expected = (Fahrenheit)123.45;
                var calculated = (Fahrenheit)(Kelvin)(Rankine)(Celsius)expected;
                // unfortunately, due to whimsical floating-point accuracy...:
                Assert.AreNotEqual(expected, calculated);
                // but...:
                Assert.AreEqual((Fahrenheit)123.45000000000005, calculated);
            }

            [TestMethod]
            public void CompareConvertedValues()
            {
                {
                    // 100 C == 671.67 R
                    Rankine rankine = (Rankine)671.67;
                    Celsius celsius = (Celsius)100.0;
                    Assert.IsTrue((rankine == (Rankine)celsius) && ((Celsius)rankine == celsius));
                }
                {
                    // 100 C > 100 R
                    Rankine rankine = (Rankine)100.0;
                    Celsius celsius = (Celsius)100.0;
                    Assert.IsTrue((rankine < (Rankine)celsius) && (celsius >= (Celsius)rankine));
                }
            }

            [TestMethod]
            public void EqGtGeLtLe()
            {
                Celsius celsius = (Celsius)100.0;
                Assert.IsTrue(celsius == (Celsius)(Kelvin)(100.0 + 273.15));
                Assert.IsTrue(celsius.Equals((Celsius)(Kelvin)(100.0 + 273.15)));
                Assert.IsTrue((Kelvin)celsius > (Kelvin)100.0);
                Assert.IsTrue((Kelvin)celsius >= (Kelvin)100.0);
                Assert.IsTrue((Kelvin)100.0 < (Kelvin)celsius);
                Assert.IsTrue((Kelvin)100.0 <= (Kelvin)celsius);
            }
        }


        [TestClass]
        public class AdditiveOperators
        {
            [TestMethod]
            public void AdditionSubtraction()
            {
                {
                    DegKelvin kelvins = (DegKelvin)5.0;

                    Assert.IsTrue((Celsius)100.0 + (DegCelsius)kelvins == (Celsius)105.0);
                    Assert.IsTrue((Celsius)105.0 - (DegCelsius)kelvins == (Celsius)100.0);
                    Assert.IsTrue((Celsius)105.0 - (Celsius)100.0 == (DegCelsius)kelvins);

                    DegRankine rankines = (DegRankine)9.0;

                    Assert.IsTrue((Celsius)100.0 + (DegCelsius)rankines == (Celsius)105.0);
                    Assert.IsTrue((DegCelsius)rankines + (Celsius)100.0 == (Celsius)(Fahrenheit)221.0);
                    Assert.IsTrue((Celsius)100.0 + (DegCelsius)rankines == (DegCelsius)rankines + (Celsius)100.0);
                    Assert.IsTrue((Celsius)105.0 - (DegCelsius)rankines == (Celsius)100.0);
                    Assert.IsTrue((Celsius)105.0 - (Celsius)100.0 == (DegCelsius)rankines);
                }
            }

            [TestMethod]
            public void IncrementDecrement()
            {
                var temperature = (Fahrenheit)5.0;
                var post = temperature++;
                Assert.IsTrue(temperature == (Fahrenheit)6.0);
                var pre = --temperature;
                Assert.IsTrue((post == pre) && (pre == temperature) && (temperature == (Fahrenheit)5.0));
            }
        }
    }
}
