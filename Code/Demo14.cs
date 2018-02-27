using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo14 : ILinqDemo
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

            var query = from s in students
                group s by s.Age;

            foreach (var q in query)
            {
                Console.WriteLine("age: {0} ", q.Key);
                foreach (var g in q)
                {
                    Console.WriteLine("   full name: {0}", g.FullName);                    
                }
            }
        }
    }
}
