/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


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
                "as published at http://unitsofmeasurement.codeplex.com/license."
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
                    Degree.Symbol[0], Second.Symbol[0], Meter.Symbol[0], Meter.Symbol[0] 
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
