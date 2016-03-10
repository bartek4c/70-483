using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsExpressions.DelegatesDemo
{
    public class SimpleExample
    {
        public SimpleExample(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string UppercaseFirst(string input)
        {
            var text = char.ToUpper(input[0]) + input.Substring(1).ToLower() + "_" + Name;
            Console.WriteLine(text);
            return text;
        }
        public string UppercaseLast(string input)
        {
            var text = input.Substring(0, input.Length - 1).ToLower() + char.ToUpper(input[input.Length - 1]) + "_" + Name;
            Console.WriteLine(text);
            return text;
        }
    }
}
