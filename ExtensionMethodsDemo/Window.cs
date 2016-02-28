using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    public class Window
    {
        public Window()
        {
            Height = 4;
            Weight = 2;
        }

        public Window(bool tall)
        {
            if (tall)
            {
                Height = 8;
                Weight = 2;
            }
            else
            {
                Height = 2;
                Weight = 2;
            }
        }

        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
