/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.UnitsOfMeasurement;

namespace RuntimeUnits
{
    class Program
    {
        private static CultureInfo ci = CultureInfo.InvariantCulture;

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Assembly supplementary = LoadSupplementaryUnits("LateUnits.txt");
            if (supplementary == null)
                return; // syntax errors

            TestSupplementaryUnits(supplementary);

            TestSupplementaryScales(supplementary);
        }

        static Assembly LoadSupplementaryUnits(string filename)
        {
            string filepath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), filename);
            string[] references = { typeof(Meter).Assembly.Location };
            RuntimeLoader ldr = new RuntimeLoader();
            Assembly supplement = ldr.LoadFromFile(filepath, references);
            if (supplement == null)
            {
                Console.WriteLine("\nInvalid definitions:");
                foreach (var e in ldr.Errors) Console.WriteLine(e);
            }
            return supplement;
        }

        static void TestSupplementaryUnits(Assembly supplementary)
        {
            var units = UnitCatalog<double>.LoadFromAssembly(typeof(Meter).Assembly);
            Print("\nMeter family (before loading supplementary units):", units.Items(Meter.Family));

            units.AppendFromAssembly(supplementary);
            Print("\nMeter family (afer loading supplementary units):", units.Items(Meter.Family));

            Console.WriteLine("\nConversions from/to supplementary length units:");

            IQuantity<double> length;
            if (!units.TryParse("1 nmi", out length))
                Console.WriteLine("\tFAILED (from)!");
            else
            {
                IQuantity<double> cables = units["cb"].ConvertQuantity(length);
                IQuantity<double> fathoms = units["ftm"].ConvertQuantity(length);
                Kilometer kilometers = Kilometer.From(length);

                Console.WriteLine(" {0} = {1} = {2} = {3}",
                    (length as IFormattable).ToString("{0} {1}", ci),
                    (cables as IFormattable).ToString("{0} {1}", ci),
                    (fathoms as IFormattable).ToString("{0} {1}", ci),
                    kilometers.ToString(ci)
                );
            }

            if (!units.TryParse("1 km", out length))
                Console.WriteLine("\tFAILED (to)!");
            else
            {
                Kilometer kilometers = (Kilometer)length;
                IQuantity<double> nmiles = units["nmi"].ConvertQuantity(length);
                IQuantity<double> cables = units["cb"].ConvertQuantity(length);
                IQuantity<double> fathoms = units["ftm"].ConvertQuantity(length);

                Console.WriteLine(" {0} = {1} = {2} = {3}",
                    (nmiles as IFormattable).ToString("{0} {1}", ci),
                    (cables as IFormattable).ToString("{0} {1}", ci),
                    (fathoms as IFormattable).ToString("{0} {1}", ci),
                    kilometers.ToString(ci)
                );
            }
        }

        static void TestSupplementaryScales(Assembly supplementary)
        {
            var scales = ScaleCatalog<double>.LoadFromAssembly(typeof(Kelvin).Assembly);
            Print("\nKelvin family (before loading supplementary units):", scales.Items(Kelvin.Family));

            scales.AppendFromAssembly(supplementary);
            Print("\nKelvin family (after loading supplementary units):", scales.Items(Kelvin.Family));

            Console.WriteLine("\nConversions from/to supplementary temperature units:");

            ILevel<double> temperature;
            if (!scales.TryParse("-80 deg.Re", out temperature))
                Console.WriteLine("\tFAILED (from)!");
            else
            {
                Celsius celsius = Celsius.From(temperature);
                Kelvin kelvins = Kelvin.From(temperature);
                Rankine rankines = Rankine.From(temperature);
                Fahrenheit fahrenheits = Fahrenheit.From(temperature);

                Console.WriteLine(
                    " {0} = {1} = {2} = {3} = {4}",
                    (temperature as IFormattable).ToString("{0} {1}", ci),
                    kelvins.ToString(ci),
                    celsius.ToString(ci),
                    rankines.ToString(ci),
                    fahrenheits.ToString(ci)
                );
            }

            if (!scales.TryParse("100 deg.C", out temperature))
                Console.WriteLine("\tFAILED (to)!");
            else
            {
                Celsius celsius = (Celsius)temperature;
                ILevel<double> reamures = scales["deg.Re"].ConvertLevel(temperature);
                Kelvin kelvins = (Kelvin)celsius;
                Rankine rankines = (Rankine)celsius;
                Fahrenheit fahrenheits = (Fahrenheit)celsius;

                Console.WriteLine(
                    "  {0} = {1} =  {2} = {3} =  {4}",
                    (reamures as IFormattable).ToString("{0} {1}", ci),
                    kelvins.ToString(ci),
                    celsius.ToString(ci),
                    rankines.ToString(ci),
                    fahrenheits.ToString(ci)
                );
            }
        }

        private static void Print(string header, IEnumerable<Measure> measures)
        {
            Console.WriteLine(header);
            int i = 1;
            foreach (var measure in measures)
            {
                Console.WriteLine("{0,2}. {1} {{\"{2}\"}}", i++, measure.Type.Name, String.Join("\", \"", measure.Symbol));
            }
        }
    }
}
/* Sample output:

Meter family (before loading supplementary units):
 1. Foot {"ft"}
 2. Inch {"in"}
 3. Millimeter {"mm"}
 4. Mile {"mil"}
 5. Centimeter {"cm"}
 6. Kilometer {"km"}
 7. Meter {"m"}
 8. Yard {"yd"}

Meter family (afer loading supplementary units):
 1. Foot {"ft"}
 2. Inch {"in"}
 3. Millimeter {"mm"}
 4. Mile {"mil"}
 5. Centimeter {"cm"}
 6. Kilometer {"km"}
 7. Meter {"m"}
 8. Yard {"yd"}
 9. Fathom {"ftm"}
10. Cable {"cb"}
11. NauticalMile {"nmi"}

Conversions from/to supplementary length units:
 1 nmi = 10 cb = 1012.68591426072 ftm = 1.852 km
 0.539956803455724 nmi = 5.39956803455724 cb = 546.806649168854 ftm = 1 km

Kelvin family (before loading supplementary units):
 1. Fahrenheit {"°F", "deg.F"}
 2. Rankine {"°R", "deg.R"}
 3. Celsius {"°C", "deg.C"}
 4. Kelvin {"K", "deg.K"}

Kelvin family (after loading supplementary units):
 1. Fahrenheit {"°F", "deg.F"}
 2. Rankine {"°R", "deg.R"}
 3. Celsius {"°C", "deg.C"}
 4. Kelvin {"K", "deg.K"}
 5. Reaumur {"°Ré", "°Re", "deg.Re"}

Conversions from/to supplementary temperature units:
 -80 °Ré = 173.15 K = -100 °C = 311.67 °R = -148 °F
  80 °Ré = 373.15 K =  100 °C = 671.67 °R =  212 °F
 
 */