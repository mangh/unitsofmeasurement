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
        [ExpectedException(typeof(System.NullReferenceException), "No exception on fake proxy")]
        public void FakeProxiesThrowsException()
        {
            // You can create fake unit proxy i.e. proxy constructed from non-unit type...
            UnitProxy fakeProxy = new UnitProxy(typeof(double));

            // ...but NullReferenceException("Object reference not set to an instance of an object") 
            // is thrown when you try to get any unit properties (Sense, Family, Factor, Format, Symbol) e.g.:
            object factor;
            bool gotException = false;
            try { factor = fakeProxy.Factor; }
            catch (System.NullReferenceException) { gotException = true; }
            Assert.IsTrue(gotException, "No exception on fake proxy");   

            // ...and the same happens when adding fake proxy to a catalog:
            UnitCatalog catalog = new UnitCatalog();
            catalog.Add(fakeProxy);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException),"Parsing succeeded on bad target quantity")]
        public void ParsingBadTargetQuantityThrowsException()
        {
            UnitCatalog catalog = new UnitCatalog();
            catalog.AppendFromAssembly(typeof(Meter).Assembly.Location, Meter.Family);

            string input = "100 m";
            CultureInfo ci = CultureInfo.InvariantCulture;

            // Parsing needs right target quantity...
            IQuantity<double> goodTargetQuantity;
            bool done = catalog.TryParse(input, ci, out goodTargetQuantity);
            Assert.IsTrue(done, "Parsing failed on good target quantity");
            Assert.AreEqual((Meter)100.0, (Meter)goodTargetQuantity, "Parsing got wrong result");

            // ...otherwise it throws NullReferenceException("Object reference not set to an instance of an object") 
            IQuantity<decimal> badTargetQuantity;
            catalog.TryParse(input, ci, out badTargetQuantity);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void LoadingDuplicateUnitsThrowsException()
        {
            UnitCatalog catalog = new UnitCatalog();

            // Load all the units from Newton assembly. This will load Meter family too:
            catalog.LoadFromAssembly(typeof(Newton).Assembly.Location);

            // Loading Meter family again throws ArgumentException: An item with the same key has already been added.
            catalog.AppendFromAssembly(typeof(Meter).Assembly.Location, Meter.Family);
            // ... but this would work after first making:
            //catalog.Clear();
        }

        [TestMethod]
        public void Parsing()
        {
            UnitCatalog catalog = new UnitCatalog(32);

            // Load only the unit families that you need:
            catalog.AppendFromAssembly(typeof(Meter).Assembly.Location, Meter.Family);
            catalog.AppendFromAssembly(typeof(EUR).Assembly.Location, EUR.Family);
            catalog.AppendFromAssembly(typeof(DegKelvin).Assembly.Location, DegKelvin.Family);

            bool done;
            IQuantity<decimal> amount;

            done = catalog.TryParse("100 EUR", CultureInfo.InvariantCulture, out amount);
            Assert.IsTrue(done, "Parsing '100 EUR' failed");
            Assert.IsTrue(amount is EUR, "Parsing '100 EUR' did not return EUR type");
            Assert.AreEqual((EUR)100.0m, (EUR)amount, "Parsing '100 EUR' did not return '100 EUR'");
            Assert.AreEqual((USD)((USD.Factor/EUR.Factor)*100m), USD.From(amount), "Converting parsed '100 EUR' into USD failed");

            IQuantity<double> quantity;

            done = catalog.TryParse("100 in", new CultureInfo("en-US"), out quantity);
            Assert.IsTrue(done, "Parsing '100 in' failed");
            Assert.IsTrue(quantity is Inch, "Parsing '100 in' did not return Inch type");
            Assert.AreEqual((Inch)100.0, (Inch)quantity, "Parsing '100 in' did not return '100 in'");
            Assert.AreEqual((Meter)2.54, Meter.From(quantity), "Converting parsed '100 in' into Meter failed");

            done = catalog.TryParse("100 °C", CultureInfo.InvariantCulture, out quantity);
            Assert.IsTrue(done, "Parsing '100 °C' failed");
            Assert.IsTrue(quantity is DegCelsius, "Parsing '100 °C' did not return DegCelsius type");
            Assert.AreEqual((DegCelsius)100.0, (DegCelsius)quantity, "Parsing '100 °C' did not return '100 °C'");
            Assert.AreEqual((Celsius)100.0, (Celsius)(DegCelsius)quantity, "Creating Celsius level from parsed '100 °C' failed");
        }
    }
}
