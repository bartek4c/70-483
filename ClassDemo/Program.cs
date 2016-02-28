using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //EXTENSION METHODS DEMO

            string test = "#one#,#two#,three#";
            List<string> fields = test.ExtractFields();
            foreach (var f in fields)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("---------------------------------");

            Color red = Color.Red;
            Console.WriteLine("red");
            Color blue = Color.Blue;
            Console.WriteLine("blue");
            Color Green = Color.Green;
            Console.WriteLine("green");

            Console.WriteLine("---------------------------------");

            StaticFieldCounter sfc1 = new StaticFieldCounter();
            Console.WriteLine("{0}", StaticFieldCounter.InstanceCount);
            StaticFieldCounter sfc2 = new StaticFieldCounter();
            Console.WriteLine("{0}", StaticFieldCounter.InstanceCount);
            StaticFieldCounter sfc3 = new StaticFieldCounter();
            Console.WriteLine("{0}", StaticFieldCounter.InstanceCount);

            Console.WriteLine("---------------------------------");

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            //var e = new Engineer("Hank", 12.30F);
            var e = new ChemicalEngineer("Hank", 12.30F);
            var c = new CivilEngineer("John", 15.10F);
            var cf = new CivilEngineer("John", 15.10F, true);

            Console.WriteLine("Type name: {0} | Rate: £{1} for 30 min", e.TypeName(), e.CalculateCharge(.5F));
            Console.WriteLine("Type name: {0} | Rate: £{1} for 30 min", c.TypeName(), c.CalculateCharge(.5F));
            Console.WriteLine("Type name: {0} | Rate: £{1} for 30 min", cf.TypeName(), cf.CalculateCharge(.5F));

            Console.WriteLine("---------------------------------");

            var engineers = new Engineer[2];
            //engineers[0] = new Engineer("Hank", 12.30F);
            engineers[0] = new ChemicalEngineer("Hank", 12.30F);
            engineers[1] = new CivilEngineer("John", 15.10F);

            Console.WriteLine("Type name: {0} | Rate: £{1} for 30 min", engineers[0].TypeName(), engineers[0].CalculateCharge(.5F));
            Console.WriteLine("Type name: {0} | Rate: £{1} for 30 min", engineers[1].TypeName(), engineers[1].CalculateCharge(.5F));

            Console.WriteLine("---------------------------------");

            
            var a = new Base[2];
            a[0] = new Base();
            a[1] = new Derived();
            a[0].Process(12);
            a[1].Process(12);

            Derived d = new Derived();
            short i = 12;
            d.Process(i);
            ((Base)d).Process(i);

            Console.ReadLine();
        }  

        static void UnhandledExceptionHandler (object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception) e.ExceptionObject;

            System.Diagnostics.Debugger.Break();
        }

        
    }

    #region inheritance
    
    abstract class Engineer
    {
        public Engineer(string name, float billingRate)
        {
            _name = name;
            _billingRate = billingRate;
        }

        public Engineer(string name, float billingRate, bool flatRate)
        {
            _name = name;
            _billingRate = flatRate ? 3.2F : billingRate;
        }

        public virtual float CalculateCharge(float hours)
        {
            return (hours * _billingRate);
        }

        public abstract string TypeName();
        //{
        //    return "Engineer";
        //}

        private string _name;
        protected float _billingRate; 
    }

    class ChemicalEngineer : Engineer
    {
        public ChemicalEngineer(string name, float billingRate)
            : base(name, billingRate)
        {
              
        }

        public override string TypeName()
        {
            return "Chemical Engineer";
        }
    }

    class CivilEngineer : Engineer
    {
        public CivilEngineer(string name, float billingRate)
            : base(name, billingRate)
        {

        }

        public CivilEngineer(string name, float billingRate, bool useFlatRate)
            : base(name, billingRate, useFlatRate)
        {

        }

        public override float CalculateCharge(float hours)
        {
            if (hours < 1.0F)
            {
                hours = 1.0F;
            }
            return (hours * _billingRate);
        }

        public override string TypeName()
        {
            return "Civil Engineer";
        }
    }

    #endregion

    #region overloading

    public class Base
    {
        public void Process(short value)
        {
            Console.WriteLine("Base.Process(short): {0}", value);
        }
    }

    public class Derived : Base
    {
        public void Process(int value)
        {
            Console.WriteLine("Derived.Process(int): {0}", value);
        }

        public void Process(string value)
        {
            Console.WriteLine("Derived.Process(string): {0}", value);
        }
    }

    #endregion

    #region Extension Methods

    

    #endregion
}
