using static System.Math;

namespace ProjectileRange
{
    partial class Program
    {
        static void CalculateProjectileRange(double degrees, out double tmax, out double xmax, out double ymax)
        {
            double g = 9.80665; // the gravitational acceleration
            double v = 715.0;   // the velocity at which the projectile is launched (AK-47)
            double h = 0.0;     // the initial height of the projectile
            double angle = degrees * PI / 180.0;	// the angle at which the projectile is launched

            // the time it takes for the projectile to finish its trajectory:
            tmax = (v * Sin(angle) + Sqrt(v * Sin(angle) * v * Sin(angle) + 2.0 * g * h)) / g;

            ymax = h;
            for (double t = 0.0; t < tmax; t++)
            {
                double y = h + v * Sin(angle) * t - g * t * t / 2.0;
                if (y > ymax) ymax = y;
            }

            // the total horizontal distance traveled by the projectile
            xmax = v * Cos(angle) * tmax;
        }
    }
}
