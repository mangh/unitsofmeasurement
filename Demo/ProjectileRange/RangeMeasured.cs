using Demo.UnitsOfMeasurement;

using static Demo.UnitsOfMeasurement.Math;

namespace ProjectileRange
{
    partial class Program
    {
        static void CalculateProjectileRange(Degree degrees, out Second tmax, out Meter xmax, out Meter ymax)
        {
            var g = (Meter_Sec2)9.80665; // the gravitational acceleration
            var v = (Meter_Sec)715.0;    // the velocity at which the projectile is launched (AK-47)
            var h = (Meter)0.0;          // the initial height of the projectile
            var angle = (Radian)degrees; // the angle at which the projectile is launched

            // the time it takes for the projectile to finish its trajectory:
            tmax = (v * Sin(angle) + Sqrt(v * Sin(angle) * v * Sin(angle) + 2.0 * g * h)) / g;

            ymax = h;
            for (Second t = (Second)1.0; t < tmax; t++)
            {
                Meter y = h + v * Sin(angle) * t - g * t * t / 2.0;
                if (y > ymax) ymax = y;
            }

            // the total horizontal distance traveled by the projectile
            xmax = v * Cos(angle) * tmax;
        }

    }
}
