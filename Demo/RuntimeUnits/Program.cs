/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Demo.UnitsOfMeasurement;

namespace RuntimeUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Console.WriteLine();
            Console.WriteLine("Before loading supplementary units:");
            Console.WriteLine("==================================");

            TestSupplementaryUnits("converting \"{0}\" (runtime unit):", "1 nmi");
            TestSupplementaryScales("converting \"{0}\" (runtime scale):", "-80 deg.Re");
            TestSupplementaryUnits("converting \"{0}\" (compile-time unit):", "1 km");
            TestSupplementaryScales("converting \"{0}\" (compile-time scale):", "100 deg.C");

            RuntimeLoader ldr = new RuntimeLoader();
            if (!ldr.LoadFromFile(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "LateUnits.txt")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid definitions:");
                foreach (var e in ldr.Errors) Console.WriteLine(e);
                Console.ResetColor();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("After loading supplementary units:");
            Console.WriteLine("=================================");

            TestSupplementaryUnits("converting \"{0}\" (runtime unit):", "1 nmi");
            TestSupplementaryScales("converting \"{0}\" (runtime scale):", "-80 deg.Re");
            TestSupplementaryUnits("converting \"{0}\" (compile-time unit):", "1 km");
            TestSupplementaryScales("converting \"{0}\" (compile-time scale):", "100 deg.C");
        }

        static void TestSupplementaryUnits(string headerformat, string input)
        {
            Console.WriteLine();
            Console.WriteLine(headerformat, input);

            var parser = new QuantityParser<double>(Meter.Family);

            IQuantity<double> length;
            if (!parser.TryParse(input, out length))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: invalid number or unit other than any the following: \"{1}\".", input, string.Join("\", \"", parser.Units.SelectMany(m => m.Symbol)));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int i = 0;
                foreach (var unit in parser.Units)
                {
                    string unitinfo = string.Format("{0,2}. {1}", ++i, unit);
                    IQuantity<double> output = unit.From(length);
                    Console.WriteLine("{0,-40}  {1} -> {2}", unitinfo, input, output);
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Test supplementary scales (via QuantityParser).
        /// </summary>
        /// <param name="headerformat">Report header format.</param>
        /// <param name="input">Input level to parse.</param>
        /// <remarks>
        /// QuantityParser (instead of LevelParser) is used here to get levels (via intermediate quantity).
        /// The method below shows that you can confine yourself to QuantityParser alone to get both
        /// temperature quantities as well as temperature levels (without resorting to LevelParser for the latter).
        /// See TestSupplementaryScalesWithLevelParser method below for an alternative way of doing the same via LevelParser.
        /// </remarks>
        static void TestSupplementaryScales(string headerformat, string input)
        {
            Console.WriteLine();
            Console.WriteLine(headerformat, input);

            IEnumerable<Scale<double>> allowedScales = Catalog.Scales<double>(Kelvin.Family);
            var parser = new QuantityParser<double>(allowedUnits: allowedScales.Select(s => s.Unit as Unit<double>));

            IQuantity<double> temperature;
            if (!parser.TryParse(input, out temperature))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: invalid number or unit other than any of the following: {1}.", input, string.Join(", ", parser.Units.Select(u => u.Symbol.ToString())));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int i = 0;
                foreach (var scale in allowedScales)
                {
                    string scaleinfo = string.Format("{0,2}. {1}", ++i, scale);
                    ILevel<double> output = scale.From(temperature);    // promote IQuantity<> to ILevel<> (attach IQuantity to a scale)
                    Console.WriteLine("{0,-40}  {1} -> {2}", scaleinfo, input, output);
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Test supplementary scales (via LevelParser). Alternative for TestSupplementaryScales method above.
        /// </summary>
        /// <param name="headerformat">Report header format.</param>
        /// <param name="input">Input level to parse.</param>
        /// <remarks>
        /// LevelParser is used here to get levels directly (and not via intermediate quantity as in
        /// TestSupplementaryScales above). On the other hand, if you also need to input quantities
        /// (e.g. temperature increase) then you will have to apply QuantityParser in addition (meaning
        /// two methods instead of one).
        /// </remarks>
        static void TestSupplementaryScalesWithLevelParser(string headerformat, string input)
        {
            Console.WriteLine();
            Console.WriteLine(headerformat, input);

            var parser = new LevelParser<double>(Kelvin.Family);

            ILevel<double> temperature;
            if (!parser.TryParse(input, out temperature))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: invalid number or unit other than any of the following: {1}.", input, string.Join(", ", parser.Scales.Select(s => s.Unit.Symbol.ToString())));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int i = 0;
                foreach (var scale in parser.Scales)
                {
                    string scaleinfo = string.Format("{0,2}. {1}", ++i, scale);
                    ILevel<double> output = scale.From(temperature);
                    Console.WriteLine("{0,-40}  {1} -> {2}", scaleinfo, input, output);
                }
            }
            Console.ResetColor();
        }
    }
}
/* Sample output:
Units of Measurement for C# applications. Copyright (c) Marek Anioła.
This program is provided to you under the terms of the license
as published at https://github.com/mangh/unitsofmeasurement.

Before loading supplementary units:
==================================

converting "1 nmi" (runtime unit):
1 nmi: invalid number or unit other than any the following: "m", "cm", "mm", "km", "in", "ft", "yd", "mil".

converting "-80 deg.Re" (runtime scale):
-80 deg.Re: invalid number or unit other than any of the following: {"K", "deg.K"}, {"°C", "deg.C"}, {"°R", "deg.R"}, {"°F", "deg.F"}.

converting "1 km" (compile-time unit):
 1. [L] Meter {"m"}                       1 km -> 1000 m
 2. [L] Centimeter {"cm"}                 1 km -> 100000 cm
 3. [L] Millimeter {"mm"}                 1 km -> 1000000 mm
 4. [L] Kilometer {"km"}                  1 km -> 1 km
 5. [L] Inch {"in"}                       1 km -> 39370,0787401575 in
 6. [L] Foot {"ft"}                       1 km -> 3280,83989501312 ft
 7. [L] Yard {"yd"}                       1 km -> 1093,61329833771 yd
 8. [L] Mile {"mil"}                      1 km -> 0,621371192237334 mil

converting "100 deg.C" (compile-time scale):
 1. [?] Kelvin {"K", "deg.K"}             100 deg.C -> 373,15 K
 2. [?] Celsius {"°C", "deg.C"}           100 deg.C -> 100 °C
 3. [?] Rankine {"°R", "deg.R"}           100 deg.C -> 671,67 °R
 4. [?] Fahrenheit {"°F", "deg.F"}        100 deg.C -> 212 °F

After loading supplementary units:
=================================

converting "1 nmi" (runtime unit):
 1. [L] Meter {"m"}                       1 nmi -> 1852 m
 2. [L] Centimeter {"cm"}                 1 nmi -> 185200 cm
 3. [L] Millimeter {"mm"}                 1 nmi -> 1852000 mm
 4. [L] Kilometer {"km"}                  1 nmi -> 1,852 km
 5. [L] Inch {"in"}                       1 nmi -> 72913,3858267717 in
 6. [L] Foot {"ft"}                       1 nmi -> 6076,1154855643 ft
 7. [L] Yard {"yd"}                       1 nmi -> 2025,37182852143 yd
 8. [L] Mile {"mil"}                      1 nmi -> 1,15077944802354 mil
 9. [L] Fathom {"ftm"}                    1 nmi -> 1012,68591426072 ftm
10. [L] Cable {"cb"}                      1 nmi -> 10 cb
11. [L] NauticalMile {"nmi"}              1 nmi -> 1 nmi

converting "-80 deg.Re" (runtime scale):
 1. [?] Kelvin {"K", "deg.K"}             -80 deg.Re -> 173,15 K
 2. [?] Celsius {"°C", "deg.C"}           -80 deg.Re -> -100 °C
 3. [?] Rankine {"°R", "deg.R"}           -80 deg.Re -> 311,67 °R
 4. [?] Fahrenheit {"°F", "deg.F"}        -80 deg.Re -> -148 °F
 5. [?] Reaumur {"°Ré", "°Re", "deg.Re"}  -80 deg.Re -> -80 °Ré

converting "1 km" (compile-time unit):
 1. [L] Meter {"m"}                       1 km -> 1000 m
 2. [L] Centimeter {"cm"}                 1 km -> 100000 cm
 3. [L] Millimeter {"mm"}                 1 km -> 1000000 mm
 4. [L] Kilometer {"km"}                  1 km -> 1 km
 5. [L] Inch {"in"}                       1 km -> 39370,0787401575 in
 6. [L] Foot {"ft"}                       1 km -> 3280,83989501312 ft
 7. [L] Yard {"yd"}                       1 km -> 1093,61329833771 yd
 8. [L] Mile {"mil"}                      1 km -> 0,621371192237334 mil
 9. [L] Fathom {"ftm"}                    1 km -> 546,806649168854 ftm
10. [L] Cable {"cb"}                      1 km -> 5,39956803455724 cb
11. [L] NauticalMile {"nmi"}              1 km -> 0,539956803455724 nmi

converting "100 deg.C" (compile-time scale):
 1. [?] Kelvin {"K", "deg.K"}             100 deg.C -> 373,15 K
 2. [?] Celsius {"°C", "deg.C"}           100 deg.C -> 100 °C
 3. [?] Rankine {"°R", "deg.R"}           100 deg.C -> 671,67 °R
 4. [?] Fahrenheit {"°F", "deg.F"}        100 deg.C -> 212 °F
 5. [?] Reaumur {"°Ré", "°Re", "deg.Re"}  100 deg.C -> 80 °Ré

*/