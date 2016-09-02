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
/* Sample output (under VS2010; Release config, Platform target: X86 (EXE) / AnyCPU (DLL)):

Units of Measurement for C# applications. Copyright (c) Marek Anioła.
This program is provided to you under the terms of the license
as published at https://github.com/mangh/unitsofmeasurement.

 Unit versus plain arithmetic benchmark (press Esc to quit, any other key to repeat).

 addition                  subtraction               product                   quotient                  conversion                all
 units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio     units / plain = ratio
 -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------    -----   -----   ------
 10385 / 10263 = 1,0119    10433 / 10415 = 1,0017    10530 / 10232 = 1,0291    11219 / 11305 = 0,9924    12922 / 11052 = 1,1692    62244 / 44681 = 1,3931
 12757 / 15034 = 0,8485    12706 / 12697 = 1,0007    12924 / 12697 = 1,0179    10938 / 11806 = 0,9265    12844 / 11221 = 1,1446    60823 / 44635 = 1,3627
 12697 / 12697 = 1,0000    12697 / 12715 = 0,9986    12774 / 12697 = 1,0061    10938 / 11574 = 0,9450    12794 / 10939 = 1,1696    60315 / 44568 = 1,3533
 12697 / 12767 = 0,9945    12813 / 12696 = 1,0092    12739 / 12715 = 1,0019    13838 / 13781 = 1,0041    14072 / 13673 = 1,0292    60728 / 44637 = 1,3605
 12697 / 12739 = 0,9967    29284 / 12719 = 2,3024    12007 / 12719 = 0,9440    10938 / 10963 = 0,9977    13236 / 11096 = 1,1929    59960 / 44331 = 1,3526
 12733 / 12788 = 0,9957    12470 / 12771 = 0,9764    10297 / 10266 = 1,0030    11090 / 10938 = 1,0139    12534 / 11222 = 1,1169    63749 / 44658 = 1,4275
 10421 / 10774 = 0,9672    10305 / 10157 = 1,0146    10191 / 10804 = 0,9433    11163 / 10939 = 1,0205    12501 / 11005 = 1,1359    59631 / 44068 = 1,3532
 12701 / 12764 = 0,9951    12784 / 12726 = 1,0046    12981 / 12722 = 1,0204    11730 / 13939 = 0,8415    12714 / 10939 = 1,1623    61271 / 44603 = 1,3737
 12726 / 12697 = 1,0023    12733 / 12762 = 0,9977    12779 / 12717 = 1,0049    10938 / 11637 = 0,9399    12508 / 11055 = 1,1314    60489 / 44142 = 1,3703
 12697 / 12697 = 1,0000    12697 / 12794 = 0,9924    12741 / 12696 = 1,0035    13673 / 13861 = 0,9864    13127 / 13673 = 0,9601    59662 / 44400 = 1,3437
 12697 / 12698 = 0,9999    12722 / 12816 = 0,9927    12828 / 12697 = 1,0103    13716 / 13738 = 0,9984    15361 / 13775 = 1,1151    60540 / 44068 = 1,3738
 12697 / 12775 = 0,9939    12697 / 12697 = 1,0000    12776 / 12805 = 0,9977    11448 / 13673 = 0,8373    12883 / 11463 = 1,1239    62892 / 44107 = 1,4259
 24768 / 17562 = 1,4103    16543 / 20353 = 0,8128    12738 / 12697 = 1,0032    11990 / 14058 = 0,8529    12503 / 10940 = 1,1429    59485 / 45134 = 1,3180
 12696 / 12697 = 0,9999    12697 / 12756 = 0,9954    12764 / 12738 = 1,0020    11603 / 10938 = 1,0608    12597 / 11641 = 1,0821    60390 / 44685 = 1,3515
 12696 / 12697 = 0,9999    12758 / 12747 = 1,0009    12824 / 12697 = 1,0100    13673 / 13827 = 0,9889    12869 / 12019 = 1,0707    61276 / 45670 = 1,3417
 12697 / 12697 = 1,0000    12698 / 12800 = 0,9920    12740 / 12696 = 1,0035    13673 / 13964 = 0,9792    13208 / 13800 = 0,9571    60007 / 44319 = 1,3540
 12697 / 12697 = 1,0000    12707 / 12756 = 0,9962    13016 / 12723 = 1,0230    13673 / 13674 = 0,9999    12795 / 12496 = 1,0239    59764 / 44632 = 1,3390
 12704 / 12698 = 1,0005    12767 / 12696 = 1,0056    10191 / 11800 = 0,8636    11311 / 10938 = 1,0341    12502 / 11136 = 1,1227    77560 / 44619 = 1,7383
 12697 / 12745 = 0,9962    12760 / 12697 = 1,0050    12740 / 12696 = 1,0035    11328 / 13826 = 0,8193    12501 / 10939 = 1,1428    57989 / 44624 = 1,2995
 12697 / 12698 = 0,9999    12697 / 12697 = 1,0000    10737 / 12733 = 0,8432    10938 / 10938 = 1,0000    12502 / 11345 = 1,1020    59961 / 44147 = 1,3582
 12697 / 12767 = 0,9945    13109 / 12697 = 1,0324    12739 / 12733 = 1,0005    11281 / 12705 = 0,8879    12502 / 11502 = 1,0869    60808 / 44963 = 1,3524
 12697 / 12698 = 0,9999    12762 / 12750 = 1,0009    12824 / 12697 = 1,0100    13673 / 13873 = 0,9856    12784 / 13421 = 0,9525    58779 / 45083 = 1,3038
 12697 / 12698 = 0,9999    12697 / 12787 = 0,9930    12792 / 12731 = 1,0048    13744 / 13673 = 1,0052    12501 / 13132 = 0,9519    59165 / 44527 = 1,3287
 13218 / 12697 = 1,0410    12698 / 12697 = 1,0001    12766 / 12952 = 0,9856    20592 / 13678 = 1,5055    18160 / 16844 = 1,0781    60861 / 44758 = 1,3598
 12697 / 12697 = 1,0000    12765 / 12761 = 1,0003    12511 / 12697 = 0,9854    11314 / 10938 = 1,0344    12701 / 10939 = 1,1611    60629 / 44097 = 1,3749
 29195 / 12697 = 2,2994    12766 / 12697 = 1,0054    12824 / 12697 = 1,0100    10938 / 11523 = 0,9492    13278 / 11112 = 1,1949    60157 / 44419 = 1,3543
 12697 / 12724 = 0,9979    12311 / 12697 = 0,9696    10411 / 10158 = 1,0249    11034 / 10939 = 1,0087    12919 / 10939 = 1,1810    60545 / 44239 = 1,3686
 12753 / 12697 = 1,0044    12698 / 12697 = 1,0001    12804 / 12738 = 1,0052    13627 / 13673 = 0,9966    12502 / 11248 = 1,1115    60703 / 44624 = 1,3603
 13415 / 12697 = 1,0565    12732 / 12717 = 1,0012    12738 / 12721 = 1,0013    13545 / 13889 = 0,9752    13275 / 10939 = 1,2135    62103 / 46237 = 1,3431
 12821 / 12697 = 1,0098    12730 / 12821 = 0,9929    12738 / 12726 = 1,0009    12130 / 13845 = 0,8761    12742 / 10939 = 1,1648    60534 / 43940 = 1,3777
 12782 / 12725 = 1,0045    12755 / 12697 = 1,0046    12769 / 12728 = 1,0032    13072 / 13673 = 0,9560    12501 / 11193 = 1,1169    60831 / 44167 = 1,3773
 12843 / 12717 = 1,0099    12698 / 12697 = 1,0001    12796 / 12993 = 0,9848    13814 / 13673 = 1,0103    12501 / 11319 = 1,1044    60555 / 45158 = 1,3410
 12696 / 12733 = 0,9971    12789 / 12696 = 1,0073    12739 / 12696 = 1,0034    11396 / 13315 = 0,8559    12501 / 10938 = 1,1429    59946 / 44760 = 1,3393
 12742 / 12698 = 1,0035    12759 / 12697 = 1,0049    12739 / 12930 = 0,9852    13222 / 13752 = 0,9615    12590 / 10939 = 1,1509    60532 / 44044 = 1,3744
 12697 / 12736 = 0,9969    12738 / 12735 = 1,0002    12742 / 12697 = 1,0035    11076 / 12570 = 0,8811    13053 / 10939 = 1,1933    59950 / 44626 = 1,3434
 12709 / 12698 = 1,0009    12696 / 12737 = 0,9968    10585 / 12382 = 0,8549    10939 / 11445 = 0,9558    12873 / 11004 = 1,1698    60533 / 45327 = 1,3355
 12740 / 12697 = 1,0034    12766 / 12697 = 1,0054    12739 / 12718 = 1,0017    13722 / 13846 = 0,9910    12720 / 10939 = 1,1628    60659 / 44571 = 1,3610
 12766 / 12698 = 1,0054    12697 / 12697 = 1,0000    12740 / 12758 = 0,9986    13841 / 13673 = 1,0123    12501 / 10938 = 1,1429    58859 / 44623 = 1,3190
 12697 / 12697 = 1,0000    12697 / 12757 = 0,9953    12765 / 12735 = 1,0024    13741 / 13673 = 1,0050    12502 / 12399 = 1,0083    60115 / 44807 = 1,3416
Press any key to continue . . .
*/