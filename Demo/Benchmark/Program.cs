/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Diagnostics;
using System.Threading;
using Demo.UnitsOfMeasurement;

namespace Benchmark
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at http://unitsofmeasurement.codeplex.com/license."
            );

            Console.WriteLine("\n Unit vs. plain arithmetic benchmark (press Esc to quit, any other key to repeat).\n");

            Console.WriteLine(" addition                  subtraction               product                   quotient                  conversion                all");
            Console.WriteLine(" units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio");
            Console.WriteLine(" -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------");

            int loopcount = 1000000;
            double x = 2.0;
            double y = 1.0;

            // Process and thread properties set as described in CodeProject article by Thomas Maierhofer
            // "Performance Tests: Precise Run Time Measurements with System.Diagnostics.Stopwatch"
            // http://www.codeproject.com/Articles/61964/Performance-Tests-Precise-Run-Time-Measurements-wi
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.ProcessorAffinity = new IntPtr(2);   // Use only the 2nd core
            currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // A Warmup of 1000-1500 mS. Stabilizes the CPU cache and pipeline
            sw.Restart();
            while (sw.ElapsedMilliseconds < 1200) PlainAllOperations(x, y);
            sw.Stop();

            do
            {
                long fast = StandardLoop(loopcount, x, y, PlainAddition, null);
                long slow = StandardLoop(loopcount, x, y, null, UnitAddition);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = StandardLoop(loopcount, x, y, PlainSubtraction, null);
                slow = StandardLoop(loopcount, x, y, null, UnitSubtraction);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = ProductLoop(loopcount, x, y, PlainProduct, null);
                slow = ProductLoop(loopcount, x, y, null, UnitProduct);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = QuotientLoop(loopcount, x, y, PlainQuotient, null);
                slow = QuotientLoop(loopcount, x, y, null, UnitQuotient);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = ConversionLoop(loopcount, x, PlainConversion, null);
                slow = ConversionLoop(loopcount, x, null, UnitConversion);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = StandardLoop(loopcount, x, y, PlainAllOperations, null);
                slow = StandardLoop(loopcount, x, y, null, UnitsAllOperations);
                Console.Write("{0,6} /{1,6} = {2:F4}\n", slow, fast, (double)slow / (double)fast);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static double PlainAddition(double x, double y) { return x + y; }
        static double PlainSubtraction(double x, double y) { return x - y; }
        static double PlainProduct(double x, double y) { return x * y; }
        static double PlainQuotient(double x, double y) { return x / y; }
        static double PlainConversion(double x) { return (Yard.Factor / Foot.Factor) * x; }
        static double PlainAllOperations(double x, double y)
        {
            double sum = x + y;
            double diff = x - y;
            double product = x * y;
            double quotient = x / y;
            double yards = (Yard.Factor / Foot.Factor) * sum;
            return product / (sum + diff) * quotient + (Foot.Factor / Yard.Factor) * yards;
        }

        static Foot UnitAddition(Foot x, Foot y) { return x + y; }
        static Foot UnitSubtraction(Foot x, Foot y) { return x - y; }
        static SquareFoot UnitProduct(Foot x, Foot y) { return x * y; }
        static double UnitQuotient(Foot x, Foot y) { return x / y; }
        static Yard UnitConversion(Foot x) { return (Yard)x; }
        static Foot UnitsAllOperations(Foot p, Foot q)
        {
            Foot sum = p + q;
            Foot diff = p - q;
            SquareFoot product = p * q;
            double quotient = p / q;
            Yard yards = (Yard)sum;
            return product / (sum + diff) * quotient + (Foot)yards;
        }

        static double dummyresult;

        static long StandardLoop(int loopcount, double x, double y, Func<double, double, double> plainFunc, Func<Foot, Foot, Foot> unitFunc)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            double plain = 0.0;
            Foot foots = (Foot)plain;
            Foot p = (Foot)x;
            Foot q = (Foot)y;
            for (int i = 0; i < loopcount; i++)
            {
                if (plainFunc != null)
                    plain = plainFunc(x++, y++);
                else
                    foots = unitFunc(p++, q++);
            }
            dummyresult = (plainFunc != null) ? plain : foots.Value;

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long ProductLoop(int loopcount, double x, double y, Func<double, double, double> plainFunc, Func<Foot, Foot, SquareFoot> unitFunc)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            double plain = 0.0;
            SquareFoot foots = (SquareFoot)plain;
            Foot p = (Foot)x;
            Foot q = (Foot)y;
            for (int i = 0; i < loopcount; i++)
            {
                if (plainFunc != null)
                    plain = plainFunc(x++, y++);
                else
                    foots = unitFunc(p++, q++);
            }
            dummyresult = (plainFunc != null) ? plain : foots.Value;

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long QuotientLoop(int loopcount, double x, double y, Func<double, double, double> plainFunc, Func<Foot, Foot, double> unitFunc)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            double plain = 0.0;
            double foots = plain;
            Foot p = (Foot)x;
            Foot q = (Foot)y;
            for (int i = 0; i < loopcount; i++)
            {
                if (plainFunc != null)
                    plain = plainFunc(x++, y++);
                else
                    foots = unitFunc(p++, q++);
            }
            dummyresult = (plainFunc != null) ? plain : foots;

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long ConversionLoop(int loopcount, double x, Func<double, double> plainFunc, Func<Foot, Yard> unitFunc)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            double plain = 0.0;
            Yard yards = (Yard)plain;
            Foot p = (Foot)x;
            for (int i = 0; i < loopcount; i++)
            {
                if (plainFunc != null)
                    plain = plainFunc(x++);
                else
                    yards = unitFunc(p++);
            }
            dummyresult = (plainFunc != null) ? plain : yards.Value;

            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
