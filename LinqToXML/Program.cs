using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.XPath;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = CreateXMLExample_DOM();
            var test2 = CreateXMLExample_Linq();

            var xml = XElement.Parse(test2);

            var bookNames1 = xml.Elements("book")
                .SelectMany(b => b.Elements("name"))
                .Select(name => name.Value);
            foreach (var bookName in bookNames1)
            {
                Console.WriteLine(bookName);
            }

            var bookNames2 = xml.Elements("book")
                .Descendants("name")
                .Select(name => name.Value);
            foreach (var bookName in bookNames2)
            {
                Console.WriteLine(bookName);
            }

            var bookNames3 = xml
                .XPathSelectElements("book/name") // <-- Great - full path
                .Select(name => name.Value);
            foreach (var bookName in bookNames3)
            {
                Console.WriteLine(bookName);
            }

            //using identifiers
            var @int = 2;

            Console.WriteLine(test1);
            Console.WriteLine(test2);
        }

        private void MethodToBeTested()
        {

        }

        static public string CreateXMLExample_DOM()
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlNode xmlBooksNode = xmlDocument.CreateElement("books");
            xmlDocument.AppendChild(xmlBooksNode);

            XmlNode xmlBookNode = xmlDocument.CreateElement("book");
            xmlBooksNode.AppendChild(xmlBookNode);

            XmlNode xmlNameNode = xmlDocument.CreateElement("name");
            xmlNameNode.InnerText = "Fantastic Mr Fox";
            xmlBookNode.AppendChild(xmlNameNode);

            XmlNode xmlPriceNode = xmlDocument.CreateElement("price");
            xmlPriceNode.InnerText = "35.99";
            xmlBookNode.AppendChild(xmlPriceNode);

            return xmlDocument.OuterXml;
        }

        static public string CreateXMLExample_Linq()
        {
            return new XElement("books",
                new XComment("I am a comment"),
                new XElement("book",
                    new XAttribute("data-bind", "Test attribure"),
                    new XElement("name", "Fantastic Mr Fox"),
                    new XElement("price", "35.99")
                    )
                ).ToString();
        }
    }
}
