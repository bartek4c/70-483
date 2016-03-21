using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityAndComparabilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee("Anna", 1);
            var e2 = new Employee("Julia", 1);
            var e3 = new Employee("Anna", 3);

            Console.WriteLine("Equals: {0}", e1.Equals(e2));
            Console.WriteLine("==: {0}", e1 == e2);
            Console.WriteLine("!=: {0}", e1 != e3);

            Console.WriteLine("###################################");

            var emps = new List<Employee>() {
                new Employee("Bartosz", 2),
                new Employee("Anna", 23),
                new Employee("Julia", 1)
            };
            foreach (var e in emps)
            {
                Console.WriteLine("{0} - {1}", e.Name, e.Id);
            }

            Console.WriteLine("Sorted by name below:");

            emps.Sort(new SortEmployeeByName());

            foreach (var e in emps)
            {
                Console.WriteLine("{0} - {1}", e.Name, e.Id);
            }

            Console.WriteLine("Sorted by id below:");

            emps.Sort();

            foreach (var e in emps)
            {
                Console.WriteLine("{0} - {1}", e.Name, e.Id);
            }

            Console.WriteLine("Using lambda below below:");

            //Comparison<T> Delegate
            emps.Sort((x, y) => String.Compare(x.Name, y.Name));
            //Methods matching delegate above
            var del = new Comparison<Employee>(Extensions.CompareEmployeesByName2);
            emps.Sort(del);
            //passing function directly
            emps.Sort(Extensions.CompareEmployeesByName2);

            //special comparer - to ignore case sensitivity
            new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

            var test = new ObservableCollection<Employee>();
            test.Add(new Employee("bartosz", 1));
            test.Add(new Employee("anna", 2));

            var e0 = emps.FirstOrDefault();
            var test2 = e0.TestExtension(e2);
            
            foreach (var e in emps)
            {
                Console.WriteLine("{0} - {1}", e.Name, e.Id);
            }

            Console.Read();
        }
    }

    public class Employee : IEquatable<Employee>, IComparable<Employee>
    {
        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public int Id { get; set; }

        #region overrides

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Id);
        }
        //old method - not specially useful since passes object
        public override bool Equals(object obj)
        {
            var e = (Employee)obj;
            return this.Id == e.Id;
        }

        #endregion

        #region Equality

        bool IEquatable<Employee>.Equals(Employee other)
        {
            return Equals(other);
        }

        //compare onbly by id
        public static bool operator ==(Employee e1, Employee e2)
        {
            if (e1.Id == e2.Id)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Employee e1, Employee e2)
        {
            if (e1.Name != e2.Name)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Comparability

        int IComparable<Employee>.CompareTo(Employee emp)
        {
            if (this.Id > emp.Id) return 1;
            if (this.Id < emp.Id) return -1;
            return 0;
        }

        #endregion

        
    }

    public static class Extensions
    {
        //method matching Comparison<T> Delegate
        public static int CompareEmployeesByName2(Employee e1, Employee e2)
        {
            return String.Compare(e1.Name, e2.Name);
        }

        public static int TestExtension(this Employee e1, Employee e2)
        {
            return 1;
        }
    }

    public class SortEmployeeByName : IComparer<Employee>
    {
        public int Compare(Employee e1, Employee e2)
        {
            return String.Compare(e1.Name, e2.Name);
        }
    }
}
