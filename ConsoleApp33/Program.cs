using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {

            
            XmlTextWriter xmlwriter = new XmlTextWriter("../../Magazin.xml", Encoding.UTF8);
            xmlwriter.WriteStartDocument();
            
            xmlwriter.Formatting = Formatting.Indented; 
            xmlwriter.IndentChar = '\t'; 
            xmlwriter.Indentation = 1; 
            xmlwriter.WriteStartElement("Order");
           
            xmlwriter.WriteStartElement("buy");
            xmlwriter.WriteStartAttribute("nubder", null); 
            xmlwriter.WriteString("1");
            xmlwriter.WriteEndAttribute(); 
            xmlwriter.WriteStartAttribute("product", null);
            xmlwriter.WriteString("phone");
            xmlwriter.WriteEndAttribute();
            xmlwriter.WriteStartAttribute("cost", null);
            xmlwriter.WriteString("100");
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndElement(); 
            xmlwriter.WriteEndElement();

            Console.WriteLine("Данные сохранены в XML-файл");
            xmlwriter.Close();

           
            XmlTextReader reader = new XmlTextReader("../../Magazin.xml");
            string str = null;
            while (reader.Read()) 
            {
                if (reader.NodeType == XmlNodeType.Text)
                    str += reader.Value + "\n";

                
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute()) 
                        {
                            str += reader.Value + "\n";
                        }
                    }
                }
            }
            Console.WriteLine(str);
            reader.Close();

           
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../Magazin.xml");
            
            XmlElement xRoot = xDoc.DocumentElement;
            
            foreach (XmlNode xnode in xRoot)
            {
                
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Order");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
               
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "nubder")
                    {
                        Console.WriteLine("Номер: {0}", childnode.FirstChild.Value);
                    }
                    if (childnode.Name == "product")
                    {
                        Console.WriteLine("Продукт: {0}", childnode.InnerText);
                    }
                    if (childnode.Name == "cost")
                    {
                        Console.WriteLine("цена: {0}", childnode.InnerText);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
