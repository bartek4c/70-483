using System;
using System.Collections;
using System.Collections.Generic;

namespace LinqToObjects
{
    public class EveryOtherEnumerator<T> : IEnumerable<T>
    {
        private IEnumerable<T> _baseEnumerable;

        public EveryOtherEnumerator(IEnumerable<T> baseEnumerable)
        {
            _baseEnumerable = baseEnumerable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = 0;
            foreach (T value in _baseEnumerable)
            {
                if (count % 2 == 0)
                {
                    yield return value;
                }
                count++;
            }
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
