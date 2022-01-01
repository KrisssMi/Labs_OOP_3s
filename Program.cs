using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OOP_Lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------------------------------ЗАДАНИЕ №1---------------------------------------

            /* Выполните сериализацию/десериализацию объекта используя форматы:
                    a. Binary,
                    b. SOAP,
                    c. JSON,
                    d. XML.
            Запретите сериализацию одного из членов вашего класса и продемонстрируйте отсутствие данного элемента в результате работы сериализаторов */

            Computer comp1 = new Computer("Windows", "ASUS", 2900);
            Computer comp2 = new Computer("Windows", "Lenovo", 1900);
            Computer comp3 = new Computer("Windows", "Aser", 2100);
            Computer comp4 = new Computer("iOS", "HP", 2500);

            CustomSerializer.Serialize("binComp.bin", comp1);
            CustomSerializer.Serialize("binComp.soap", comp2);
            CustomSerializer.Serialize("binComp.xml", comp3);
            CustomSerializer.Serialize("binComp.json", comp4);

            CustomSerializer.Deserialize("binComp.bin");
            CustomSerializer.Deserialize("binComp.soap");
            CustomSerializer.Deserialize("binComp.xml");
            CustomSerializer.Deserialize("binComp.json");
            Console.WriteLine();


            //-------------------------------ЗАДАНИЕ №2---------------------------------------

            /* Создайте коллекцию (массив) объектов и выполните сериализацию/десериализацию.  */

            List<Computer> list = new List<Computer>() { comp1, comp2, comp3, comp4 };
            using (FileStream fs = new FileStream("List.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Computer>));
                xs.Serialize(fs, list);
                fs.Close();
                using (FileStream fsd = new FileStream("List.xml", FileMode.Open))
                {
                    List<Computer> computers = (List<Computer>)xs.Deserialize(fsd);
                    computers.ForEach(x => Console.WriteLine($"Deserialized comp: {x.Brand} {x.Model}"));
                }
            }
            Console.WriteLine();


            //-------------------------------ЗАДАНИЕ №3---------------------------------------

            /* Напишите два селектора для вашего XML документа */

            Regex regex = new Regex(@"<Brand>(?<B>\w+)</Brand><Model>(?<M>\w+)</Model>");

            XmlDocument document = new XmlDocument();
            document.Load("List.xml");
            XmlElement xmlRoot = document.DocumentElement;
            XmlNode my_comp = xmlRoot.SelectSingleNode("descendant::Computer[Model='ASUS']");
            Console.WriteLine($"{regex.Match(my_comp.OuterXml).Groups["B"].Value} {regex.Match(my_comp.OuterXml).Groups["M"].Value}");

            Console.WriteLine();
            XmlNodeList allComps = xmlRoot.SelectNodes("*");
            foreach (XmlNode i in allComps)
            {
                Console.WriteLine($"{regex.Match(i.OuterXml).Groups["B"].Value} {regex.Match(i.OuterXml).Groups["M"].Value}");
            }
            Console.WriteLine();



            //-------------------------------ЗАДАНИЕ №4---------------------------------------

            /* Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов. */

            XDocument students = new XDocument();           // представляет весь xml-документ
            XElement root = new XElement("Students");       // представляет отдельный элемент
            XElement student = new XElement("student");
            XAttribute name = new XAttribute("name", "Kristina");
            XAttribute surname = new XAttribute("surname", "Minevich");
            student.Add(name, surname);
            root.Add(student);
            name = new XAttribute("name", "Natasha");
            surname = new XAttribute("surname", "Stalmahova");
            student = new XElement("student");
            student.Add(name, surname);
            root.Add(student);
            students.Add(root);
            students.Save("Students.xml");

            var allStudents = root.Elements("student");
            foreach (var i in allStudents)
            {
                if (i.Attribute("name").Value == "Natasha")
                    Console.WriteLine(i.Attribute("surname").Value);
            }
        }
    }
}
