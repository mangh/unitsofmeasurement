/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;
using System.Diagnostics;
using Demo.UnitsOfMeasurement;

namespace ProjectileRange
{
    partial class Program
    {
        private static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Units of Measurement for C# applications. Copyright (©) Marek Anioła.\n" +
                "This program is provided to you under the terms of the license\n" +
                "as published at https://github.com/mangh/unitsofmeasurement."
            );

            Console.WriteLine("\nRange of a projectile (demo application)");

            Meter.Format = "{0,5:F0} {1}";
            Second.Format = "{0,3:F0} {1}";
            Degree.Format = "{0,5:F0}{1}";

            do
            {
                Console.WriteLine(
                    "\n angle |  tmax |  xmax   |  ymax   |   Q   |   P   |  Q/P" +
                    "\n  ({0})  |  ({1})  |  ({2})    |  ({3})    | ticks | ticks | ratio" +
                    "\n ------+-------+---------+---------+-------+-------+------",
                    Degree.Symbol.Default, Second.Symbol.Default, Meter.Symbol.Default, Meter.Symbol.Default 
                );

                double performanceRatio = 0.0;
                for (double angle = 0.0; angle < 90.0; angle++)
                {
                    long slow = GetCalculationsTime((Degree)angle);	// with units
                    long fast = GetCalculationsTime(angle);	// without units (plain)

                    Console.WriteLine("{0,6:F1}", (double)slow / (double)fast);

                    performanceRatio += (double)slow / (double)fast;
                }

                Console.WriteLine("\nAverage performance ratio Q/P (quantities/plain) = {0:F1}.", performanceRatio / 90.0);
                Console.WriteLine("\nPress Esc to quit, any other key to retry...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static long GetCalculationsTime(Degree angle)
        {
            sw.Restart();

            CalculateProjectileRange(angle, out Second tmax, out Meter xmax, out Meter ymax);

            sw.Stop();
            long ticks = sw.ElapsedTicks;

            Console.WriteLine("{0} | {1} | {2} | {3} | {4,5} |       |", angle, tmax, xmax, ymax, ticks);

            return ticks;
        }

        static long GetCalculationsTime(double angle)
        {
            sw.Restart();

            CalculateProjectileRange(angle, out double tmax, out double xmax, out double ymax);

            sw.Stop();
            long ticks = sw.ElapsedTicks;

            Console.Write("{0,5:F0}\u00B0 | {1,3:F0} s | {2,5:F0} m | {3,5:F0} m |       | {4,5} |", angle, tmax, xmax, ymax, ticks);

            return ticks;
        }
    }
}

/*
 * Sample output (release build, prefer 32-bit: false):
 *  
 * Units of Measurement for C# applications. Copyright (c) Marek Aniola.
 * This program is provided to you under the terms of the license
 * as published at https://github.com/mangh/unitsofmeasurement.
 * 
 * Range of a projectile (demo application)
 * 
 *  angle |  tmax |  xmax   |  ymax   |   Q   |   P   |  Q/P
 *   (°)  |  (s)  |  (m)    |  (m)    | ticks | ticks | ratio
 *  ------+-------+---------+---------+-------+-------+------
 *     0° |   0 s |     0 m |     0 m |    14 |       |
 *     0° |   0 s |     0 m |     0 m |       |    18 |   0,8
 *     1° |   3 s |  1819 m |     8 m |    11 |       |
 *     1° |   3 s |  1819 m |     8 m |       |     4 |   2,8
 *     2° |   5 s |  3636 m |    31 m |    10 |       |
 *     2° |   5 s |  3636 m |    31 m |       |     5 |   2,0
 *     3° |   8 s |  5449 m |    71 m |    14 |       |
 *     3° |   8 s |  5449 m |    71 m |       |     7 |   2,0
 *     4° |  10 s |  7255 m |   127 m |    18 |       |
 *     4° |  10 s |  7255 m |   127 m |       |     6 |   3,0
 *     5° |  13 s |  9052 m |   197 m |    14 |       |
 *     5° |  13 s |  9052 m |   197 m |       |     4 |   3,5
 *     6° |  15 s | 10839 m |   284 m |    15 |       |
 *     6° |  15 s | 10839 m |   284 m |       |     4 |   3,8
 *     7° |  18 s | 12611 m |   387 m |    16 |       |
 *     7° |  18 s | 12611 m |   387 m |       |     4 |   4,0
 *     8° |  20 s | 14369 m |   505 m |    18 |       |
 *     8° |  20 s | 14369 m |   505 m |       |     4 |   4,5
 *     9° |  23 s | 16109 m |   637 m |    20 |       |
 *     9° |  23 s | 16109 m |   637 m |       |     4 |   5,0
 *    10° |  25 s | 17830 m |   785 m |    22 |       |
 *    10° |  25 s | 17830 m |   785 m |       |     4 |   5,5
 *    11° |  28 s | 19528 m |   949 m |    22 |       |
 *    11° |  28 s | 19528 m |   949 m |       |     4 |   5,5
 *    12° |  30 s | 21203 m |  1127 m |    24 |       |
 *    12° |  30 s | 21203 m |  1127 m |       |     5 |   4,8
 *    13° |  33 s | 22852 m |  1318 m |    30 |       |
 *    13° |  33 s | 22852 m |  1318 m |       |     5 |   6,0
 *    14° |  35 s | 24474 m |  1525 m |    38 |       |
 *    14° |  35 s | 24474 m |  1525 m |       |     5 |   7,6
 *    15° |  38 s | 26065 m |  1746 m |    37 |       |
 *    15° |  38 s | 26065 m |  1746 m |       |     4 |   9,3
 *    16° |  40 s | 27625 m |  1980 m |    31 |       |
 *    16° |  40 s | 27625 m |  1980 m |       |     5 |   6,2
 *    17° |  43 s | 29151 m |  2228 m |    33 |       |
 *    17° |  43 s | 29151 m |  2228 m |       |     5 |   6,6
 *    18° |  45 s | 30642 m |  2488 m |    36 |       |
 *    18° |  45 s | 30642 m |  2488 m |       |     5 |   7,2
 *    19° |  47 s | 32095 m |  2762 m |    35 |       |
 *    19° |  47 s | 32095 m |  2762 m |       |     4 |   8,8
 *    20° |  50 s | 33509 m |  3049 m |    35 |       |
 *    20° |  50 s | 33509 m |  3049 m |       |     4 |   8,8
 *    21° |  52 s | 34882 m |  3347 m |    38 |       |
 *    21° |  52 s | 34882 m |  3347 m |       |     4 |   9,5
 *    22° |  55 s | 36213 m |  3657 m |    40 |       |
 *    22° |  55 s | 36213 m |  3657 m |       |     6 |   6,7
 *    23° |  57 s | 37500 m |  3978 m |    40 |       |
 *    23° |  57 s | 37500 m |  3978 m |       |     5 |   8,0
 *    24° |  59 s | 38740 m |  4312 m |    50 |       |
 *    24° |  59 s | 38740 m |  4312 m |       |     6 |   8,3
 *    25° |  62 s | 39934 m |  4655 m |    40 |       |
 *    25° |  62 s | 39934 m |  4655 m |       |     6 |   6,7
 *    26° |  64 s | 41079 m |  5009 m |    41 |       |
 *    26° |  64 s | 41079 m |  5009 m |       |     5 |   8,2
 *    27° |  66 s | 42174 m |  5372 m |    40 |       |
 *    27° |  66 s | 42174 m |  5372 m |       |     5 |   8,0
 *    28° |  68 s | 43218 m |  5745 m |    41 |       |
 *    28° |  68 s | 43218 m |  5745 m |       |     4 |  10,3
 *    29° |  71 s | 44209 m |  6126 m |    41 |       |
 *    29° |  71 s | 44209 m |  6126 m |       |     5 |   8,2
 *    30° |  73 s | 45146 m |  6515 m |    43 |       |
 *    30° |  73 s | 45146 m |  6515 m |       |     5 |   8,6
 *    31° |  75 s | 46028 m |  6913 m |    52 |       |
 *    31° |  75 s | 46028 m |  6913 m |       |     5 |  10,4
 *    32° |  77 s | 46855 m |  7319 m |    45 |       |
 *    32° |  77 s | 46855 m |  7319 m |       |     4 |  11,3
 *    33° |  79 s | 47624 m |  7731 m |    48 |       |
 *    33° |  79 s | 47624 m |  7731 m |       |     8 |   6,0
 *    34° |  82 s | 48335 m |  8150 m |    57 |       |
 *    34° |  82 s | 48335 m |  8150 m |       |     8 |   7,1
 *    35° |  84 s | 48987 m |  8575 m |    54 |       |
 *    35° |  84 s | 48987 m |  8575 m |       |     5 |  10,8
 *    36° |  86 s | 49579 m |  9005 m |    69 |       |
 *    36° |  86 s | 49579 m |  9005 m |       |    10 |   6,9
 *    37° |  88 s | 50111 m |  9440 m |    56 |       |
 *    37° |  88 s | 50111 m |  9440 m |       |     6 |   9,3
 *    38° |  90 s | 50582 m |  9880 m |    54 |       |
 *    38° |  90 s | 50582 m |  9880 m |       |     5 |  10,8
 *    39° |  92 s | 50991 m | 10323 m |    53 |       |
 *    39° |  92 s | 50991 m | 10323 m |       |     5 |  10,6
 *    40° |  94 s | 51338 m | 10769 m |    54 |       |
 *    40° |  94 s | 51338 m | 10769 m |       |     5 |  10,8
 *    41° |  96 s | 51623 m | 11219 m |    56 |       |
 *    41° |  96 s | 51623 m | 11219 m |       |     5 |  11,2
 *    42° |  98 s | 51845 m | 11670 m |    57 |       |
 *    42° |  98 s | 51845 m | 11670 m |       |     5 |  11,4
 *    43° |  99 s | 52003 m | 12123 m |    57 |       |
 *    43° |  99 s | 52003 m | 12123 m |       |     6 |   9,5
 *    44° | 101 s | 52099 m | 12577 m |    58 |       |
 *    44° | 101 s | 52099 m | 12577 m |       |     5 |  11,6
 *    45° | 103 s | 52130 m | 13032 m |    71 |       |
 *    45° | 103 s | 52130 m | 13032 m |       |     8 |   8,9
 *    46° | 105 s | 52099 m | 13486 m |    69 |       |
 *    46° | 105 s | 52099 m | 13486 m |       |     5 |  13,8
 *    47° | 107 s | 52003 m | 13941 m |   408 |       |
 *    47° | 107 s | 52003 m | 13941 m |       |    11 |  37,1
 *    48° | 108 s | 51845 m | 14395 m |    76 |       |
 *    48° | 108 s | 51845 m | 14395 m |       |     6 |  12,7
 *    49° | 110 s | 51623 m | 14846 m |    70 |       |
 *    49° | 110 s | 51623 m | 14846 m |       |     6 |  11,7
 *    50° | 112 s | 51338 m | 15296 m |    71 |       |
 *    50° | 112 s | 51338 m | 15296 m |       |     6 |  11,8
 *    51° | 113 s | 50991 m | 15742 m |    71 |       |
 *    51° | 113 s | 50991 m | 15742 m |       |     6 |  11,8
 *    52° | 115 s | 50582 m | 16184 m |    71 |       |
 *    52° | 115 s | 50582 m | 16184 m |       |     6 |  11,8
 *    53° | 116 s | 50111 m | 16625 m |    72 |       |
 *    53° | 116 s | 50111 m | 16625 m |       |     6 |  12,0
 *    54° | 118 s | 49579 m | 17060 m |    73 |       |
 *    54° | 118 s | 49579 m | 17060 m |       |     5 |  14,6
 *    55° | 119 s | 48987 m | 17490 m |    74 |       |
 *    55° | 119 s | 48987 m | 17490 m |       |     6 |  12,3
 *    56° | 121 s | 48335 m | 17914 m |    81 |       |
 *    56° | 121 s | 48335 m | 17914 m |       |     7 |  11,6
 *    57° | 122 s | 47624 m | 18333 m |    80 |       |
 *    57° | 122 s | 47624 m | 18333 m |       |     9 |   8,9
 *    58° | 124 s | 46855 m | 18746 m |    81 |       |
 *    58° | 124 s | 46855 m | 18746 m |       |     8 |  10,1
 *    59° | 125 s | 46028 m | 19150 m |    80 |       |
 *    59° | 125 s | 46028 m | 19150 m |       |    11 |   7,3
 *    60° | 126 s | 45146 m | 19549 m |    79 |       |
 *    60° | 126 s | 45146 m | 19549 m |       |     7 |  11,3
 *    61° | 128 s | 44209 m | 19939 m |    88 |       |
 *    61° | 128 s | 44209 m | 19939 m |       |     7 |  12,6
 *    62° | 129 s | 43218 m | 20320 m |    79 |       |
 *    62° | 129 s | 43218 m | 20320 m |       |     7 |  11,3
 *    63° | 130 s | 42174 m | 20693 m |    80 |       |
 *    63° | 130 s | 42174 m | 20693 m |       |     6 |  13,3
 *    64° | 131 s | 41079 m | 21055 m |    81 |       |
 *    64° | 131 s | 41079 m | 21055 m |       |    11 |   7,4
 *    65° | 132 s | 39934 m | 21410 m |    80 |       |
 *    65° | 132 s | 39934 m | 21410 m |       |     6 |  13,3
 *    66° | 133 s | 38740 m | 21752 m |    82 |       |
 *    66° | 133 s | 38740 m | 21752 m |       |     6 |  13,7
 *    67° | 134 s | 37500 m | 22086 m |    94 |       |
 *    67° | 134 s | 37500 m | 22086 m |       |     7 |  13,4
 *    68° | 135 s | 36213 m | 22407 m |    88 |       |
 *    68° | 135 s | 36213 m | 22407 m |       |     8 |  11,0
 *    69° | 136 s | 34882 m | 22718 m |    89 |       |
 *    69° | 136 s | 34882 m | 22718 m |       |     9 |   9,9
 *    70° | 137 s | 33509 m | 23015 m |   107 |       |
 *    70° | 137 s | 33509 m | 23015 m |       |    15 |   7,1
 *    71° | 138 s | 32095 m | 23302 m |    93 |       |
 *    71° | 138 s | 32095 m | 23302 m |       |     7 |  13,3
 *    72° | 139 s | 30642 m | 23576 m |    85 |       |
 *    72° | 139 s | 30642 m | 23576 m |       |     7 |  12,1
 *    73° | 139 s | 29151 m | 23837 m |    97 |       |
 *    73° | 139 s | 29151 m | 23837 m |       |     7 |  13,9
 *    74° | 140 s | 27625 m | 24085 m |    87 |       |
 *    74° | 140 s | 27625 m | 24085 m |       |     6 |  14,5
 *    75° | 141 s | 26065 m | 24318 m |    86 |       |
 *    75° | 141 s | 26065 m | 24318 m |       |     6 |  14,3
 *    76° | 141 s | 24474 m | 24539 m |    82 |       |
 *    76° | 141 s | 24474 m | 24539 m |       |     6 |  13,7
 *    77° | 142 s | 22852 m | 24746 m |    81 |       |
 *    77° | 142 s | 22852 m | 24746 m |       |    11 |   7,4
 *    78° | 143 s | 21203 m | 24938 m |    89 |       |
 *    78° | 143 s | 21203 m | 24938 m |       |    10 |   8,9
 *    79° | 143 s | 19528 m | 25115 m |    87 |       |
 *    79° | 143 s | 19528 m | 25115 m |       |     6 |  14,5
 *    80° | 144 s | 17830 m | 25279 m |    83 |       |
 *    80° | 144 s | 17830 m | 25279 m |       |     6 |  13,8
 *    81° | 144 s | 16109 m | 25427 m |    83 |       |
 *    81° | 144 s | 16109 m | 25427 m |       |     6 |  13,8
 *    82° | 144 s | 14369 m | 25560 m |    82 |       |
 *    82° | 144 s | 14369 m | 25560 m |       |     7 |  11,7
 *    83° | 145 s | 12611 m | 25677 m |   117 |       |
 *    83° | 145 s | 12611 m | 25677 m |       |     8 |  14,6
 *    84° | 145 s | 10839 m | 25779 m |   104 |       |
 *    84° | 145 s | 10839 m | 25779 m |       |     7 |  14,9
 *    85° | 145 s |  9052 m | 25867 m |    86 |       |
 *    85° | 145 s |  9052 m | 25867 m |       |     7 |  12,3
 *    86° | 145 s |  7255 m | 25938 m |    84 |       |
 *    86° | 145 s |  7255 m | 25938 m |       |     6 |  14,0
 *    87° | 146 s |  5449 m | 25994 m |    83 |       |
 *    87° | 146 s |  5449 m | 25994 m |       |     7 |  11,9
 *    88° | 146 s |  3636 m | 26033 m |    86 |       |
 *    88° | 146 s |  3636 m | 26033 m |       |     7 |  12,3
 *    89° | 146 s |  1819 m | 26057 m |    83 |       |
 *    89° | 146 s |  1819 m | 26057 m |       |    12 |   6,9
 * 
 * Average performance ratio Q/P (quantities/plain) = 9,9.
 * 
 */
