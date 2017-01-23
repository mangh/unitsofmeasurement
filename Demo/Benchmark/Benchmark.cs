using System;
using System.Linq;

namespace Benchmark
{
    class Benchmark
    {
        private double[] ratio;
        private int current;

        public double Mean { get; private set; }
        public double StdDev { get; private set; }

        public Benchmark(int size)
        {
            ratio = new double[size];
            current = 0;
        }
        public bool Add(long slow, long fast)
        {
            ratio[current++] = (double)slow / fast;
            bool complete;
            if(complete = (current >= ratio.Length))
            {
                CalculateAverage();
                current = 0;
            }
            return complete;
        }
        public void CalculateAverage()
        {
            if(current <= 0)
            {
                Mean = StdDev = double.NaN;
            }
            else
            {
                var calculated = ratio.Where((r,i) => i < current);
                Mean = calculated.Average();
                StdDev = Math.Sqrt(calculated.Sum(r => (r - Mean) * (r - Mean)) / current);
            }
        }
    }
}
