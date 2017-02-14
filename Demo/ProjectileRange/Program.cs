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
    class Program
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
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static long GetCalculationsTime(Degree angle)
        {
            sw.Restart();

            Second tmax; Meter xmax, ymax;
            CalculateProjectileRange(angle, out tmax, out xmax, out ymax);

            sw.Stop();
            long ticks = sw.ElapsedTicks;

            Console.WriteLine("{0} | {1} | {2} | {3} | {4,5} |       |", angle, tmax, xmax, ymax, ticks);

            return ticks;
        }

        static long GetCalculationsTime(double angle)
        {
            sw.Restart();

            double tmax, xmax, ymax;
            CalculateProjectileRange(angle, out tmax, out xmax, out ymax);

            sw.Stop();
            long ticks = sw.ElapsedTicks;

            Console.Write("{0,5:F0}\u00B0 | {1,3:F0} s | {2,5:F0} m | {3,5:F0} m |       | {4,5} |", angle, tmax, xmax, ymax, ticks);

            return ticks;
        }

        static void CalculateProjectileRange(Degree degrees, out Second tmax, out Meter xmax, out Meter ymax)
        {
            var g = (Meter_Sec2)9.80665; // the gravitational acceleration
            var v = (Meter_Sec)715.0;    // the velocity at which the projectile is launched (AK-47)
            var h = (Meter)0.0;          // the initial height of the projectile
            var angle = (Radian)degrees; // the angle at which the projectile is launched

            // the time it takes for the projectile to finish its trajectory:
            tmax = (v * UMath.Sin(angle) + UMath.Sqrt((v * UMath.Sin(angle)) * (v * UMath.Sin(angle)) + 2.0 * g * h)) / g;

            ymax = h;
            for (Second t = (Second)0.0; t < tmax; t++)
            {
                Meter y = h + v * UMath.Sin(angle) * t - g * t * t / 2.0;
                if (y > ymax) ymax = y;
            }

            // the total horizontal distance traveled by the projectile
            xmax = v * UMath.Cos(angle) * tmax;
        }

        static void CalculateProjectileRange(double degrees, out double tmax, out double xmax, out double ymax)
        {
            double g = 9.80665; // the gravitational acceleration
            double v = 715.0;   // the velocity at which the projectile is launched (AK-47)
            double h = 0.0;     // the initial height of the projectile
            double angle = degrees * Math.PI / 180.0;	// the angle at which the projectile is launched

            // the time it takes for the projectile to finish its trajectory:
            tmax = (v * Math.Sin(angle) + Math.Sqrt((v * Math.Sin(angle)) * (v * Math.Sin(angle)) + 2.0 * g * h)) / g;

            ymax = h;
            for (double t = 0.0; t < tmax; t++)
            {
                double y = h + v * Math.Sin(angle) * t - g * t * t / 2.0;
                if (y > ymax) ymax = y;
            }

            // the total horizontal distance traveled by the projectile
            xmax = v * Math.Cos(angle) * tmax;
        }
    }
}

/*
 Sample output:
 
 Range of a projectile (demo application)

 angle |  tmax |  xmax   |  ymax   |   Q   |   P   |  Q/P
  (°)  |  (s)  |  (m)    |  (m)    | ticks | ticks | ratio
 ------+-------+---------+---------+-------+-------+------
    0° |   0 s |     0 m |     0 m |     6 |       |
    0° |   0 s |     0 m |     0 m |       |     2 |   3,0
    1° |   3 s |  1819 m |     8 m |    13 |       |
    1° |   3 s |  1819 m |     8 m |       |     4 |   3,3
    2° |   5 s |  3636 m |    31 m |    15 |       |
    2° |   5 s |  3636 m |    31 m |       |     5 |   3,0
    3° |   8 s |  5449 m |    71 m |    11 |       |
    3° |   8 s |  5449 m |    71 m |       |     5 |   2,2
    4° |  10 s |  7255 m |   127 m |    11 |       |
    4° |  10 s |  7255 m |   127 m |       |     6 |   1,8
    5° |  13 s |  9052 m |   197 m |    13 |       |
    5° |  13 s |  9052 m |   197 m |       |     7 |   1,9
    6° |  15 s | 10839 m |   284 m |    15 |       |
    6° |  15 s | 10839 m |   284 m |       |     8 |   1,9
    7° |  18 s | 12611 m |   387 m |    14 |       |
    7° |  18 s | 12611 m |   387 m |       |     9 |   1,6
    8° |  20 s | 14369 m |   505 m |    15 |       |
    8° |  20 s | 14369 m |   505 m |       |     9 |   1,7
    9° |  23 s | 16109 m |   637 m |    20 |       |
    9° |  23 s | 16109 m |   637 m |       |     9 |   2,2
   10° |  25 s | 17830 m |   785 m |    18 |       |
   10° |  25 s | 17830 m |   785 m |       |    10 |   1,8
   11° |  28 s | 19528 m |   949 m |    18 |       |
   11° |  28 s | 19528 m |   949 m |       |     9 |   2,0
   12° |  30 s | 21203 m |  1127 m |    19 |       |
   12° |  30 s | 21203 m |  1127 m |       |    13 |   1,5
   13° |  33 s | 22852 m |  1318 m |    22 |       |
   13° |  33 s | 22852 m |  1318 m |       |    12 |   1,8
   14° |  35 s | 24474 m |  1525 m |    22 |       |
   14° |  35 s | 24474 m |  1525 m |       |    11 |   2,0
   15° |  38 s | 26065 m |  1746 m |    23 |       |
   15° |  38 s | 26065 m |  1746 m |       |    13 |   1,8
   16° |  40 s | 27625 m |  1980 m |    24 |       |
   16° |  40 s | 27625 m |  1980 m |       |    14 |   1,7
   17° |  43 s | 29151 m |  2228 m |    27 |       |
   17° |  43 s | 29151 m |  2228 m |       |    14 |   1,9
   18° |  45 s | 30642 m |  2488 m |    26 |       |
   18° |  45 s | 30642 m |  2488 m |       |    15 |   1,7
   19° |  47 s | 32095 m |  2762 m |    26 |       |
   19° |  47 s | 32095 m |  2762 m |       |    18 |   1,4
   20° |  50 s | 33509 m |  3049 m |    29 |       |
   20° |  50 s | 33509 m |  3049 m |       |    18 |   1,6
   21° |  52 s | 34882 m |  3347 m |    30 |       |
   21° |  52 s | 34882 m |  3347 m |       |    18 |   1,7
   22° |  55 s | 36213 m |  3657 m |    23 |       |
   22° |  55 s | 36213 m |  3657 m |       |    16 |   1,4
   23° |  57 s | 37500 m |  3978 m |    25 |       |
   23° |  57 s | 37500 m |  3978 m |       |    18 |   1,4
   24° |  59 s | 38740 m |  4312 m |    28 |       |
   24° |  59 s | 38740 m |  4312 m |       |    19 |   1,5
   25° |  62 s | 39934 m |  4655 m |    27 |       |
   25° |  62 s | 39934 m |  4655 m |       |    16 |   1,7
   26° |  64 s | 41079 m |  5009 m |    27 |       |
   26° |  64 s | 41079 m |  5009 m |       |    17 |   1,6
   27° |  66 s | 42174 m |  5372 m |    27 |       |
   27° |  66 s | 42174 m |  5372 m |       |    18 |   1,5
   28° |  68 s | 43218 m |  5745 m |    36 |       |
   28° |  68 s | 43218 m |  5745 m |       |    21 |   1,7
   29° |  71 s | 44209 m |  6126 m |    31 |       |
   29° |  71 s | 44209 m |  6126 m |       |    19 |   1,6
   30° |  73 s | 45146 m |  6515 m |    30 |       |
   30° |  73 s | 45146 m |  6515 m |       |    18 |   1,7
   31° |  75 s | 46028 m |  6913 m |    32 |       |
   31° |  75 s | 46028 m |  6913 m |       |    19 |   1,7
   32° |  77 s | 46855 m |  7319 m |    31 |       |
   32° |  77 s | 46855 m |  7319 m |       |    24 |   1,3
   33° |  79 s | 47624 m |  7731 m |    32 |       |
   33° |  79 s | 47624 m |  7731 m |       |    21 |   1,5
   34° |  82 s | 48335 m |  8150 m |    33 |       |
   34° |  82 s | 48335 m |  8150 m |       |    21 |   1,6
   35° |  84 s | 48987 m |  8575 m |    34 |       |
   35° |  84 s | 48987 m |  8575 m |       |    22 |   1,5
   36° |  86 s | 49579 m |  9005 m |    34 |       |
   36° |  86 s | 49579 m |  9005 m |       |    21 |   1,6
   37° |  88 s | 50111 m |  9440 m |    34 |       |
   37° |  88 s | 50111 m |  9440 m |       |    22 |   1,5
   38° |  90 s | 50582 m |  9880 m |    34 |       |
   38° |  90 s | 50582 m |  9880 m |       |    23 |   1,5
   39° |  92 s | 50991 m | 10323 m |    36 |       |
   39° |  92 s | 50991 m | 10323 m |       |    23 |   1,6
   40° |  94 s | 51338 m | 10769 m |    46 |       |
   40° |  94 s | 51338 m | 10769 m |       |    24 |   1,9
   41° |  96 s | 51623 m | 11219 m |    38 |       |
   41° |  96 s | 51623 m | 11219 m |       |    24 |   1,6
   42° |  98 s | 51845 m | 11670 m |    36 |       |
   42° |  98 s | 51845 m | 11670 m |       |    24 |   1,5
   43° |  99 s | 52003 m | 12123 m |    33 |       |
   43° |  99 s | 52003 m | 12123 m |       |    25 |   1,3
   44° | 101 s | 52099 m | 12577 m |    45 |       |
   44° | 101 s | 52099 m | 12577 m |       |    28 |   1,6
   45° | 103 s | 52130 m | 13032 m |    36 |       |
   45° | 103 s | 52130 m | 13032 m |       |    24 |   1,5
   46° | 105 s | 52099 m | 13486 m |    39 |       |
   46° | 105 s | 52099 m | 13486 m |       |    26 |   1,5
   47° | 107 s | 52003 m | 13941 m |    39 |       |
   47° | 107 s | 52003 m | 13941 m |       |    29 |   1,3
   48° | 108 s | 51845 m | 14395 m |    41 |       |
   48° | 108 s | 51845 m | 14395 m |       |    31 |   1,3
   49° | 110 s | 51623 m | 14846 m |    48 |       |
   49° | 110 s | 51623 m | 14846 m |       |    28 |   1,7
   50° | 112 s | 51338 m | 15296 m |    42 |       |
   50° | 112 s | 51338 m | 15296 m |       |    29 |   1,4
   51° | 113 s | 50991 m | 15742 m |    41 |       |
   51° | 113 s | 50991 m | 15742 m |       |    28 |   1,5
   52° | 115 s | 50582 m | 16184 m |    42 |       |
   52° | 115 s | 50582 m | 16184 m |       |    30 |   1,4
   53° | 116 s | 50111 m | 16625 m |    44 |       |
   53° | 116 s | 50111 m | 16625 m |       |    29 |   1,5
   54° | 118 s | 49579 m | 17060 m |    45 |       |
   54° | 118 s | 49579 m | 17060 m |       |    32 |   1,4
   55° | 119 s | 48987 m | 17490 m |    43 |       |
   55° | 119 s | 48987 m | 17490 m |       |    29 |   1,5
   56° | 121 s | 48335 m | 17914 m |    44 |       |
   56° | 121 s | 48335 m | 17914 m |       |    32 |   1,4
   57° | 122 s | 47624 m | 18333 m |    44 |       |
   57° | 122 s | 47624 m | 18333 m |       |    33 |   1,3
   58° | 124 s | 46855 m | 18746 m |    94 |       |
   58° | 124 s | 46855 m | 18746 m |       |    34 |   2,8
   59° | 125 s | 46028 m | 19150 m |    46 |       |
   59° | 125 s | 46028 m | 19150 m |       |    32 |   1,4
   60° | 126 s | 45146 m | 19549 m |    47 |       |
   60° | 126 s | 45146 m | 19549 m |       |    32 |   1,5
   61° | 128 s | 44209 m | 19939 m |    46 |       |
   61° | 128 s | 44209 m | 19939 m |       |    34 |   1,4
   62° | 129 s | 43218 m | 20320 m |    49 |       |
   62° | 129 s | 43218 m | 20320 m |       |    32 |   1,5
   63° | 130 s | 42174 m | 20693 m |    49 |       |
   63° | 130 s | 42174 m | 20693 m |       |    33 |   1,5
   64° | 131 s | 41079 m | 21055 m |    49 |       |
   64° | 131 s | 41079 m | 21055 m |       |    33 |   1,5
   65° | 132 s | 39934 m | 21410 m |    87 |       |
   65° | 132 s | 39934 m | 21410 m |       |    33 |   2,6
   66° | 133 s | 38740 m | 21752 m |    44 |       |
   66° | 133 s | 38740 m | 21752 m |       |    35 |   1,3
   67° | 134 s | 37500 m | 22086 m |    45 |       |
   67° | 134 s | 37500 m | 22086 m |       |    29 |   1,6
   68° | 135 s | 36213 m | 22407 m |    46 |       |
   68° | 135 s | 36213 m | 22407 m |       |    30 |   1,5
   69° | 136 s | 34882 m | 22718 m |    45 |       |
   69° | 136 s | 34882 m | 22718 m |       |    30 |   1,5
   70° | 137 s | 33509 m | 23015 m |    45 |       |
   70° | 137 s | 33509 m | 23015 m |       |    32 |   1,4
   71° | 138 s | 32095 m | 23302 m |    45 |       |
   71° | 138 s | 32095 m | 23302 m |       |    32 |   1,4
   72° | 139 s | 30642 m | 23576 m |    46 |       |
   72° | 139 s | 30642 m | 23576 m |       |    34 |   1,4
   73° | 139 s | 29151 m | 23837 m |    47 |       |
   73° | 139 s | 29151 m | 23837 m |       |   199 |   0,2
   74° | 140 s | 27625 m | 24085 m |    47 |       |
   74° | 140 s | 27625 m | 24085 m |       |    34 |   1,4
   75° | 141 s | 26065 m | 24318 m |    45 |       |
   75° | 141 s | 26065 m | 24318 m |       |    32 |   1,4
   76° | 141 s | 24474 m | 24539 m |    41 |       |
   76° | 141 s | 24474 m | 24539 m |       |    29 |   1,4
   77° | 142 s | 22852 m | 24746 m |    44 |       |
   77° | 142 s | 22852 m | 24746 m |       |    26 |   1,7
   78° | 143 s | 21203 m | 24938 m |    44 |       |
   78° | 143 s | 21203 m | 24938 m |       |    27 |   1,6
   79° | 143 s | 19528 m | 25115 m |    43 |       |
   79° | 143 s | 19528 m | 25115 m |       |    28 |   1,5
   80° | 144 s | 17830 m | 25279 m |    43 |       |
   80° | 144 s | 17830 m | 25279 m |       |    29 |   1,5
   81° | 144 s | 16109 m | 25427 m |    43 |       |
   81° | 144 s | 16109 m | 25427 m |       |    31 |   1,4
   82° | 144 s | 14369 m | 25560 m |    43 |       |
   82° | 144 s | 14369 m | 25560 m |       |    27 |   1,6
   83° | 145 s | 12611 m | 25677 m |    50 |       |
   83° | 145 s | 12611 m | 25677 m |       |    27 |   1,9
   84° | 145 s | 10839 m | 25779 m |    42 |       |
   84° | 145 s | 10839 m | 25779 m |       |    29 |   1,4
   85° | 145 s |  9052 m | 25867 m |    43 |       |
   85° | 145 s |  9052 m | 25867 m |       |    29 |   1,5
   86° | 145 s |  7255 m | 25938 m |    42 |       |
   86° | 145 s |  7255 m | 25938 m |       |    26 |   1,6
   87° | 146 s |  5449 m | 25994 m |    53 |       |
   87° | 146 s |  5449 m | 25994 m |       |    27 |   2,0
   88° | 146 s |  3636 m | 26033 m |    48 |       |
   88° | 146 s |  3636 m | 26033 m |       |    29 |   1,7
   89° | 146 s |  1819 m | 26057 m |    42 |       |
   89° | 146 s |  1819 m | 26057 m |       |    27 |   1,6

Average performance ratio Q/P (quantities/plain) = 1,6.

*/