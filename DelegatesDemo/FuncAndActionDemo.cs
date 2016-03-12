using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    /// <summary>
    /// Both Func and Action are common generic delegates used in programming with generics!
    /// </summary>
    public class FuncAndActionDemo<T, U>
    {
        public void Run()
        {
            //Func is a generic delegate that takes up to 16 arguments and return a value
            Func<int, string, bool> f = MyFuncTestMethod;
            //Action is a generic delegate that takes up to 16 arguments and DOESN't return a value
            Action<int, string> a = MyActionTestMethod;
        }

        /// <summary>
        /// Exemplary func method
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void MyActionTestMethod(int arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exemplary action method
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private bool MyFuncTestMethod(int arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        
    }
}
