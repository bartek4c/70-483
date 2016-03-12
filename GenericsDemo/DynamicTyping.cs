using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class DynamicTyping
    {
        /// <summary>
        /// This won't work because + cannot be executed against T and T, since we dont know their types
        /// </summary>
        /*
        public static T Add<T>(T first, T second)
        {
            return first + second;
        }
        */

        public static T Add<T>(T first, T second)
        {
            try
            {
                return (dynamic)first + (dynamic)second;
            }
            catch (Exception e)
            {
                return (dynamic)null;
            }
            
        }
    }

    
}
