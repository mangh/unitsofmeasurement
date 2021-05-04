using System;

namespace Bullet.Plain
{
    public class Calculator
    {
        public readonly double g = 9.80665; // the gravitational acceleration (Meter/Sec2)
        public readonly double v;           // the velocity at which the projectile is launched (Meter/Sec)
        public readonly double h;           // the initial height of the projectile (Meter)

        public Calculator(double height, double velocity)
        {
            v = velocity;
            h = height;
        }

        public (double, double, double, double) CalculateRange(double slope)
        {
            // the angle (in Radians) at which the projectile is launched
            double angle = Math.PI / 180.0 * slope;

            // the vertical component of the velocity
            double vy = v * Math.Sin(angle);

            // the time it takes for the projectile to finish its trajectory:
            double tmax = (vy + Math.Sqrt(vy * vy + 2.0 * g * h)) / g;

            // the total horizontal distance traveled by the projectile
            double xmax = v * Math.Cos(angle) * tmax;

            // maximum vertical displacement of the projectile
            double ymax = h;
            for (double t = 0.0; t < tmax; t++)
            {
                var y = h + (vy - g * t) * t / 2.0;
                if (y > ymax) ymax = y;
            }

            return (slope, tmax, xmax, ymax);
        }
    }
}
