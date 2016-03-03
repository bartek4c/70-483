using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var covariance = new Covariance();

            var ints = new MyList<int>(10);
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            Console.WriteLine(ints.Count);

            var doubles = new MyList<double>(10);
            doubles.Add(1.15);
            doubles.Add(2.20);
            doubles.Add(3.25);
            Console.WriteLine(doubles.Count);

            var ints_c = new MyConstrainedList<int>(10);
            ints_c.Add(1);
            ints_c.Add(2);
            ints_c.Add(3);
            Console.WriteLine(ints_c.Count);

            var doubles_c = new MyConstrainedList<double>(10);
            doubles_c.Add(1.15);
            doubles_c.Add(2.20);
            doubles_c.Add(3.25);
            Console.WriteLine(doubles_c.Count);

            var storer = new Storer<Temperature, MyList<int>>();

            Console.ReadLine();
        }
    }

    class MyList<T>
    {
        int _count = 0;
        T[] _values;

        public MyList(int capacity)
        {
            _values = new T[capacity];
        }

        public void Add(T value)
        {
            _values[_count] = value;
            _count++;
        }

        public T this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public int Count { get { return _count; } }
    }

    class MyConstrainedList<T> where T : new()
    {
        int _count = 0;
        T[] _values;

        public MyConstrainedList(int capacity)
        {
            _values = new T[capacity];
        }

        public void Add(T value)
        {
            _values[_count] = value;
            _count++;
        }

        public T this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public int Count { get { return _count; } }
    }

    class Storer<T, U> where T : IComparable, IEnumerable where U : class
    {

    }

    class Temperature : IComparable, IEnumerable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    interface IMyList<T>
    {
        void Add(T value);
    }

    class Test1<T> : IMyList<T>
    {
        public void Add(T value)
        {
            throw new NotImplementedException();
        }
    }

    class Test2 : IMyList<int>
    {
        public void Add(int value)
        {
            throw new NotImplementedException();
        }
    }

    class Test3 : Test1<int>, IMyList<int>
    {
        void IMyList<int>.Add(int value)
        {
            throw new NotImplementedException();
        }
    }
}
