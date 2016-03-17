using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqToObjects
{
    public class TestProgram
    {
        public TestProgram()
        {
            var student = new Student()
            {
                Name = "Bartosz",
                Assignments = new List<Assignment>() {
                    new Assignment { Name = "Maths", Score = 4 },
                    new Assignment { Name = "Biology", Score = 6 }
                }
            };

            //mine
            double average1 = student.Assignments.MyAverage(a => a.Score);
            //linq
            double average2 = student.Assignments.Average(a => a.Score);
            //mine
            var min = 1;
            int greaterThan = student.Assignments.HowManyAboveMinimal(x => x.Score > min);

            Console.WriteLine("How many greater than {0} -> {1}", min, greaterThan);
            Console.WriteLine("Average score for {0} is {1}/{2}", student.Name, average1, average2);
            Console.Read();

            Func<string, int, bool> predicate = (x, y) => x.Length == y;
        }
    }

    public class Student
    {
        public Student()
        {
            Assignments = new List<Assignment>();
        }
        public List<Assignment> Assignments { get; set; }
        public string Name { get; set; }
    }

    public class Assignment
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public static class ExtensionMethods
    {
        public static double MyAverage<T>(this IEnumerable<T> values, Func<T, int> selector)
        {
            double sum = 0;
            int count = 0;
            foreach (T value in values)
            {
                sum += selector(value);
                count++;
            }
            return sum / count;
        }

        public static int HowManyAboveMinimal<T>(this IEnumerable<T> values, Func<T, bool> veryfier)
        {
            int count = 0;
            foreach (T value in values)
            {
                if (veryfier(value))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
