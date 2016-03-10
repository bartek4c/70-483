using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsExpressions.DelegatesDemo
{
    public class Employee
    {
        //fields
        public string _name;
        public int _id;
        public int _age;
        public int _salary;
        
        //constructors
        public Employee(string name, int id)
        {
            _name = name;
            _id = id;
        }
        public Employee(string name, int age, int salary)
        {
            _name = name;
            _age = age;
            _salary = salary;
        }

        //methods
        public static int CompareName(object obj1, object obj2)
        {
            Employee emp1 = (Employee)obj1;
            Employee emp2 = (Employee)obj2;
            
            return (String.Compare(emp1._name, emp2._name));
        }
        public static int CompareId(object obj1, object obj2)
        {
            Employee emp1 = (Employee)obj1;
            Employee emp2 = (Employee)obj2;

            if (emp1._id > emp2._id)
            {
                return 1;
            }
            else if (emp1._id < emp2._id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    
}
