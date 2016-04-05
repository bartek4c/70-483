using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    public class SlowOperation
    {
        public void PerformSlowOperation(int id)
        {
            var rand = new Random();
            double sum = 0;

            for (int i = 0; i < 100000000; i++)
            {
                var number = Convert.ToDouble(rand.Next(100)) / 100;
                sum += number;
            }
            /// in async approaches sum might be the same because Random is seeded based on time 
            /// at a low resolution. This is a classic issue and might be considered as an API design error. 
            Console.WriteLine("Finished processing operation no. {0}. Final sum calculated is: {1}", id, sum.ToString("0.##"));
        }

        public double PerformSlowOperation(int id, bool returnValue)
        {
            if (returnValue)
            {
                var rand = new Random();
                double sum = 0;

                for (int i = 0; i < 100000000; i++)
                {
                    //var number = Convert.ToDouble(rand.Next(100)) / 100;
                    double number = 0.4;
                    sum += number;
                }

                return sum;
            }
            return 0;
        }
    }
}
