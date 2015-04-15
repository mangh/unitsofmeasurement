/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;
using Demo.UnitsOfMeasurement;

namespace Currencies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at http://unitsofmeasurement.codeplex.com/license."
            );

            Console.WriteLine("\nUpdating exchange rates in currency units (demo application).\n");

            var catalog = UnitCatalog<decimal>.LoadFromAssembly(typeof(EUR).Assembly);

            UpdateCurrencyRates(catalog, @"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
        }

        private static void UpdateCurrencyRates(UnitCatalog<decimal> catalog, string url)
        {
            Console.WriteLine("Connecting to {0} ...", url);

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            using (XmlReader reader = XmlReader.Create(url, settings))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.LocalName == "Cube"))
                    {
                        List<XmlAttributeData> attributes = GetAttributes(reader);
                        XmlAttributeData attrCurrency = attributes.Find(a => a.Name == "currency");
                        XmlAttributeData attrRate = attributes.Find(a => a.Name == "rate");
                        if ((attrCurrency != null) && (attrRate != null))
                        {
                            decimal rate;
                            Unit<decimal> currency = catalog[attrCurrency.Value];
                            if ((currency != null) && decimal.TryParse(attrRate.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out rate))
                            {
                                decimal oldrate = currency.Factor;
                                currency.Factor = rate;
                                Console.WriteLine("{0} rate = {1} (previously {2})", attrCurrency.Value, rate, oldrate);
                            }
                        }
                    }
                }
            }
        }

        private static List<XmlAttributeData> GetAttributes(XmlReader reader)
        {
            List<XmlAttributeData> attributes = new List<XmlAttributeData>();
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    attributes.Add(new XmlAttributeData(reader.LocalName, reader.Value));
                }
                reader.MoveToElement();
            }
            return attributes;
        }

        private class XmlAttributeData
        {
            public string Name { get; private set; }
            public string Value { get; private set; }
            public XmlAttributeData(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
/*
 Sample output:

 Updating exchange rates in currency units (demo application).

 Connecting to http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml ...
 USD rate = 1,3267 (previously 1,3433)
 GBP rate = 0,80030 (previously 0,79055)
 PLN rate = 4,1863 (previously 4,1437)

 */