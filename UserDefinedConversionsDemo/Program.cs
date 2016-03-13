using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedConversionsDemo
{
    /// <summary>
    /// UserDefinedConversions - something that automapper resolves?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12;
            RomanNumeral numeral = new RomanNumeral(s);

            Console.WriteLine("Roman as int: {0}", (int)numeral);
            Console.WriteLine("Roman as string: {0}", (string)numeral);

            s = 165;
            numeral = (RomanNumeral) s;

            Console.WriteLine("Roman as int: {0}", (int)numeral);
            Console.WriteLine("Roman as string: {0}", (string)numeral);

            Console.ReadLine();

            //short s2 = numeral;
        }
    }

    struct RomanNumeral
    {
        private short _value;
        public RomanNumeral(short value)
        {
            if (value > 5000)
            {
                throw (new ArgumentOutOfRangeException());
            }
            _value = value;
        }

        //CONV 1
        //conversion from short to roman numeral
        //explicit because might not always succeeed
        public static explicit operator RomanNumeral(short value)
        {
            RomanNumeral retval;
            retval = new RomanNumeral(value);
            return retval;
        }

        //CONV 2
        //conversion from short to roman numeral
        //implicit because it'll be always successful
        public static implicit operator short(RomanNumeral roman)
        {
            return roman._value;
        }

        //For some reason this string method always has to sit above conv3
        static string NumberString(ref int value, int magnitude, char letter)
        {
            StringBuilder numberString = new StringBuilder();
            while (value >= magnitude)
            {
                value -= magnitude;
                numberString.Append(letter);
            }
            return numberString.ToString();
        }

        //CONV 3
        //conversion to string
        public static implicit operator string(RomanNumeral roman)
        {
            int temp = roman._value;
            StringBuilder retval = new StringBuilder();

            retval.Append(RomanNumeral.NumberString(ref temp, 1000, 'M'));
            retval.Append(RomanNumeral.NumberString(ref temp, 500, 'D'));
            retval.Append(RomanNumeral.NumberString(ref temp, 100, 'C'));
            retval.Append(RomanNumeral.NumberString(ref temp, 50, 'L'));
            retval.Append(RomanNumeral.NumberString(ref temp, 10, 'X'));
            retval.Append(RomanNumeral.NumberString(ref temp, 5, 'V'));
            retval.Append(RomanNumeral.NumberString(ref temp, 1, 'I'));

            return retval.ToString();
        }
    }
}
