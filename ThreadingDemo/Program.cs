using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 50);
            Console.SetBufferSize(40, 50);

            Val val = new Val();
            for (int threadNum = 0; threadNum < 5; threadNum++)
            {
                Thread thread = new Thread(new ThreadStart(val.DoBump));
                thread.Start();
            }

            var single1 = Singleton1.Instance;
            single1.Name = "Name";
            single1.Id = 1;

            var single2 = Singleton1.Instance;

            Console.Read();
        }
    }

    class Val
    {
        int number = 1;

        public void Bump()
        {
            //missing try-finally
            //Monitor.Enter(this);
            //int temp = number;
            //Thread.Sleep(1);
            //number = temp + 2;
            //Console.WriteLine("number = {0}", number);
            //Monitor.Exit(this);

            //will be translated into try-finally
            lock (this)
            {
                int temp = number;
                Thread.Sleep(1);
                number = temp + 2;
                Console.WriteLine("number = {0}", number);
            }
        }

        public override string ToString()
        {
            return number.ToString();
        }

        public void DoBump()
        {
            for (int i = 0; i < 5; i++)
            {
                Bump();
            }
        }
    }

    public class Singleton1
    {
        private static readonly Singleton1 _instance = new Singleton1();
        private Singleton1()
        {

        }

        public static Singleton1 Instance
        {
            get { return _instance; }
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}
