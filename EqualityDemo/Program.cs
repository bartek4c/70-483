using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityDemo
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

            Console.Read();
        }
    }

    public class Employee : IEquatable<Employee>
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

        
    }
}
