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

        static int benchmarkSamples = 32;
        static Benchmark add = new Benchmark(benchmarkSamples);  // benchmark for addition
        static Benchmark sub = new Benchmark(benchmarkSamples);  // benchmark for subtraction
        static Benchmark mul = new Benchmark(benchmarkSamples);  // benchmark for product (multiplication)
        static Benchmark div = new Benchmark(benchmarkSamples);  // benchmark for quotient (division)
        static Benchmark cvt = new Benchmark(benchmarkSamples);  // benchmark for conversion
        static Benchmark mix = new Benchmark(benchmarkSamples);  // benchmark for mix of all the above operations

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Console.WriteLine("\n Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).\n");
            Console.WriteLine(" addition                  subtraction               product                   quotient                  conversion                mix of all operations");
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
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / fast);
                add.Add(slow, fast);

                fast = PlainLoop(loopcount, x, y, PlainSubtraction);
                slow = UnitLoop(loopcount, p, q, UnitSubtraction);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / fast);
                sub.Add(slow, fast);

                fast = PlainLoop(loopcount, x, y, PlainProduct);
                slow = UnitLoop(loopcount, p, q, UnitProduct);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / fast);
                mul.Add(slow, fast);

                fast = PlainLoop(loopcount, x, y, PlainQuotient);
                slow = UnitLoop(loopcount, p, q, UnitQuotient);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / fast);
                div.Add(slow, fast);

                fast = PlainLoop(loopcount, x, PlainConversion);
                slow = UnitLoop(loopcount, p, UnitConversion);
                Console.Write("{0,6} /{1,6} = {2:F4}   ", slow, fast, (double)slow / fast);
                cvt.Add(slow, fast);

                fast = PlainLoop(loopcount, x, y, PlainAllOperations);
                slow = UnitLoop(loopcount, p, q, UnitsAllOperations);
                Console.WriteLine("{0,6} /{1,6} = {2:F4}", slow, fast, (double)slow / fast);
                if(mix.Add(slow, fast))
                {
                    Console.WriteLine();
                    Console.WriteLine(" Average slowdown:");
                    Console.WriteLine(" addition:                 subtraction:              product:                  quotient:                 conversion:               mix:");
                    Console.WriteLine(" {0,22}    {1,22}    {2,22}    {3,22}    {4,22}    {5,22}",
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", add.Mean, add.StdDev, 100.0 * add.StdDev / add.Mean),
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", sub.Mean, sub.StdDev, 100.0 * sub.StdDev / sub.Mean),
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", mul.Mean, mul.StdDev, 100.0 * mul.StdDev / mul.Mean),
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", div.Mean, div.StdDev, 100.0 * div.StdDev / div.Mean),
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", cvt.Mean, cvt.StdDev, 100.0 * cvt.StdDev / cvt.Mean),
                        string.Format("{0:F2} -+{1:F2} (-+{2:F0}%)", mix.Mean, mix.StdDev, 100.0 * mix.StdDev / mix.Mean)
                    );
                    Console.WriteLine("{0,153}", "==================");
                    Console.WriteLine();
                }
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
/* Sample output under VS2010, Release config, Platform target: AnyCPU, Prefer 32 bit, Optimize code:

Units of Measurement for C# applications. Copyright (c) Marek Anioła.
This program is provided to you under the terms of the license
as published at https://github.com/mangh/unitsofmeasurement.

 Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).

 addition                  subtraction               product                   quotient                  conversion                mix of all operations
 units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio
 -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------
 10603 / 10235 = 1,0360    11059 / 11012 = 1,0043    10639 / 11011 = 0,9662    11312 / 11017 = 1,0268    13887 / 11058 = 1,2558    62155 / 44562 = 1,3948
 12965 / 12740 = 1,0177    12940 / 12758 = 1,0143    12886 / 12697 = 1,0149    10938 / 13386 = 0,8171    13553 / 10939 = 1,2390    62559 / 44941 = 1,3920
 13054 / 12756 = 1,0234    12941 / 12838 = 1,0080    12970 / 12758 = 1,0166    11523 / 13755 = 0,8377    13747 / 10939 = 1,2567    60758 / 44975 = 1,3509
 12820 / 12697 = 1,0097    12896 / 12776 = 1,0094    12978 / 12717 = 1,0205    13673 / 13673 = 1,0000    13617 / 11011 = 1,2367    60995 / 44694 = 1,3647
 12969 / 12697 = 1,0214    12939 / 12890 = 1,0038    12600 / 12697 = 0,9924    10939 / 10938 = 1,0001    14939 / 10939 = 1,3657    59918 / 44839 = 1,3363
 12925 / 12753 = 1,0135    13164 / 12759 = 1,0317    12882 / 12749 = 1,0104    10938 / 12901 = 0,8478    13283 / 11029 = 1,2044    60869 / 44560 = 1,3660
 12965 / 12697 = 1,0211    12938 / 12743 = 1,0153    10305 / 11169 = 0,9226    10938 / 10938 = 1,0000    13283 / 11246 = 1,1811    61695 / 44659 = 1,3815
 12696 / 12740 = 0,9965    12993 / 12778 = 1,0168    12902 / 12697 = 1,0161    10939 / 12991 = 0,8420    13396 / 10939 = 1,2246    62222 / 44038 = 1,4129
 12964 / 12715 = 1,0196    12996 / 12769 = 1,0178    12942 / 12724 = 1,0171    11048 / 10939 = 1,0100    13571 / 10939 = 1,2406    60862 / 44107 = 1,3799
 12897 / 12717 = 1,0142    13035 / 12753 = 1,0221    12881 / 12696 = 1,0146    13673 / 13767 = 0,9932    18216 / 13673 = 1,3323    61421 / 46994 = 1,3070
 12976 / 12697 = 1,0220    12964 / 12768 = 1,0154    12383 / 12700 = 0,9750    11390 / 11389 = 1,0001    13283 / 10938 = 1,2144    61945 / 45433 = 1,3634
 12700 / 12747 = 0,9963    12811 / 12734 = 1,0060    10404 / 10703 = 0,9721    11036 / 10939 = 1,0089    13282 / 11027 = 1,2045    61165 / 44251 = 1,3822
 12696 / 12697 = 0,9999    13017 / 12773 = 1,0191    12940 / 12696 = 1,0192    13672 / 13699 = 0,9980    14812 / 13702 = 1,0810    61177 / 44418 = 1,3773
 12942 / 12697 = 1,0193    12968 / 12807 = 1,0126    11897 / 12696 = 0,9371    11047 / 10939 = 1,0099    13528 / 10939 = 1,2367    60542 / 44278 = 1,3673
 12965 / 12697 = 1,0211    13002 / 12754 = 1,0194    12903 / 12697 = 1,0162    13673 / 13773 = 0,9927    15219 / 13674 = 1,1130    59054 / 44388 = 1,3304
 13017 / 12725 = 1,0229    12940 / 13462 = 0,9612    10322 / 10342 = 0,9981    11479 / 12070 = 0,9510    13283 / 10939 = 1,2143    63236 / 44580 = 1,4185
 12757 / 12697 = 1,0047    12751 / 12776 = 0,9980    10419 / 12543 = 0,8307    10938 / 11618 = 0,9415    13659 / 11052 = 1,2359    61468 / 45079 = 1,3636
 12965 / 12721 = 1,0192    12986 / 12749 = 1,0186    10276 / 10446 = 0,9837    11264 / 10939 = 1,0297    13283 / 10939 = 1,2143    61448 / 44704 = 1,3746
 12938 / 12757 = 1,0142    12977 / 12738 = 1,0188    12882 / 12718 = 1,0129    10939 / 12939 = 0,8454    13667 / 11413 = 1,1975    61297 / 44468 = 1,3785
 12922 / 12735 = 1,0147    12897 / 12746 = 1,0118    12878 / 12752 = 1,0099    12164 / 13673 = 0,8896    13282 / 11134 = 1,1929    60481 / 44719 = 1,3525
 12964 / 14586 = 0,8888    12963 / 12778 = 1,0145    12901 / 12697 = 1,0161    10938 / 12435 = 0,8796    13407 / 10939 = 1,2256    58803 / 44277 = 1,3281
 12897 / 12716 = 1,0142    12963 / 12764 = 1,0156    12883 / 12697 = 1,0146    11046 / 10977 = 1,0063    13556 / 10939 = 1,2392    60783 / 44463 = 1,3670
 12999 / 12697 = 1,0238    12942 / 12745 = 1,0155    11455 / 12697 = 0,9022    10939 / 11178 = 0,9786    13596 / 10978 = 1,2385    71982 / 45203 = 1,5924
 13031 / 12697 = 1,0263    12982 / 12738 = 1,0192    12882 / 12833 = 1,0038    12618 / 13822 = 0,9129    13283 / 10938 = 1,2144    62677 / 44849 = 1,3975
 12942 / 12733 = 1,0164    12969 / 12735 = 1,0184    12844 / 12737 = 1,0084    13768 / 13824 = 0,9959    16194 / 13673 = 1,1844    60900 / 44926 = 1,3556
 12950 / 12741 = 1,0164    12975 / 12782 = 1,0151    12934 / 12891 = 1,0033    14019 / 13753 = 1,0193    14136 / 11638 = 1,2146    65275 / 46697 = 1,3978
 12965 / 12716 = 1,0196    12996 / 12848 = 1,0115    12837 / 12697 = 1,0110    13727 / 13673 = 1,0039    13282 / 12319 = 1,0782    60799 / 44596 = 1,3633
 12929 / 12698 = 1,0182    13027 / 12751 = 1,0216    12779 / 12763 = 1,0013    12980 / 13673 = 0,9493    13283 / 11144 = 1,1919    61166 / 44186 = 1,3843
 12862 / 12698 = 1,0129    12940 / 12783 = 1,0123    12859 / 12738 = 1,0095    13672 / 13674 = 0,9999    13625 / 12708 = 1,0722    61406 / 44024 = 1,3948
 12986 / 12697 = 1,0228    12896 / 12766 = 1,0102    12902 / 12736 = 1,0130    10938 / 11496 = 0,9515    13949 / 11217 = 1,2436    61905 / 45499 = 1,3606
 12965 / 12697 = 1,0211    12896 / 12794 = 1,0080    11484 / 12696 = 0,9045    10938 / 11182 = 0,9782    13505 / 10939 = 1,2346    61361 / 44970 = 1,3645
 12898 / 12696 = 1,0159    12940 / 12698 = 1,0191    12841 / 13357 = 0,9614    12923 / 13672 = 0,9452    13282 / 11597 = 1,1453    61037 / 44559 = 1,3698

 Average slowdown:
 addition:                 subtraction:              product:                  quotient:                 conversion:               mix:
     1,01 -+0,02 (-+2%)        1,01 -+0,01 (-+1%)        0,99 -+0,04 (-+4%)        0,96 -+0,06 (-+7%)        1,21 -+0,06 (-+5%)        1,38 -+0,05 (-+3%)
                                                                                                                                       ==================
Press any key to continue . . .
*/

/* Sample output under VS2015, Release config, Platform target: AnyCPU, Prefer 32 bit, Optimize code:

 Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).

 addition                  subtraction               product                   quotient                  conversion                mix of all operations
 units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio
 -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------
  9626 /  9322 = 1,0326    11670 /  9287 = 1,2566     9945 /  8944 = 1,1119    11483 / 11022 = 1,0418    12605 / 11060 = 1,1397    66903 / 44374 = 1,5077
 11768 / 10917 = 1,0780    11719 / 11019 = 1,0635    10741 / 11003 = 0,9762    11353 / 11883 = 0,9554    11382 / 11050 = 1,0300    65893 / 44124 = 1,4934
 11823 / 10917 = 1,0830    11783 / 11017 = 1,0695    11883 / 11046 = 1,0758    10938 / 13628 = 0,8026    11278 / 11667 = 0,9667    65322 / 44673 = 1,4622
  9647 /  9088 = 1,0615     9648 / 11603 = 0,8315     9605 /  8904 = 1,0787    10938 / 11230 = 0,9740    11124 / 10939 = 1,0169    65515 / 44834 = 1,4613
  9522 /  8731 = 1,0906     9635 /  9425 = 1,0223     9517 /  8805 = 1,0809    10938 / 11233 = 0,9737    10938 / 10939 = 0,9999    64646 / 44932 = 1,4388
  9376 /  8733 = 1,0736     9749 /  9258 = 1,0530     9521 /  8803 = 1,0816    11045 / 11307 = 0,9768    10939 / 10939 = 1,0000    65865 / 44064 = 1,4948
  9376 /  8728 = 1,0742     9623 /  9349 = 1,0293     9521 /  8974 = 1,0610    10938 / 11302 = 0,9678    10939 / 11026 = 0,9921    65346 / 44041 = 1,4838
  9479 /  8731 = 1,0857     9632 /  9495 = 1,0144     9514 /  8804 = 1,0806    11382 / 11617 = 0,9798    11007 / 10939 = 1,0062    65086 / 43937 = 1,4813
  9375 /  8738 = 1,0729     9721 /  9332 = 1,0417     9520 /  8805 = 1,0812    11045 / 11336 = 0,9743    10938 / 10939 = 0,9999    67839 / 44488 = 1,5249
  9832 /  8732 = 1,1260     9657 /  9184 = 1,0515     9521 /  8885 = 1,0716    10938 / 11033 = 0,9914    10939 / 11025 = 0,9922    64100 / 44251 = 1,4486
  9480 /  8819 = 1,0750     9609 /  9536 = 1,0077     9715 /  8803 = 1,1036    10939 / 11096 = 0,9859    11041 / 10938 = 1,0094    64708 / 44202 = 1,4639
  9376 /  8732 = 1,0738     9700 /  9400 = 1,0319     9517 /  8805 = 1,0809    10967 / 11339 = 0,9672    10939 / 10938 = 1,0001    64710 / 44879 = 1,4419
 13274 /  8732 = 1,5202    11320 / 10069 = 1,1242     9848 /  9640 = 1,0216    11064 / 10938 = 1,0115    11386 / 10939 = 1,0409    65509 / 44690 = 1,4659
  9846 /  9007 = 1,0931     9467 /  8730 = 1,0844     9609 /  8974 = 1,0708    10938 / 10938 = 1,0000    11491 / 11024 = 1,0424    65399 / 44040 = 1,4850
  9866 /  8732 = 1,1299     9376 /  9084 = 1,0321    11547 /  8805 = 1,3114    10939 / 11068 = 0,9883    11759 / 10939 = 1,0750    64434 / 44669 = 1,4425
  9851 /  8734 = 1,1279     9376 /  8962 = 1,0462     9609 /  8805 = 1,0913    11037 / 10938 = 1,0091    11338 / 10938 = 1,0366    67103 / 44988 = 1,4916
  9376 /  8970 = 1,0453     9499 /  8736 = 1,0873    13962 /  8825 = 1,5821    11071 / 11168 = 0,9913    10938 / 11258 = 0,9716    65051 / 44685 = 1,4558
  9865 /  9436 = 1,0455     9375 /  8729 = 1,0740     9507 /  9417 = 1,0096    10938 / 10938 = 1,0000    11086 / 11187 = 0,9910    64600 / 44614 = 1,4480
  9577 /  9017 = 1,0621     9467 /  8734 = 1,0839     9520 /  9011 = 1,0565    10938 / 11032 = 0,9915    11261 / 11429 = 0,9853    64528 / 44052 = 1,4648
  9608 /  9242 = 1,0396     9564 /  8732 = 1,0953     9520 /  9149 = 1,0406    11040 / 10938 = 1,0093    11102 / 11246 = 0,9872    65785 / 44756 = 1,4699
  9525 /  9245 = 1,0303     9376 /  8737 = 1,0731     9998 /  9281 = 1,0773    10939 / 10938 = 1,0001    11394 / 11421 = 0,9976    64286 / 44153 = 1,4560
  9573 /  9099 = 1,0521     9466 /  8733 = 1,0839     9936 /  8987 = 1,1056    10939 / 10975 = 0,9967    10939 / 11252 = 0,9722    65038 / 44701 = 1,4550
  9376 /  8948 = 1,0478     9467 /  8873 = 1,0669     9507 /  9277 = 1,0248    11047 / 10938 = 1,0100    10939 / 11104 = 0,9851    64888 / 44827 = 1,4475
  9375 /  9069 = 1,0337     9565 /  8726 = 1,0961     9517 /  9231 = 1,0310    10938 / 10938 = 1,0000    11768 / 11563 = 1,0177    65084 / 44722 = 1,4553
  9862 /  9510 = 1,0370     9376 /  8731 = 1,0739     9616 /  8901 = 1,0803    10938 / 10938 = 1,0000    11518 / 11403 = 1,0101    64396 / 44110 = 1,4599
  9376 /  8942 = 1,0485     9450 /  8890 = 1,0630     9521 /  9026 = 1,0548    10983 / 10985 = 0,9998    11519 / 11309 = 1,0186    64887 / 44057 = 1,4728
  9376 /  8937 = 1,0491     9425 /  8730 = 1,0796     9517 /  9277 = 1,0259    10938 / 10939 = 0,9999    10938 / 11194 = 0,9771    70327 / 44011 = 1,5979
  9969 /  9866 = 1,0104     9467 /  9236 = 1,0250     9779 /  9433 = 1,0367    10939 / 10938 = 1,0001    11170 / 11627 = 0,9607    64454 / 44042 = 1,4635
  9504 /  8727 = 1,0890     9376 /  8731 = 1,0739     9779 /  9644 = 1,0140    10938 / 11119 = 0,9837    10939 / 11120 = 0,9837    65350 / 44379 = 1,4725
 17786 / 12191 = 1,4589    10018 / 10558 = 0,9489     9507 /  8804 = 1,0799    11807 / 11299 = 1,0450    10938 / 10990 = 0,9953    64840 / 44823 = 1,4466
  9376 /  8732 = 1,0738     9578 /  9094 = 1,0532     9517 /  8805 = 1,0809    11526 / 10938 = 1,0538    10939 / 10939 = 1,0000    65181 / 44040 = 1,4800
  9448 /  9239 = 1,0226     9484 /  9044 = 1,0487     9517 /  8871 = 1,0728    10939 / 11150 = 0,9811    10939 / 11081 = 0,9872    64665 / 44070 = 1,4673

 Average slowdown:
 addition:                 subtraction:              product:                  quotient:                 conversion:               mix:
    1,09 -+0,11 (-+10%)        1,06 -+0,06 (-+6%)       1,09 -+0,10 (-+10%)        0,99 -+0,04 (-+4%)        1,01 -+0,03 (-+3%)        1,47 -+0,03 (-+2%)
                                                                                                                                       ==================
Press any key to continue . . . 
*/

