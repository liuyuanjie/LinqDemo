using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo24 : ILinqDemo
    {
        public void Output()
        {
            var students = new List<Student>
                {
                    new Student{StID=1, Age = 2, FirstName ="Liu", LastName = "Yuanjie"},
                    new Student{StID=2, Age = 12, FirstName ="Liu", LastName = "Jia"},
                    new Student{StID=3, Age = 2, FirstName ="Qu", LastName = "Jiangbo"},
                    new Student{StID=4, Age = 15, FirstName ="Li", LastName = "Xing"}
                };

            XDocument studentLingDocument =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Students")
                );
            XElement root = studentLingDocument.Element("Students");
            students.ForEach(x => root
                .Add(
                    new XElement("Student",
                            new XAttribute("FullName", x.FullName),
							new XAttribute("StID", x.StID),
                        new XElement("StID", x.StID),
                        new XElement("Age", x.Age),
                        new XElement("FirstName", x.FirstName),
                        new XElement("LastName", x.LastName)
                        )
                    )
                );

            var query = from e in studentLingDocument.Element("Students").Elements()
                        where e.Attribute("FullName").Value == "Liu Yuanjie"
                        select e;

            Console.WriteLine(studentLingDocument);

            Console.WriteLine("---------Find Liuy uanjie---------");
            foreach (var xElement in query.Elements())
            {
                Console.WriteLine("{0}: {1}", xElement.Name, xElement.Value);
            }

            query = from e in studentLingDocument.Element("Students").Elements()
                    let age = e.Element("Age")
                    where age != null && int.Parse(age.Value) > 2
                    select e;

            Console.WriteLine("---------Find Age > 2---------");
            foreach (var xElement in query.Elements())
            {
                Console.WriteLine("{0}: {1}", xElement.Name, xElement.Value);
            }
        }
    }
}
