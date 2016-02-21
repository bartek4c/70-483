using System;

namespace ClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadLine();
        }  
    }

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
}
