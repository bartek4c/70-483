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


            var test = typeof(Program);
            var test2 = new Program().GetType();

            Console.ReadLine();
        }
    }

    public abstract class BaseClass
    {
        public virtual int PropertyOne { get; set; }
        public abstract int Propertytwo { get; set; }
        public int PropertyThree { get; set; }
    }

    public class DerivedClass : BaseClass
    {
        public new int PropertyThree { get; set; }

        public override int PropertyOne
        {
            get
            {
                return base.PropertyOne;
            }
            set
            {
                base.PropertyOne = value;
            }
        }

        public override int Propertytwo
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
