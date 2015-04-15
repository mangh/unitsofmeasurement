/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo.UnitsOfMeasurement;

namespace UnitsOfMeasurement.Test
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void DuplicateSymbolThrowsException()
        {
            var catalog = new UnitCatalog<double>();
            catalog.Add(typeof(Meter)); // OK
            catalog.Add(typeof(Meter)); // exception
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void DuplicateSymbolThrowsException2()
        {
            // Load all the units from Newton assembly. This will load Meter family too:
            var catalog = UnitCatalog<double>.LoadFromAssembly(typeof(Newton).Assembly);

            // Loading Meter family again throws ArgumentException: An item with the same symbol(s) has already been added.
            catalog.AppendFromAssembly(typeof(Meter).Assembly, Meter.Family);
            // ... but this would work after first making:
            //catalog.Clear();
        }

        [TestMethod]
        public void Parsing()
        {
            var units = UnitCatalog<double>.LoadFromAssembly(typeof(Meter).Assembly, Meter.Family);
            var currencies = UnitCatalog<decimal>.LoadFromAssembly(typeof(EUR).Assembly, EUR.Family);

            IQuantity<decimal> amount;

            bool done = currencies.TryParse("100 EUR", CultureInfo.InvariantCulture, out amount);
            Assert.IsTrue(done, "Parsing '100 EUR' failed");
            Assert.IsTrue(amount is EUR, "Parsing '100 EUR' did not return EUR type");
            Assert.AreEqual((EUR)100.0m, (EUR)amount, "Parsing '100 EUR' did not return '100 EUR'");
            Assert.AreEqual((USD)((USD.Factor / EUR.Factor) * 100m), USD.From(amount), "Converting '100 EUR' into USD failed");

            Assert.AreEqual(((IFormattable)amount).ToString("{1} {0}", CultureInfo.InvariantCulture), "EUR 100", "((IFormattable)amount).ToString failed");

            IQuantity<double> quantity;

            done = units.TryParse("100 in", new CultureInfo("en-US"), out quantity);
            Assert.IsTrue(done, "Parsing '100 in' failed");
            Assert.IsTrue(quantity is Inch, "Parsing '100 in' did not return Inch type");
            Assert.AreEqual((Inch)100.0, (Inch)quantity, "Parsing '100 in' did not return '100 in'");
            Assert.AreEqual((Meter)2.54, Meter.From(quantity), "Converting '100 in' into Meter failed");

            Assert.AreEqual(((IFormattable)quantity).ToString("{1} {0}", CultureInfo.InvariantCulture), "in 100", "((IFormattable)quantity).ToString failed");

            var scales = ScaleCatalog<double>.LoadFromAssembly(typeof(Kelvin).Assembly, Kelvin.Family);

            ILevel<double> level;

            done = scales.TryParse("100 °C", CultureInfo.InvariantCulture, out level);
            Assert.IsTrue(done, "Parsing '100 °C' level failed");
            Assert.IsTrue(level is Celsius, "Parsing '100 °C' did not return Celsius type");
            Assert.AreEqual((Celsius)100.0, (Celsius)level, "Parsing '100 °C' did not return '100 °C' level");
            Assert.AreEqual((Fahrenheit)212.0, Fahrenheit.From(level), "Converting '100 °C' level into Fahrenheit failed");

            Assert.AreEqual(((IFormattable)level).ToString("{1} {0}", CultureInfo.InvariantCulture), "°C 100", "((IFormattable)level).ToString failed");

            // You can also get the last result via 'quantities' and 'units' (instead of 'levels' and 'scales')
            units.AppendFromAssembly(typeof(DegKelvin).Assembly, DegKelvin.Family);

            done = units.TryParse("100 °C", CultureInfo.InvariantCulture, out quantity);
            Assert.IsTrue(done, "Parsing '100 °C' quantity failed");
            Assert.IsTrue(quantity is DegCelsius, "Parsing '100 °C' did not return DegCelsius type");
            Assert.AreEqual((DegCelsius)100.0, (DegCelsius)quantity, "Parsing '100 °C' did not return '100 °C' quantity");
            Assert.AreEqual((Celsius)100.0, (Celsius)quantity.Value, "Creating Celsius level from parsed '100 °C' failed");
            Assert.AreEqual((Fahrenheit)212.0, (Fahrenheit)(Celsius)quantity.Value, "Converting '100 °C' quantity into Fahrenheit failed");
        }
    }
}
