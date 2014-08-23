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
/*
 Sample output:

 Unit vs. plain arithmetic benchmark (press Esc to quit, any other key to repeat).

 addition                  subtraction               product                   quotient                  conversion                all
 units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio
 -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------
 13051 / 12080 = 1,0804    12977 / 12926 = 1,0039    13542 / 12604 = 1,0744    12922 / 12682 = 1,0189    15571 / 11698 = 1,3311    77071 / 46693 = 1,6506
 36691 / 34892 = 1,0516    11869 / 33720 = 0,3520    13192 / 12635 = 1,0441    12945 / 12347 = 1,0484    15299 / 11622 = 1,3164    75287 / 46796 = 1,6088
 28903 / 35189 = 0,8214    20855 / 20596 = 1,0126    15479 / 20797 = 0,7443    12032 / 12504 = 0,9623    15983 / 11632 = 1,3741    75452 / 46582 = 1,6198
 36996 / 34627 = 1,0684    12312 / 30551 = 0,4030    12672 / 12564 = 1,0086    12041 / 12803 = 0,9405    15792 / 11560 = 1,3661    74919 / 46714 = 1,6038
 33956 / 34260 = 0,9911    18895 / 31767 = 0,5948    13326 / 12516 = 1,0647    12455 / 12553 = 0,9922    15859 / 11616 = 1,3653    76214 / 47740 = 1,5964
 36681 / 34351 = 1,0678    12105 / 20187 = 0,5996    12742 / 12442 = 1,0241    12198 / 11953 = 1,0205    15440 / 11672 = 1,3228    75107 / 46368 = 1,6198
 36620 / 34354 = 1,0660    12157 / 31298 = 0,3884    13296 / 12598 = 1,0554    12560 / 12514 = 1,0037    16482 / 11307 = 1,4577    84166 / 48384 = 1,7395
 37029 / 34858 = 1,0623    12545 / 26830 = 0,4676    12862 / 12546 = 1,0252    12750 / 13549 = 0,9410    15485 / 11636 = 1,3308    75273 / 46513 = 1,6183
 36621 / 34359 = 1,0658    12313 / 34372 = 0,3582    12773 / 12422 = 1,0283    12234 / 12377 = 0,9884    15322 / 11467 = 1,3362    75061 / 46250 = 1,6229
 17565 / 16468 = 1,0666    16493 / 16436 = 1,0035    13132 / 16436 = 0,7990    12202 / 12358 = 0,9874    15245 / 11615 = 1,3125    74663 / 46410 = 1,6088
 36678 / 34325 = 1,0686    26386 / 34308 = 0,7691    12794 / 11935 = 1,0720    11994 / 12463 = 0,9624    15404 / 11585 = 1,3297    74766 / 46230 = 1,6173
 13219 / 14136 = 0,9351    12202 / 12366 = 0,9867    13095 / 12259 = 1,0682    11969 / 12338 = 0,9701    15458 / 11470 = 1,3477    75027 / 46358 = 1,6184
 32731 / 34433 = 0,9506    16447 / 16481 = 0,9979    17700 / 16442 = 1,0765    11962 / 14241 = 0,8400    15545 / 11777 = 1,3199    75997 / 46345 = 1,6398
 36666 / 34316 = 1,0685    23336 / 34348 = 0,6794    12721 / 12325 = 1,0321    11968 / 12084 = 0,9904    15145 / 11161 = 1,3570    75304 / 46530 = 1,6184
 17783 / 16489 = 1,0785    16494 / 16446 = 1,0029    12828 / 12652 = 1,0139    12089 / 12479 = 0,9687    15134 / 11137 = 1,3589    75049 / 46260 = 1,6223
 23129 / 23639 = 0,9784    21673 / 21876 = 0,9907    12904 / 11962 = 1,0787    11999 / 11968 = 1,0026    15439 / 11508 = 1,3416    75150 / 46424 = 1,6188
 36608 / 34349 = 1,0658    14682 / 14688 = 0,9996    15801 / 14671 = 1,0770    12972 / 14682 = 0,8835    15194 / 11722 = 1,2962    75260 / 46485 = 1,6190

 */
