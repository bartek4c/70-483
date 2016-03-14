using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.JamieKing
{
    public class PairDifferent<T, U>
    {
        public T First { get; set; }
        public U Second { get; set; }
        public override string ToString()
        {
            return "< " + First + " , " + Second + " >";
        }
    }

    public class PairTheSame<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
        public override string ToString()
        {
            return "< " + First + " , " + Second + " >";
        }
    }


    class MainClass
    {
        static void DoSomething<T>(T arg) { }

        //second entry point
        static void Main()
        {
            //Type inference example !!!
            DoSomething("Bartosz");
            DoSomething<string>("Bartosz");
            DoSomething(5);
            DoSomething<int>(5);

            var pairStringInt = new PairDifferent<string, int> { First = "bob", Second = 2 };
            var pairIntInt = new PairTheSame<int> { First = 2, Second = 3 };
            
            Console.WriteLine(pairStringInt.ToString());
            Console.WriteLine(pairIntInt.ToString());
            Console.Read();
        }
    }
}
