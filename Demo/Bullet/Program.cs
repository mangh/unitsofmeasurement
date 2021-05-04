/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

#if DIMENSIONAL_ANALYSIS
    using Demo.UnitsOfMeasurement;
    using static Demo.UnitsOfMeasurement.Math;
#else
    using Meter = System.Double;
    using Second = System.Double;
    using Degree = System.Double;
    using Meter_Sec = System.Double;
#endif

namespace Bullet
{
    class Program
    {
#if DIMENSIONAL_ANALYSIS
        static readonly string dimensional_analysis_status = "dimensional analysis: ON";
#else
        static readonly string dimensional_analysis_status = "dimensional analysis: OFF";
#endif
        // Bullet slope: range and step values
        static readonly double min = 0.0;
        static readonly double max = 90.0;
        static readonly double step = 0.1;

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Console.WriteLine("\nRange of a bullet (demo)");

            // Customize unit formats
            CustomizeFormats();

            // Plain and measured (with units) bullet samplers
            var plain = new Plain.Sampler(height: 0.0, velocity: 715.0);
            var fancy = new Measured.Sampler(height: (Meter)0.0, velocity: (Meter_Sec)715.0);

            // Fancy/plain performance ratio
            var ratio = new Benchmark();

            // Process and thread properties set as described in CodeProject article by Thomas Maierhofer
            // "Performance Tests: Precise Run Time Measurements with System.Diagnostics.Stopwatch"
            // http://www.codeproject.com/Articles/61964/Performance-Tests-Precise-Run-Time-Measurements-wi
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.ProcessorAffinity = new IntPtr(2);   // Use only the 2nd core
            currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // A warmup of 1000 - 1500 mS. Stabilizes the CPU cache and pipeline
            WarmUp(plain, fancy);

            do
            {
                // calculate bullet ranges while measure the time spent for the calculations
                List<(double, double, double, double)> p = plain.Sample(min, max, step);
                List<(Degree, Second, Meter, Meter)> f = fancy.Sample((Degree)min, (Degree)max, (Degree)step);

                // update performance ratio
                ratio.Add(fancy.timer.elapsed / plain.timer.elapsed);

                PrintResults(f, p);

                Console.WriteLine();
                Console.WriteLine(
$"{fancy.benchmark.Count}. quantity/plain performance ratio: {fancy.timer.elapsed:F0} / {plain.timer.elapsed:F0} = {fancy.timer.elapsed / plain.timer.elapsed:F2} ({dimensional_analysis_status})");
                Console.WriteLine("Press Esc to conclude, any other key to retry...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.WriteLine();
            Console.WriteLine("Average performance ratio for {0} run(s): {1:F0}±{2:F0}({3:F0}%) / {4:F0}±{5:F0}({6:F0}%) = {7:F2}±{8:F2}({9:F0}%).",
                fancy.benchmark.Count,
                fancy.benchmark.Average, fancy.benchmark.StdDev, fancy.benchmark.StdDevPercentage,
                plain.benchmark.Average, plain.benchmark.StdDev, plain.benchmark.StdDevPercentage,
                ratio.Average, ratio.StdDev, ratio.StdDevPercentage
            );
        }

        static void WarmUp(Plain.Sampler plain, Measured.Sampler measured)
        {
            // Warmp up
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            while (sw.ElapsedMilliseconds < 1000)
            {
                plain.Sample(min, max, step);
                measured.Sample((Degree)min, (Degree)max, (Degree)step);
            }
            sw.Stop();

            // Clear statistics
            plain.benchmark.Reset();
            measured.benchmark.Reset();
        }

        static void CustomizeFormats()
        {
            Demo.UnitsOfMeasurement.Meter.Format = "{0,5:F0} {1}";      // quantity value {0}, width 5, format "F0" followed by blank and unit symbol {1}
            Demo.UnitsOfMeasurement.Second.Format = "{0,3:F0} {1}";     // quantity value {0}, width 3, format "F0" followed by blank and unit symbol {1}
            Demo.UnitsOfMeasurement.Degree.Format = "{0,5:F2}{1}";      // quantity value {0}, width 5, format "F2" followed by unit symbol {1} (no blank between value and symbol)
        }

        static void PrintResults(List<(Degree, Second, Meter, Meter)> f, List<(double, double, double, double)> p)
        {
            Console.WriteLine();
            Console.WriteLine(" angle |  tmax |  xmax   |  ymax  ");
            Console.WriteLine($"  ({Demo.UnitsOfMeasurement.Degree.Symbol.Default})  |  ({Demo.UnitsOfMeasurement.Second.Symbol.Default})  |  ({Demo.UnitsOfMeasurement.Meter.Symbol.Default})    |  ({Demo.UnitsOfMeasurement.Meter.Symbol.Default})");
            Console.WriteLine(" ------+-------+---------+---------");

            for (int i = 0; i < f.Count; i++)
            {
                (Degree slope, Second tmax, Meter xmax, Meter ymax) = f[i];

                // Fancy and plain results are to be the same. Is this the case?
#if DIMENSIONAL_ANALYSIS
                Console.WriteLine($"{slope} | {tmax} | {xmax} | {ymax}");

                double slopeErr = slope.Value - p[i].Item1;
                double tmaxErr = tmax.Value - p[i].Item2;
                double xmaxErr = xmax.Value - p[i].Item3;
                double ymaxErr = ymax.Value - p[i].Item4;
#else
                Console.WriteLine($"{Demo.UnitsOfMeasurement.Degree.String(slope)} | {Demo.UnitsOfMeasurement.Second.String(tmax)} | {Demo.UnitsOfMeasurement.Meter.String(xmax)} | {Demo.UnitsOfMeasurement.Meter.String(ymax)}");

                double slopeErr = slope - p[i].Item1;
                double tmaxErr = tmax - p[i].Item2;
                double xmaxErr = xmax - p[i].Item3;
                double ymaxErr = ymax - p[i].Item4;
#endif
                if ((slopeErr != 0.0) || (tmaxErr != 0.0) || (xmaxErr != 0.0) || (ymaxErr != 0.0))
                {
                    Console.WriteLine($"{Demo.UnitsOfMeasurement.Degree.String(slopeErr)} | {Demo.UnitsOfMeasurement.Second.String(tmaxErr)} | {Demo.UnitsOfMeasurement.Meter.String(xmaxErr)} | {Demo.UnitsOfMeasurement.Meter.String(ymaxErr)}");
                }
            }
        }
    }
}
/* Sample output (dimensional analysis: OFF):
 * 
 * Units of Measurement for C# applications. Copyright (c) Marek Aniola.
 * This program is provided to you under the terms of the license
 * as published at https://github.com/mangh/unitsofmeasurement.
 * 
 * Range of a bullet (demo)
 * 
 *  angle |  tmax |  xmax   |  ymax
 *   (°)  |  (s)  |  (m)    |  (m)
 *  ------+-------+---------+---------
 *  0,00° |   0 s |     0 m |     0 m
 *  0,10° |   0 s |   182 m |     0 m
 *  0,20° |   1 s |   364 m |     0 m
 *  0,30° |   1 s |   546 m |     0 m
 *  0,40° |   1 s |   728 m |     0 m
 *  0,50° |   1 s |   910 m |     0 m
 *  0,60° |   2 s |  1092 m |     0 m
 *  0,70° |   2 s |  1274 m |     0 m
 *  0,80° |   2 s |  1456 m |     0 m
 *  0,90° |   2 s |  1637 m |     1 m
 *  1,00° |   3 s |  1819 m |     1 m
 *  1,10° |   3 s |  2001 m |     2 m
 * ...
 * ...
 * ...
 * 89,00° | 146 s |  1819 m |  6513 m
 * 89,10° | 146 s |  1637 m |  6514 m
 * 89,20° | 146 s |  1456 m |  6514 m
 * 89,30° | 146 s |  1274 m |  6514 m
 * 89,40° | 146 s |  1092 m |  6515 m
 * 89,50° | 146 s |   910 m |  6515 m
 * 89,60° | 146 s |   728 m |  6515 m
 * 89,70° | 146 s |   546 m |  6515 m
 * 89,80° | 146 s |   364 m |  6515 m
 * 89,90° | 146 s |   182 m |  6515 m
 * 90,00° | 146 s |     0 m |  6515 m
 * 
 * 32. quantity/plain performance ratio: 4266 / 4360 = 0,98 (dimensional analysis: OFF)
 * Press Esc to conclude, any other key to retry...
 * 
 * Average performance ratio for 32 run(s): 4518±739(16%) / 4559±750(16%) = 0,99±0,04(4%).
 * 
 ********************************************************************************************
 *
 * Sample output (dimensional analysis: ON):
 * 
 *  angle |  tmax |  xmax   |  ymax
 *   (°)  |  (s)  |  (m)    |  (m)
 *  ------+-------+---------+---------
 *  0,00° |   0 s |     0 m |     0 m
 *  0,10° |   0 s |   182 m |     0 m
 *  0,20° |   1 s |   364 m |     0 m
 *  0,30° |   1 s |   546 m |     0 m
 *  0,40° |   1 s |   728 m |     0 m
 *  0,50° |   1 s |   910 m |     0 m
 *  0,60° |   2 s |  1092 m |     0 m
 *  0,70° |   2 s |  1274 m |     0 m
 *  0,80° |   2 s |  1456 m |     0 m
 *  0,90° |   2 s |  1637 m |     1 m
 *  1,00° |   3 s |  1819 m |     1 m
 *  1,10° |   3 s |  2001 m |     2 m
 * ...
 * ...
 * ...
 * 89,00° | 146 s |  1819 m |  6513 m
 * 89,10° | 146 s |  1637 m |  6514 m
 * 89,20° | 146 s |  1456 m |  6514 m
 * 89,30° | 146 s |  1274 m |  6514 m
 * 89,40° | 146 s |  1092 m |  6515 m
 * 89,50° | 146 s |   910 m |  6515 m
 * 89,60° | 146 s |   728 m |  6515 m
 * 89,70° | 146 s |   546 m |  6515 m
 * 89,80° | 146 s |   364 m |  6515 m
 * 89,90° | 146 s |   182 m |  6515 m
 * 90,00° | 146 s |     0 m |  6515 m
 * 
 * 32. quantity/plain performance ratio: 25396 / 4333 = 5,86 (dimensional analysis: ON)
 * Press Esc to conclude, any other key to retry...
 * 
 * Average performance ratio for 32 run(s): 24943±2733(11%) / 4493±752(17%) = 5,63±0,61(11%).
 * 
 *
 */