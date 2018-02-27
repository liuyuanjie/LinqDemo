using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo20 : ILinqDemo
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

            Func<Student, bool> checkFullNameGreateTen = (s) =>
            {
                return s.FullName.Length > 10;
            };

            Func<Student, Student> updateAge = (s) =>
            {
                s.Age += 100;

                return s;
            };

            var query = students.Where(checkFullNameGreateTen).Select(updateAge);

            foreach (var q in query)
            {
                Console.WriteLine("Full Name: {0}, Age: {1}", q.FullName, q.Age);
            }

            var query1 = students
                .Where(s => s.FullName.Length > 10)
                .Select(s =>
                    {
                        s.Age += 100;
                        return s;
                    });

            foreach (var q in query1)
            {
                Console.WriteLine("Full Name: {0}, Age: {1}", q.FullName, q.Age);
            }
        }
    }
}
