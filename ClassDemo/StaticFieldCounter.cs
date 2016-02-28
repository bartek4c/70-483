using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class StaticFieldCounter
    {
        static StaticFieldCounter()
        {
            Console.WriteLine("StaticFieldCounter initializing".ToUpper());
        }

        public StaticFieldCounter()
        {
            InstanceCount++;
        }

        public static int InstanceCount = 0;
    }

}
