using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 5;
            a = a % (double)1.5;
            Console.WriteLine("% : {0}", a);

            int k = 5;
            int value1 = k++;
            int value2 = ++k;

            string test1 = String.Format("{0}, {1}", value1, value2);



            var test = typeof(Program);
            var test2 = new Program().GetType();

            Console.ReadLine();
        }
    }
}
