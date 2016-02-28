using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string val1 = "SwdljfaJHGgHJGhlhjjkKGkgkK";
            Console.WriteLine(val1.UpperSecondLetter());

            string val2 = "##test##";
            Console.WriteLine(val2.ExtractHashes());

            var houseWithTallWindows = new House();
            houseWithTallWindows.TallWindows();
            Console.WriteLine("First house window size {0}x{1}",
                houseWithTallWindows.Windows.FirstOrDefault().Height,
                houseWithTallWindows.Windows.FirstOrDefault().Weight);

            var houseWithShortWindows = new House();
            houseWithShortWindows.ShortWindows();
            Console.WriteLine("Second house window size {0}x{1}",
                houseWithShortWindows.Windows.FirstOrDefault().Height,
                houseWithShortWindows.Windows.FirstOrDefault().Weight);

            Console.ReadLine();

            //hidden method in interface - separate from extension methods demo
            Employee e = new Employee();
            var ie = (IRenderIcon)e;
            ie.DragIcon(1, 1);
            
        }
    }

    interface IRenderIcon
    {
        void DrawIcon(int x, int y);
        void DragIcon(int x, int y);
        void ResizeIcon(int x, int y);
    }

    class Employee : IRenderIcon
    {
        public Employee()
        {

        }

        public Employee(int id, string name)
        {
            _id = id;
            _name = name;
        }

        private int _id;
        private string _name;

        void IRenderIcon.DrawIcon(int x, int y)
        {
            throw new NotImplementedException();
        }

        void IRenderIcon.DragIcon(int x, int y)
        {
            throw new NotImplementedException();
        }

        void IRenderIcon.ResizeIcon(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
