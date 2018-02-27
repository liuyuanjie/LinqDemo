using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo22 : ILinqDemo
    {
        public void Output()
        {
            var students = new List<Student>
                {
                    new Student{StID=1,Age = 2,FirstName ="Liu", LastName = "Yuanjie"},
                    new Student{StID=2,Age = 12,FirstName ="Liu", LastName = "Jia"},
                    new Student{StID=3,Age = 2,FirstName ="Qu", LastName = "Jiangbo"},
                    new Student{StID=4,Age = 15,FirstName ="Li", LastName = "Xing"}
                };

            XDocument studentXDocument =
                new XDocument(
                    new XElement("Students",
                        new XElement("Student",
                            new XElement("StID","1"),
                            new XElement("Age", "2"),
                            new XElement("FirstName", "Liu"),
                            new XElement("LastName", "Yuanjie")
                        ),
                        new XElement("Student",
                            new XElement("StID","2"),
                            new XElement("Age", "12"),
                            new XElement("FirstName", "Liu"),
                            new XElement("LastName", "Jia")
                        ),
                        new XElement("Student",
                            new XElement("StID","3"),
                            new XElement("Age", "2"),
                            new XElement("FirstName", "Qu"),
                            new XElement("LastName", "Jiangbo")
                        )
                    )
                );

            Console.WriteLine(studentXDocument);
        }
    }
}
