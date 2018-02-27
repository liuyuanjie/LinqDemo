using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo26 : ILinqDemo
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
                        orderby s.FullName descending
                        select s;

            foreach (var q in query)
            {
                Console.WriteLine("age: {0} full name: {1}", q.Age, q.FullName);
            }
        }
    }
}
