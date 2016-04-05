using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            var opr1 = new SlowOperation();
            var opr2 = new SlowOperation();

            //comment in whichever you want to test
            //ExampleWithValueNotReturned(sw, opr1, opr2);
            ExampleWithValueReturned_Standard(sw, opr1, opr2);
            //ExampleWithValueReturned_Async(sw, opr1, opr2);
            //ExampleWithValueReturned_Parallel(sw, opr1, opr2);
            ExampleWithValueReturned_PLINQ(sw, opr1, opr2);

            Console.ReadLine();
        }

        static void ExampleWithValueNotReturned(Stopwatch sw, SlowOperation opr1, SlowOperation opr2)
        {
            //inline processing
            Console.WriteLine("Started processing INLINE. Start: {0}", sw.Elapsed);
            sw.Start();
            opr1.PerformSlowOperation(1);
            opr2.PerformSlowOperation(2);
            Console.WriteLine("Stopped processing INLINE. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");

            //TASK - cannot wait for the return value, since it doesn't make sense to run async and then wait
            Console.WriteLine("Started processing using TASK. Start: {0}", sw.Elapsed);
            sw.Start();

            //initialize and start in one command
            Task.Factory.StartNew(() => opr1.PerformSlowOperation(1));
            Task.Factory.StartNew(() => opr2.PerformSlowOperation(2));

            //initialize and then start
            //var task1 = new Task(() => opr1.PerformSlowOperation(1));
            //var task2 = new Task(() => opr2.PerformSlowOperation(2));
            //task1.Start();
            //task2.Start();

            Console.WriteLine("Stopped processing using TASK. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");
        }

        static void ExampleWithValueReturned_Standard(Stopwatch sw, SlowOperation opr1, SlowOperation opr2)
        {
            //inline processing
            Console.WriteLine("Started processing INLINE. Start: {0}", sw.Elapsed);
            sw.Start();

            Console.WriteLine("1 Step0: {0}", sw.Elapsed);
            var sum1_1 = opr1.PerformSlowOperation(1, true);
            Console.WriteLine("1 Step1: {0}", sw.Elapsed);
            var sum2_1 = opr2.PerformSlowOperation(2, true);
            Console.WriteLine("1 Step2: {0}", sw.Elapsed);

            Console.WriteLine("Operations sum is: {0}", (sum1_1 + sum2_1).ToString("0.##"));
            Console.WriteLine("Stopped processing INLINE. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");
        }

        static async void ExampleWithValueReturned_Async(Stopwatch sw, SlowOperation opr1, SlowOperation opr2)
        {
            //ASYNC AWAIT - where you don't want to block the thread
            Console.WriteLine("Started processing ASYNC. Start: {0}", sw.Elapsed);
            sw.Start();

            Console.WriteLine("2 Step0: {0}", sw.Elapsed);
            var sum1_2 = Task<double>.Factory.StartNew(() => opr1.PerformSlowOperation(1, true));
            Console.WriteLine("2 Step1: {0}", sw.Elapsed);
            var sum2_2 = Task<double>.Factory.StartNew(() => opr2.PerformSlowOperation(1, true));
            Console.WriteLine("2 Step2: {0}", sw.Elapsed);

            var sum = await Task.WhenAll(sum1_2, sum2_2);

            Console.WriteLine("Operations sum is: {0}", (sum1_2.Result + sum2_2.Result).ToString("0.##"));
            Console.WriteLine("Stopped processing ASYNC. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");
        }

        static ConcurrentBag<double> _sumOfSums = new ConcurrentBag<double>();
        static void ExampleWithValueReturned_Parallel(Stopwatch sw, SlowOperation opr1, SlowOperation opr2)
        {
            //PARALLEL - using parallel foreach loop

            List<SlowOperation> oprs = new List<SlowOperation>() {
                opr1,
                opr2
            };
                        
            Console.WriteLine("Started processing PARALLEL. Start: {0}", sw.Elapsed);
            sw.Start();

            Parallel.ForEach<SlowOperation>(oprs, (opr) =>
            {
                var value = opr.PerformSlowOperation(1, true);
                _sumOfSums.Add(value);                
            });           
            
            Console.WriteLine("Operations sum is: {0}", (_sumOfSums.Sum()).ToString("0.##"));
            Console.WriteLine("Stopped processing PARALLEL. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");
        }


        static void ExampleWithValueReturned_PLINQ(Stopwatch sw, SlowOperation opr1, SlowOperation opr2)
        {
            //PLINQ - using parallel linq

            List<SlowOperation> oprs = new List<SlowOperation>() {
                opr1,
                opr2
            };

            Console.WriteLine("Started processing PLINQ. Start: {0}", sw.Elapsed);
            sw.Start();

            var sum = oprs
                .AsParallel<SlowOperation>()
                .Select(opr => opr.PerformSlowOperation(1, true))
                .Sum();

            Console.WriteLine("Operations sum is: {0}", (sum).ToString("0.##"));
            Console.WriteLine("Stopped processing PLINQ. Stop: {0}", sw.Elapsed);
            sw.Stop();

            sw.Reset();
            Console.WriteLine("");
        }
    }
}
