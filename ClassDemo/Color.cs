using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class Color
    {
        public Color(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        int _red;
        int _green;
        int _blue;

        public static readonly Color Red;
        public static readonly Color Green;
        public static readonly Color Blue;

        static Color()
        {
            Console.WriteLine("new Color class instance".ToUpper());

            Red = new Color(255, 0, 0);
            Green = new Color(0, 255, 0);
            Blue = new Color(0, 0, 255);
        }
    }
}
