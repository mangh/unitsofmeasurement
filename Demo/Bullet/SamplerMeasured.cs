using System.Collections.Generic;

#if DIMENSIONAL_ANALYSIS
    using Demo.UnitsOfMeasurement;
    using static Demo.UnitsOfMeasurement.Math;
#else
    using Meter = System.Double;
    using Second = System.Double;
    using Degree = System.Double;
    using Meter_Sec = System.Double;
#endif

namespace Bullet.Measured
{
    public class Sampler : Calculator
    {
        public List<(Degree, Second, Meter, Meter)> results;
        public Timer<Degree, (Degree, Second, Meter, Meter)> timer;
        public Benchmark benchmark;

        public Sampler(Meter height, Meter_Sec velocity) :
            base(height, velocity)
        {
            results = new List<(Degree, Second, Meter, Meter)>(1000);
            benchmark = new Benchmark();
            timer = new Timer<Degree, (Degree, Second, Meter, Meter)>(
                (Degree min, Degree max, Degree step) =>
                {
                    results.Clear();
                    for (Degree slope = min; slope < max; slope += step) results.Add(CalculateRange(slope));
                    return results;
                }
            );
        }

        public List<(Degree, Second, Meter, Meter)> Sample(Degree min, Degree max, Degree step)
        {
            var result = timer.WatchComputation(min, max, step);
            benchmark.Add(timer.elapsed);
            return result;
        }
    }
}
