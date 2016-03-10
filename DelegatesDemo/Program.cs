using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesEventsExpressions;

namespace DelegatesEventsExpressions.DelegatesDemo
{
    class Program
    {
        public delegate string UppercaseDelegate(string inputString);
        public delegate int CompareItemsCallback(object obj1, object obj2);
        
        public delegate bool AgeExclusion(Employee person);

        static void Main(string[] args)
        {
            ///Simple example
            SimpleExample example = new SimpleExample("Bartosz");
            //Function pointers - del points to UppercaseFirst and then to UppercaseLast
            //IMPORTANT! could create two separate delegates
            var del = new UppercaseDelegate(example.UppercaseFirst);
            del += new UppercaseDelegate(example.UppercaseLast);

            //iterate to get to each delegate separately,
            //then you can wrap them up in try catch block
            //IMPORTANT! won't work with var keyword
            foreach (UppercaseDelegate subDel in del.GetInvocationList())
            {
                try
                {
                    var str = subDel("tEsTDelegate");
                }
                catch (Exception e)
                {
                    //do something here...
                }
            }
            Console.WriteLine("---------------------------");
            //Otherwise only last one will be executed, hence
            //three lines in the output instead of four
            Console.WriteLine(del("tEsTDelegate"));

            Console.WriteLine("--------short start----------------");
            //IMPORTANT! This would work as well
            UppercaseDelegate del2 = example.UppercaseFirst;
            del2 += example.UppercaseLast;
            del2("tEsTDelegate");
            Console.WriteLine("--------short end-----------------");

            ///Book example
            var emp1 = new Employee("Bartosz", 23);
            var emp2 = new Employee("Adam", 24);
            CompareItemsCallback del4 = new CompareItemsCallback(Employee.CompareId);
            var test = del4(emp1, emp2);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Predicate examples:");

            ///Predicate examples
            Predicate<int> isOne = x => x == 1;
            Console.WriteLine(isOne(2));
            Console.WriteLine(isOne(1));

            var employees = new List<Employee>() {
                new Employee("Bartosz", 26, 100),
                new Employee("Adam", 27, 120),
                new Employee("Daniel", 31, 140)
            };

            //LAMBDA !!!!
            var filterByAge = new EmployeeFilterAge(29);
            //FindIndex returns first occurance matching predicate criteria
            //predicate method - receives one parameter and returns true or false
            //List<T>.FindIndex(Predicate<T> match)

            //option 1 - pass delegate
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //CANNOT DO THAT BECAUSE PREDICATE IS A DELEGATE ITSELF
            //https://msdn.microsoft.com/en-us/library/bfcke1bz%28v=vs.110%29.aspx
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //that's why i.e. option 2 works
            AgeExclusion del3 = filterByAge.OlderThan;
            //  int index1 = employees.FindIndex(del3);
            //  Console.WriteLine(index1.ToString());
            //can pass a predicate though
            Predicate<Employee> match = e => e._age > 29;
            //or
            Predicate<Employee> match2 = filterByAge.OlderThan;
            int index1 = employees.FindIndex(match);
            int index1prim = employees.FindIndex(match2);
            Console.WriteLine(index1.ToString() + ", " + index1prim.ToString());

            //option 2 - using method to create predicate
            int index2 = employees.FindIndex(filterByAge.OlderThan);
            Console.WriteLine(index2.ToString());
                        
            //option 3 - using anonymous method instead of predicate
            int index3 = employees.FindIndex(delegate(Employee employee)
            {
                return employee._age > 29;
            });
            Console.WriteLine(index3.ToString());

            //option 4 - using lambda
            int index4 = employees.FindIndex(e => e._age > 29);
            Console.WriteLine(index4.ToString());

            Console.ReadLine();
        }

        
        
        
    }
}
