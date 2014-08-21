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

            UnitCatalog catalog = new UnitCatalog();
            catalog.LoadFromAssembly(typeof(EUR).Assembly.Location);

            UpdateCurrencyRates(catalog, @"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
        }

        private static void UpdateCurrencyRates(UnitCatalog catalog, string url)
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
                            UnitProxy currencyUnit = catalog[attrCurrency.Value];
                            if ((currencyUnit != null) && decimal.TryParse(attrRate.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out rate))
                            {
                                object oldrate = currencyUnit.Factor;
                                currencyUnit.Factor = rate;
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
