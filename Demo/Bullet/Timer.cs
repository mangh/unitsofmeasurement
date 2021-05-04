using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Bullet
{
    public class Timer<TArg, TResult>
    {
        protected readonly Stopwatch watch;
        protected Func<TArg, TArg, TArg, List<TResult>> compute;
        public double elapsed;

        public Timer(Func<TArg, TArg, TArg, List<TResult>> computation)
        {
            watch = new Stopwatch();
            compute = computation;
        }

        public List<TResult> WatchComputation(TArg min, TArg max, TArg delta)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Restart();

            List<TResult> result = compute(min, max, delta);

            watch.Stop();
            elapsed = watch.ElapsedTicks;

            return result;
        }
    }
}
