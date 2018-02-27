using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo8 : ILinqDemo
    {
        public void Output()
        {
            var students = new List<Student>
                {
                    new Student{StID=1,Age = 2,FirstName ="Liu", LastName = "Yuanjie"},
                    new Student{StID=2,Age = 12,FirstName ="Liu", LastName = "Jia"},
                    new Student{StID=3,Age = 5,FirstName ="Qu", LastName = "Jiangbo"},
                    new Student{StID=4,Age = 15,FirstName ="Li", LastName = "Xing"},
                    new Student{StID=5,Age = 15,FirstName ="Bai", LastName = "Chonglong"},
                };

            var courses = new List<Course>
                {
                    new Course{StID=1,CourseName = "Art"},
                    new Course{StID=2,CourseName = "History"},
                    new Course{StID=3,CourseName = "History"},
                    new Course{StID=4,CourseName = "Physics"}
                };

            var query = from s in students
                        join c in courses on s.StID equals c.StID into sc
                        from scd in sc.DefaultIfEmpty(new Course
                                {
                                    CourseName = "None"
                                })
                        select new { s.FullName, scd.CourseName };

            foreach (var q in query)
            {
                Console.WriteLine("full name: {0} course: {1}", q.FullName, q.CourseName);
            }
        }
    }
}
