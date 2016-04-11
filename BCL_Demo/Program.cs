using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCL_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "chrome.exe";

            Process.Start(startInfo);

            #region number formatting

            ///STANDARD FORMAT

            //currency
            Console.WriteLine("{0:C}", 333423.456);

            //decimal
            Console.WriteLine("{0:D7}", 456);

            //scientific
            Console.WriteLine("{0:E10}", 1365.4585);

            //fixed-point
            Console.WriteLine("{0:F}", 458.56565656);
            Console.WriteLine("{0:F4}", 458.56565656);

            //number
            Console.WriteLine("{0:N}", 4545.4545);

            //hexadecimal
            Console.WriteLine("{0:X}", 255);

            ///CUSTOM FORMAT
            
            //digit or zero placeholder
            Console.WriteLine("{0:000}", 55);

            //digit or space placeholder
            Console.WriteLine("{0:###}", 56);

            //decimal point
            Console.WriteLine("{0:##.00}", 54.5);

            //group separator
            Console.WriteLine("{0:##,000.00}", 45956985.458547);

            //percent notation
            Console.WriteLine("{0:##.00 %}", 0.75565);

            #endregion

            #region datetime formatting

            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
            Console.WriteLine(DateTime.Now.ToOADate());

            var now = DateTime.Now;

            Console.WriteLine("{0:D}", now);
            Console.WriteLine("{0:F}", now);
            Console.WriteLine("{0:G}", now);
            Console.WriteLine("{0:T}", now);

            #endregion
        }
    }
}
