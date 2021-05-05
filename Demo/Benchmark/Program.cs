/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

#if DIMENSIONAL_ANALYSIS
    using Demo.UnitsOfMeasurement;
    using static Demo.UnitsOfMeasurement.Math;
#else
    using Meter = System.Double;
    using Foot = System.Double;
    using Yard = System.Double;
    using Second = System.Double;
    using Degree = System.Double;
    using SquareFoot = System.Double;
    using Meter_Sec = System.Double;
#endif

namespace Benchmark
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class Arithmetic
    {
        static readonly double max = 1000000.0;
        static readonly Foot maxf = (Foot)max;

        static readonly Bullet.Plain.Calculator plain = new Bullet.Plain.Calculator(0.0, 715.0);
        static readonly Bullet.Measured.Calculator fancy = new Bullet.Measured.Calculator((Meter)0.0, (Meter_Sec)715.0);

        public Arithmetic()
        {
        }

        // The following (unnecessary) Params declaration(s) makes
        // BenchmarkDotNet reporting the DIMENSIONAL_ANALYSIS symbol status:
#if DIMENSIONAL_ANALYSIS
        [Params("On")]
        public string DimensionalAnalysis { get; set; }        
#else
        [Params("Off")]
        public string DimensionalAnalysis { get; set; }
#endif

        // Plain arithmetic //////////////////////////////////////////////
        public static double ADD(double x, double y) => x + y;
        public static double SUB(double x, double y) => x - y;
        public static double MUL(double x, double y) => x * y;
        public static double DIV(double x, double y) => x / y;
        public static double CVT(double x) => (Demo.UnitsOfMeasurement.Yard.Factor / Demo.UnitsOfMeasurement.Foot.Factor) * x;
        public static double MIX(double x, double y)
        {
            double sum = x + y;
            double diff = x - y;
            double product = x * y;
            double quotient = (x / y);
            double yards = (Demo.UnitsOfMeasurement.Yard.Factor / Demo.UnitsOfMeasurement.Foot.Factor) * sum;
            return product / (sum + diff) * quotient + (Demo.UnitsOfMeasurement.Foot.Factor / Demo.UnitsOfMeasurement.Yard.Factor) * yards;
        }

        public delegate double D_DD(double x, double y);
        public static double PlainLoop(D_DD func)
        {
            double ret = 0.0;
            for (double x = 1.0, y = 1.0; x < max; x++, y++) ret = func(x, y);
            return ret;
        }

        public delegate double D_D(double x);
        public static double PlainLoop4(D_D func)
        {
            double ret = 0.0;
            for (double x = 1.0; x < max; x++) ret = func(x);
            return ret;
        }

        // Quantity (fancy) arithmetic ///////////////////////////////////////////
        public static Foot QADD(Foot p, Foot q) => p + q;
        public static Foot QSUB(Foot p, Foot q) => p - q;
        public static SquareFoot QMUL(Foot p, Foot q) => p * q;
        public static double QDIV(Foot p, Foot q) => p / q;
        public static Yard QCVT(Foot p) => (Yard)p;
        public static Foot QMIX(Foot p, Foot q)
        {
            Foot sum = p + q;
            Foot diff = p - q;
            SquareFoot product = p * q;
            double quotient = (p / q);
            Yard yards = (Yard)sum;
            return product / (sum + diff) * quotient + (Foot)yards;
        }

        public delegate Foot F_FF(Foot x, Foot y);
        public static Foot UnitLoop(F_FF func)
        {
            Foot ret = (Foot)0.0;
            for (Foot x = (Foot)1.0, y = (Foot)1.0; x < maxf; x++, y++) ret = func(x, y);
            return ret;
        }

        public delegate SquareFoot SF_FF(Foot x, Foot y);
        public static SquareFoot UnitLoop2(SF_FF func)
        {
            SquareFoot ret = (SquareFoot)0.0;
            for (Foot x = (Foot)1.0, y = (Foot)1.0; x < maxf; x++, y++) ret = func(x, y);
            return ret;
        }

        public delegate double D_FF(Foot x, Foot y);
        public static double UnitLoop3(D_FF func)
        {
            double ret = 0.0;
            for (Foot x = (Foot)1.0, y = (Foot)1.0; x < maxf; x++, y++) ret = func(x, y);
            return ret;
        }

        public delegate Yard Y_F(Foot x);
        public static Yard UnitLoop4(Y_F func)
        {
            Yard ret = (Yard)0.0;
            for (Foot x = (Foot)1.0; x < maxf; x++) ret = func(x);
            return ret;
        }

        // Benchmarking //////////////////////////////////////////////////

        [BenchmarkCategory("Add"), Benchmark(Baseline = true)] public double PlainAdd() => PlainLoop(ADD);
        [BenchmarkCategory("Sub"), Benchmark(Baseline = true)] public double PlainSubtract() => PlainLoop(SUB);
        [BenchmarkCategory("Mul"), Benchmark(Baseline = true)] public double PlainMultiply() => PlainLoop(MUL);
        [BenchmarkCategory("Div"), Benchmark(Baseline = true)] public double PlainDivide() => PlainLoop(DIV);
        [BenchmarkCategory("Cvt"), Benchmark(Baseline = true)] public double PlainConvert() => PlainLoop4(CVT);
        [BenchmarkCategory("Mix"), Benchmark(Baseline = true)] public double PlainMixture() => PlainLoop(MIX);

        [BenchmarkCategory("Bullet"), Benchmark(Baseline = true)]
        public (double, double, double, double) PlainBullet()
        {
            var result = (0.0, 0.0, 0.0, 0.0);
            for (double slope = 0.0; slope < 90.0; slope += 0.1)
            {
                result = plain.CalculateRange(slope);
            }
            return result;
        }

        [BenchmarkCategory("Add"), Benchmark] public Foot UnitsAdd() => UnitLoop(QADD);
        [BenchmarkCategory("Sub"), Benchmark] public Foot UnitsSubtract() => UnitLoop(QSUB);
        [BenchmarkCategory("Mul"), Benchmark] public SquareFoot UnitsMultiply() => UnitLoop2(QMUL);
        [BenchmarkCategory("Div"), Benchmark] public double UnitsDivide() => UnitLoop3(QDIV);
        [BenchmarkCategory("Cvt"), Benchmark] public Yard UnitsConvert() => UnitLoop4(QCVT);
        [BenchmarkCategory("Mix"), Benchmark] public Foot UnitsMixture() => UnitLoop(QMIX);
        [BenchmarkCategory("Bullet"), Benchmark]
        public (Degree, Second, Meter, Meter) UnitsBullet()
        {
            var result = ((Degree)0.0, (Second)0.0, (Meter)0.0, (Meter)0.0);
            for (double slope = 0.0; slope < 90.0; slope += 0.1)
            {
                result = fancy.CalculateRange((Degree)slope);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Arithmetic>();
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
/*
 * Sample reports (shortened):
 * 
 * BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
 * Intel Core i5-3360M CPU 2.80GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
 *   [Host]     : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
 *   DefaultJob : .NET Framework 4.8 (4.8.4341.0), X64 RyuJIT
 * 
 * 
 * |        Method | DimensionalAnalysis |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |
 * |-------------- |-------------------- |-----------:|----------:|----------:|-----------:|------:|--------:|
 * |      PlainAdd |                 Off | 3,941.2 μs |  61.40 μs |  47.94 μs | 3,931.6 μs |  1.00 |    0.00 |
 * |      UnitsAdd |                 Off | 3,934.2 μs |  20.37 μs |  17.01 μs | 3,936.1 μs |  1.00 |    0.01 |
 * |               |                     |            |           |           |            |       |         |
 * | PlainSubtract |                 Off | 3,943.2 μs |  45.63 μs |  35.62 μs | 3,942.8 μs |  1.00 |    0.00 |
 * | UnitsSubtract |                 Off | 3,923.3 μs |  36.78 μs |  30.71 μs | 3,913.5 μs |  1.00 |    0.01 |
 * |               |                     |            |           |           |            |       |         |
 * | PlainMultiply |                 Off | 4,272.3 μs | 181.76 μs | 530.20 μs | 3,963.5 μs |  1.00 |    0.00 |
 * | UnitsMultiply |                 Off | 3,991.6 μs |  78.06 μs | 111.96 μs | 3,940.4 μs |  0.91 |    0.11 |
 * |               |                     |            |           |           |            |       |         |
 * |   PlainDivide |                 Off | 4,253.8 μs |  53.83 μs |  42.03 μs | 4,259.3 μs |  1.00 |    0.00 |
 * |   UnitsDivide |                 Off | 4,255.8 μs |  59.52 μs | 147.13 μs | 4,223.9 μs |  1.00 |    0.04 |
 * |               |                     |            |           |           |            |       |         |
 * |  PlainConvert |                 Off | 3,981.1 μs | 184.07 μs | 542.74 μs | 3,658.5 μs |  1.00 |    0.00 |
 * |  UnitsConvert |                 Off | 3,654.7 μs |  52.92 μs |  83.93 μs | 3,632.0 μs |  0.93 |    0.12 |
 * |               |                     |            |           |           |            |       |         |
 * |  PlainMixture |                 Off | 8,406.4 μs |  64.93 μs |  63.77 μs | 8,418.0 μs |  1.00 |    0.00 |
 * |  UnitsMixture |                 Off | 8,447.1 μs | 136.76 μs | 162.80 μs | 8,385.6 μs |  1.01 |    0.03 |
 * |               |                     |            |           |           |            |       |         |
 * |   PlainBullet |                 Off |   279.9 μs |   2.85 μs |   2.66 μs |   280.4 μs |  1.00 |    0.00 |
 * |   UnitsBullet |                 Off |   280.1 μs |   1.82 μs |   1.70 μs |   280.8 μs |  1.00 |    0.01 |
 * 
 * // * Warnings *
 * MultimodalDistribution
 *   Arithmetic.PlainConvert: Default -> It seems that the distribution can have several modes (mValue = 2.84)
 * 
 * Run time: 00:06:45 (405.81 sec), executed benchmarks: 14
 * 
 * ...
 * ...
 * ...
 * ...
 * 
 * |        Method | DimensionalAnalysis |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |
 * |-------------- |-------------------- |------------:|----------:|----------:|------------:|------:|--------:|
 * |      PlainAdd |                  On |  3,976.3 μs |  69.83 μs | 106.63 μs |  3,956.2 μs |  1.00 |    0.00 |
 * |      UnitsAdd |                  On |  7,337.8 μs |  59.94 μs |  50.05 μs |  7,346.6 μs |  1.85 |    0.03 |
 * |               |                     |             |           |           |             |       |         |
 * | PlainSubtract |                  On |  4,464.9 μs | 202.52 μs | 574.51 μs |  4,241.1 μs |  1.00 |    0.00 |
 * | UnitsSubtract |                  On |  8,046.9 μs | 338.02 μs | 991.36 μs |  7,376.6 μs |  1.81 |    0.27 |
 * |               |                     |             |           |           |             |       |         |
 * | PlainMultiply |                  On |  3,938.8 μs |  56.32 μs |  47.03 μs |  3,930.7 μs |  1.00 |    0.00 |
 * | UnitsMultiply |                  On |  7,496.0 μs |  97.81 μs | 116.44 μs |  7,451.8 μs |  1.91 |    0.05 |
 * |               |                     |             |           |           |             |       |         |
 * |   PlainDivide |                  On |  4,257.0 μs |  69.98 μs |  77.78 μs |  4,230.7 μs |  1.00 |    0.00 |
 * |   UnitsDivide |                  On |  7,073.0 μs |  75.21 μs |  83.60 μs |  7,042.4 μs |  1.66 |    0.02 |
 * |               |                     |             |           |           |             |       |         |
 * |  PlainConvert |                  On |  3,931.0 μs |  32.32 μs |  25.24 μs |  3,923.1 μs |  1.00 |    0.00 |
 * |  UnitsConvert |                  On |  6,766.7 μs |  44.23 μs |  43.44 μs |  6,754.8 μs |  1.72 |    0.02 |
 * |               |                     |             |           |           |             |       |         |
 * |  PlainMixture |                  On |  8,433.4 μs |  37.15 μs |  31.02 μs |  8,422.7 μs |  1.00 |    0.00 |
 * |  UnitsMixture |                  On | 36,860.2 μs | 321.24 μs | 284.77 μs | 36,922.7 μs |  4.37 |    0.03 |
 * |               |                     |             |           |           |             |       |         |
 * |   PlainBullet |                  On |    282.9 μs |   1.49 μs |   1.32 μs |    283.4 μs |  1.00 |    0.00 |
 * |   UnitsBullet |                  On |  1,713.9 μs |  11.24 μs |   8.78 μs |  1,716.2 μs |  6.06 |    0.05 |
 * 
 * 
 * // * Legends *
 *   DimensionalAnalysis : Value of the 'DimensionalAnalysis' parameter
 *   Mean                : Arithmetic mean of all measurements
 *   Error               : Half of 99.9% confidence interval
 *   StdDev              : Standard deviation of all measurements
 *   Median              : Value separating the higher half of all measurements (50th percentile)
 *   Ratio               : Mean of the ratio distribution ([Current]/[Baseline])
 *   RatioSD             : Standard deviation of the ratio distribution ([Current]/[Baseline])
 *   1 μs                : 1 Microsecond (0.000001 sec)
 * 
 * Run time: 00:08:18 (498.2 sec), executed benchmarks: 14
 *  
 */
