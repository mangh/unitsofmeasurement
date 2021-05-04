#if DIMENSIONAL_ANALYSIS
    using Demo.UnitsOfMeasurement;
    using static Demo.UnitsOfMeasurement.Math;
#else
    using static System.Math;
    using Degree = System.Double;
    using Meter = System.Double;
    using Meter_Sec = System.Double;
    using Meter_Sec2 = System.Double;
    using Radian = System.Double;
    using Second = System.Double;
#endif

namespace Bullet.Measured
{
    public class Calculator
    {
        public readonly Meter_Sec2 g = (Meter_Sec2)9.80665; // the gravitational acceleration
        public readonly Meter_Sec v;    // the velocity at which the projectile is launched
        public readonly Meter h;        // the initial height of the projectile

        public Calculator(Meter height, Meter_Sec velocity)
        {
            v = velocity;
            h = height;
        }

        public (Degree, Second, Meter, Meter) CalculateRange(Degree slope)
        {
            // the angle (in Radians) at which the projectile is launched
#if DIMENSIONAL_ANALYSIS
            Radian angle = (Radian)slope;
#else
            Radian angle = (Demo.UnitsOfMeasurement.Radian.Factor / Demo.UnitsOfMeasurement.Degree.Factor) * slope;
#endif

            // the vertical component of the velocity
            Meter_Sec vy = v * Sin(angle);

            // the time it takes for the projectile to finish its trajectory:
            Second tmax = (vy + Sqrt(vy * vy + 2.0 * g * h)) / g;

            // the total horizontal distance traveled by the projectile
            Meter xmax = v * Cos(angle) * tmax;

            // maximum vertical displacement of the projectile
            Meter ymax = h;
            for (Second t = (Second)0.0; t < tmax; t++)
            {
                Meter y = h + (vy - g * t) * t / 2.0;
                if (y > ymax) ymax = y;
            }

            return (slope, tmax, xmax, ymax);
        }
    }
}
