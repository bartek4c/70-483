using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsExpressions.DelegatesDemo
{
    public class EmployeeFilterAge
    {
        int _age;
        public EmployeeFilterAge(int age)
        {
            _age = age;
        }
        //predicate method - receives one parameter and returns true or false
        public bool OlderThan(Employee employee)
        {
            return employee._age > _age;
        }

        public bool OtherOlderThan(Employee employee)
        {
            return employee._age > 29;
        }
    }
}
