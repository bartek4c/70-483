using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    public static class ExtensionMethods
    {
        public static string UpperSecondLetter(this string val)
        {
            if (val.Length > 0)
            {
                char[] array = val.ToCharArray();
                for(var i = 0; i < array.Length; i++)
                {
                    if (i == 1)
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                    else
                    {
                        array[i] = char.ToLower(array[i]);
                    }
                }
                return new string(array);
            }
            return val;
        }

        public static string ExtractHashes(this string val)
        {
            return val.Replace("#", "");
        }

        public static void TallWindows(this House house)
        {
            for (var i = 0; i < 3; i++)
            {
                house.Windows.Add(new Window(true));
            }
        }

        public static void ShortWindows(this House house)
        {
            for (var i = 0; i < 3; i++)
            {
                house.Windows.Add(new Window(false));
            }
        }
    }
}
