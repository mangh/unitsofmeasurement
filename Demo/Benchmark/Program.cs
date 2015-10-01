/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


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
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Console.WriteLine("\n Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).\n");
            Console.WriteLine(" addition                  subtraction               product                   quotient                  conversion                all");
            Console.WriteLine(" units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio");
            Console.WriteLine(" -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------");

            int loopcount = 1000000;
            double x = 2.0;
            double y = 1.0;
            Foot p = (Foot)x;
            Foot q = (Foot)y;

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
                long fast = PlainLoop(loopcount, x, y, PlainAddition);
                long slow = UnitLoop(loopcount, p, q, UnitAddition);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = PlainLoop(loopcount, x, y, PlainSubtraction);
                slow = UnitLoop(loopcount, p, q, UnitSubtraction);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = PlainLoop(loopcount, x, y, PlainProduct);
                slow = UnitLoop(loopcount, p, q, UnitProduct);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = PlainLoop(loopcount, x, y, PlainQuotient);
                slow = UnitLoop(loopcount, p, q, UnitQuotient);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = PlainLoop(loopcount, x, PlainConversion);
                slow = UnitLoop(loopcount, p, UnitConversion);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / (double)fast);

                fast = PlainLoop(loopcount, x, y, PlainAllOperations);
                slow = UnitLoop(loopcount, p, q, UnitsAllOperations);
                Console.Write("{0,6} /{1,6} = {2:F4}\n", slow, fast, (double)slow / (double)fast);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }

        static Func<double, double, double> PlainAddition = (x, y) => x + y;
        static Func<double, double, double> PlainSubtraction = (x, y) => x - y;
        static Func<double, double, double> PlainProduct = (x, y) => x * y;
        static Func<double, double, double> PlainQuotient = (x, y) => x / y;
        static Func<double, double> PlainConversion = x => (Yard.Factor / Foot.Factor) * x;
        static Func<double, double, double> PlainAllOperations = (x, y) =>
        {
            double sum = x + y;
            double diff = x - y;
            double product = x * y;
            double quotient = x / y;
            double yards = (Yard.Factor / Foot.Factor) * sum;
            return product / (sum + diff) * quotient + (Foot.Factor / Yard.Factor) * yards;
        };

        static Func<Foot, Foot, Foot> UnitAddition = (x, y) => x + y;
        static Func<Foot, Foot, Foot> UnitSubtraction = (x, y) => x - y;
        static Func<Foot, Foot, SquareFoot> UnitProduct = (x, y) => x * y;
        static Func<Foot, Foot, double> UnitQuotient = (x, y) => x / y;
        static Func<Foot, Yard> UnitConversion = x => (Yard)x;
        static Func<Foot, Foot, Foot> UnitsAllOperations = (p, q) =>
        {
            Foot sum = p + q;
            Foot diff = p - q;
            SquareFoot product = p * q;
            double quotient = p / q;
            Yard yards = (Yard)sum;
            return product / (sum + diff) * quotient + (Foot)yards;
        };

        static double result;
        static long PlainLoop(int loopcount, double x, double y, Func<double, double, double> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                result = func(x++, y++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }
        static Foot footresult;
        static long UnitLoop(int loopcount, Foot x, Foot y, Func<Foot, Foot, Foot> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                footresult = func(x++, y++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static SquareFoot squarefootresult;
        static long UnitLoop(int loopcount, Foot x, Foot y, Func<Foot, Foot, SquareFoot> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                squarefootresult = func(x++, y++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long UnitLoop(int loopcount, Foot x, Foot y, Func<Foot, Foot, double> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                result = func(x++, y++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }

        static long PlainLoop(int loopcount, double x, Func<double, double> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                result = func(x++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }
        static Yard yardresult;
        static long UnitLoop(int loopcount, Foot x, Func<Foot, Yard> func)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            sw.Restart();

            for(int i = 0; i < loopcount; i++)
            {
                yardresult = func(x++);
            }

            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
/* Sample output:

 Units of Measurement for C# applications. Copyright (c) Marek Anioła.
 This program is provided to you under the terms of the license
 as published at http://unitsofmeasurement.codeplex.com/license.

 Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).

 addition                  subtraction               product                   quotient                  conversion                all
 units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio
 -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------
  9914 /  9049 = 1,0956    10517 /  9678 = 1,0867    14532 /  9503 = 1,5292    11481 / 13298 = 0,8634    14125 / 11699 = 1,2074    75585 / 45304 = 1,6684
  9730 /  9690 = 1,0041     9684 /  8894 = 1,0888     9905 /  9361 = 1,0581    11473 / 11518 = 0,9961    12004 / 11236 = 1,0684    74980 / 45544 = 1,6463
 45512 / 29016 = 1,5685    19945 / 22424 = 0,8894    11984 / 13410 = 0,8937    12059 / 11830 = 1,0194    15508 / 11975 = 1,2950    74095 / 45608 = 1,6246
 28575 / 30428 = 0,9391    24543 / 37757 = 0,6500    16399 / 14047 = 1,1674    12307 / 13059 = 0,9424    12058 / 11590 = 1,0404    75242 / 45819 = 1,6422
 19569 / 18140 = 1,0788    16443 / 18972 = 0,8667    17664 / 10420 = 1,6952    12073 / 14060 = 0,8587    12456 / 11618 = 1,0721    74047 / 46519 = 1,5918
 26097 / 25755 = 1,0133    22126 / 20873 = 1,0600     9852 / 21266 = 0,4633    11186 / 11157 = 1,0026    12775 / 11777 = 1,0847    74483 / 45728 = 1,6288
 27564 / 26088 = 1,0566    19213 / 26289 = 0,7308    10773 /  9260 = 1,1634    11262 / 11592 = 0,9715    13040 / 11559 = 1,1281    74182 / 45799 = 1,6197
 10556 / 14235 = 0,7416    10053 /  9311 = 1,0797    11787 /  9372 = 1,2577    11159 / 11613 = 0,9609    12788 / 11535 = 1,1086    74352 / 45783 = 1,6240
 30015 / 25822 = 1,1624    25548 / 29059 = 0,8792    16052 / 14197 = 1,1307    14964 / 12572 = 1,1903    12877 / 11202 = 1,1495    73900 / 45534 = 1,6230
 27545 / 25622 = 1,0751    16532 / 15329 = 1,0785    16757 / 15591 = 1,0748    11530 / 17192 = 0,6707    12049 / 11554 = 1,0428    73457 / 45334 = 1,6204
  9829 /  9214 = 1,0667    10369 /  9224 = 1,1241    10058 / 10069 = 0,9989    11556 / 11443 = 1,0099    11956 / 11178 = 1,0696    76502 / 46017 = 1,6625
 27640 / 25583 = 1,0804    23991 / 25663 = 0,9348    10096 /  9197 = 1,0977    11162 / 11155 = 1,0006    12184 / 11156 = 1,0921    73481 / 45227 = 1,6247
 24376 / 25653 = 0,9502    19563 / 18089 = 1,0815    17766 / 18195 = 0,9764    11115 / 11531 = 0,9639    12104 / 11499 = 1,0526    73346 / 45713 = 1,6045
 10010 /  9277 = 1,0790    10033 /  9286 = 1,0804    10123 /  9383 = 1,0789    11624 / 11645 = 0,9982    12449 / 11616 = 1,0717    73474 / 47328 = 1,5524
 27995 / 25577 = 1,0945    13236 / 18355 = 0,7211    13366 / 12361 = 1,0813    15447 / 15356 = 1,0059    11954 / 11831 = 1,0104    73429 / 44752 = 1,6408
 27598 / 25686 = 1,0744    25642 / 25695 = 0,9979    10311 /  9227 = 1,1175    11166 / 11156 = 1,0009    12136 / 11488 = 1,0564    73531 / 45391 = 1,6199
 27630 / 25625 = 1,0782    13210 / 18624 = 0,7093    13365 / 12403 = 1,0776    15431 / 15357 = 1,0048    11958 / 12279 = 0,9739    73702 / 45216 = 1,6300
 11629 / 11794 = 0,9860    10045 /  9323 = 1,0774    10167 /  9378 = 1,0841    11644 / 11622 = 1,0019    12467 / 11619 = 1,0730    74040 / 48635 = 1,5224
 27575 / 25599 = 1,0772    14988 / 14795 = 1,0130    15266 / 14051 = 1,0865    12879 / 17456 = 0,7378    12441 / 11566 = 1,0757    73255 / 45074 = 1,6252
 27596 / 25844 = 1,0678    12785 / 29194 = 0,4379     9881 /  9382 = 1,0532    11157 / 11165 = 0,9993    11975 / 11300 = 1,0597    73459 / 44935 = 1,6348
 27692 / 25574 = 1,0828    27666 / 25611 = 1,0802     9903 / 16985 = 0,5830    11277 / 11535 = 0,9776    12472 / 11578 = 1,0772    74281 / 45368 = 1,6373
 13658 / 14614 = 0,9346     9968 /  9310 = 1,0707     9843 /  9321 = 1,0560    11432 / 11158 = 1,0246    12075 / 11502 = 1,0498    73593 / 45465 = 1,6187
 27673 / 25616 = 1,0803    15113 / 25668 = 0,5888     9930 /  9195 = 1,0799    11165 / 11698 = 0,9544    12088 / 11161 = 1,0831    73536 / 45388 = 1,6202
 27628 / 25627 = 1,0781    27682 / 25672 = 1,0783     9698 / 17142 = 0,5657    11261 / 11005 = 1,0233    12038 / 11500 = 1,0468    73638 / 45237 = 1,6278
 13162 / 12309 = 1,0693    13235 / 12276 = 1,0781    13009 / 12357 = 1,0528    11228 / 11660 = 0,9630    12000 / 11540 = 1,0399    73555 / 45242 = 1,6258
 27724 / 25570 = 1,0842    27542 / 25704 = 1,0715     9748 / 13808 = 0,7060    11182 / 11162 = 1,0018    12281 / 11534 = 1,0648    73546 / 45218 = 1,6265
 27611 / 25663 = 1,0759    22457 / 25697 = 0,8739     9932 /  9272 = 1,0712    11222 / 11601 = 0,9673    12310 / 11377 = 1,0820    73624 / 44624 = 1,6499
 27950 / 25653 = 1,0895    18696 / 25708 = 0,7272    11716 /  9354 = 1,2525    15350 / 11724 = 1,3093    12522 / 13256 = 0,9446    77584 / 46712 = 1,6609
 23999 / 25636 = 0,9361    22752 / 20494 = 1,1102     9998 / 20682 = 0,4834    11710 / 12031 = 0,9733    12075 / 11482 = 1,0516    73924 / 45330 = 1,6308
 29230 / 25647 = 1,1397    21646 / 25644 = 0,8441     9740 /  8925 = 1,0913    11377 / 12142 = 0,9370    12220 / 11476 = 1,0648    76030 / 45391 = 1,6750
 36252 / 25633 = 1,4143    34739 / 27412 = 1,2673    20509 / 13459 = 1,5238    11958 / 14372 = 0,8320    12479 / 11479 = 1,0871    75370 / 45994 = 1,6387
 27617 / 25667 = 1,0760    12184 / 19016 = 0,6407    12393 / 11476 = 1,0799    14328 / 14810 = 0,9675    12460 / 13254 = 0,9401    73781 / 45244 = 1,6307
 27791 / 25637 = 1,0840    19235 / 25771 = 0,7464     9795 /  9380 = 1,0442    11356 / 11932 = 0,9517    12376 / 11456 = 1,0803    73584 / 45710 = 1,6098
 34258 / 36460 = 0,9396    15331 / 30199 = 0,5077    11372 /  9568 = 1,1885    11164 / 11584 = 0,9637    12505 / 11477 = 1,0896    74043 / 45710 = 1,6198
 27709 / 25648 = 1,0804     9740 / 24766 = 0,3933    10126 /  9196 = 1,1011    11159 / 11172 = 0,9988    11961 / 11486 = 1,0414    73372 / 45170 = 1,6244
 31781 / 25631 = 1,2399    15463 / 25826 = 0,5987    12603 / 14183 = 0,8886    13015 / 16470 = 0,7902    12720 / 11641 = 1,0927    73881 / 46545 = 1,5873
 27869 / 26742 = 1,0421     9648 / 24123 = 0,4000    10581 /  9181 = 1,1525    11159 / 11738 = 0,9507    12827 / 11492 = 1,1162    73884 / 45488 = 1,6243
 Press any key to continue . . .
*/
