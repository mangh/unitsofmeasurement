using System.Collections.Generic;

namespace Bullet.Plain
{
    public class Sampler : Calculator
    {
        public List<(double, double, double, double)> results;
        public Timer<double, (double, double, double, double)> timer;
        public Benchmark benchmark;

        public Sampler(double height, double velocity) :
            base(height, velocity)
        {
            results = new List<(double, double, double, double)>(1000);
            benchmark = new Benchmark();
            timer = new Timer<double, (double, double, double, double)>(
                (double min, double max, double step) =>
                {
                    results.Clear();
                    for (double slope = min; slope < max; slope += step) results.Add(CalculateRange(slope));
                    return results;
                }
            );
        }

        public List<(double, double, double, double)> Sample(double min, double max, double step)
        {
            var result = timer.WatchComputation(min, max, step);
            benchmark.Add(timer.elapsed);
            return result;
        }
    }
}
