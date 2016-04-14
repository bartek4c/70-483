using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            MyRow row = new MyRow();
            row.Add(new MyElement("Gumpy"));
            row.Add(new MyElement("Pokey"));

            Console.WriteLine("Initial Value");
            Console.WriteLine("{0}", row);

            //write to binary, read it back
            using (Stream streamWriter = File.Create("MyRow.bin"))
            {
                BinaryFormatter binaryWriter = new BinaryFormatter();
                binaryWriter.Serialize(streamWriter, row);
            }

            MyRow rowBinary = null;
            using (Stream streamReader = File.OpenRead("MyRow.bin"))
            {
                BinaryFormatter binaryReader = new BinaryFormatter();
                rowBinary = (MyRow)binaryReader.Deserialize(streamReader);
            }

            Console.WriteLine("Values after binary serialization");
            Console.WriteLine("{0}", rowBinary);
        }
    }

    [Serializable]
    class MyElement
    {
        private string _name;
        [NonSerialized]
        private int _cacheValue;

        public MyElement(string name)
        {
            _name = name;
            _cacheValue = 15;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1}", _name, _cacheValue);
        }
    }

    [Serializable]
    class MyRow
    {
        List<MyElement> _elements = new List<MyElement>();

        public void Add(MyElement myElement)
        {
            _elements.Add(myElement);
        }

        public override string ToString()
        {
            return String.Join(
                "\n",
                _elements
                    .Select(element => element.ToString())
                    .ToList());
        }
    }
}
