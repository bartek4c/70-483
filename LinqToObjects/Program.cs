using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestProgram();

            List<int> numbers = new List<int>() { 2, 4, 5, 8, 23, 45 };

            var t1 = numbers.Max();
            var t2 = numbers.Sum();


            var eoe = new EveryOtherEnumerator<int>(numbers); //IEnumerator - run through for each to process
            foreach (var item in eoe)
            {
                Console.WriteLine(item);
            }
            Console.Read();

            List<Student> students = new List<Student>();
            List<Assignment> assignements = new List<Assignment>();

            var joined = students.Join(assignements,
                s => s.Name,
                a => a.Name,
                (s, a) => new
                    {
                        Name = s.Name,
                        Score = a.Score,
                        Assignments = s.Assignments // <-- this doesn't make sense!!!
                    }
                );
        }
    }
}
