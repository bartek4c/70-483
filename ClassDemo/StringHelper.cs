using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public static class StringHelper
    {
        public static List<string> ExtractFields(this string fieldString)
        {
            string[] fieldArray = fieldString.Split(',');
            List<string> fields = new List<string>();
            foreach (var f in fieldArray)
            {
                fields.Add(f.Replace("#", ""));
            }
            return fields;
        }
    }
}
