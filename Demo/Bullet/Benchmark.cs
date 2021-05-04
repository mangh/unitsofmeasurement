using System;
using System.Collections.Generic;
using System.Linq;

namespace Bullet
{
    public class Benchmark
    {
        private readonly List<double> samples;

        public double Average => samples.Average();
        public double StdDev => Math.Sqrt(samples.Average(r => (r - Average) * (r - Average)));
        public double StdDevPercentage => 100.0 * StdDev / Average;
        public int Count => samples.Count;

        public Benchmark()
        {
            samples = new List<double>();
        }

        public void Add(double sample) => samples.Add(sample);
        public void Reset() => samples.Clear();
    }
}
