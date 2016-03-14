using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = 2;
            int? j = null;

            int? test = i - j;

            var roman1 = new RomanNumeral(12);
            var roman2 = new RomanNumeral(125);

            Console.WriteLine("Minus: {0}", -roman1);
            Console.WriteLine("Increment: {0}", ++roman1);
            Console.WriteLine("Addition: {0}", roman1 + roman2);
            Console.Read();
        }
    }

    struct RomanNumeral
    {
        private int _value;
        public RomanNumeral(int value)
        {
            _value = value;
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static RomanNumeral operator -(RomanNumeral roman)
        {
            return new RomanNumeral(-roman._value);
        }
        public static RomanNumeral operator +(RomanNumeral roman1, RomanNumeral roman2)
        {
            return new RomanNumeral(roman1._value + roman2._value);
        }
        public static RomanNumeral operator ++(RomanNumeral roman)
        {
            return new RomanNumeral(roman._value + 1);
        }
    }
}
