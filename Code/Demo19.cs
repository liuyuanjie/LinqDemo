using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo19 : ILinqDemo
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
                        group s by 1 into g
                        select new
                        {
                            Grouy = g.Key,
                            Count = g.Count(),
                            Sum = g.Sum(x => x.Age),
                            Max = g.Max(x => x.Age),
                            Min = g.Min(x => x.Age)
                        };

            foreach (var g in query)
            {
                Console.WriteLine("Grouy: {0}, Count: {1}, Sumn: {2}, Max: {3},Min: {4}", g.Grouy, g.Count, g.Sum, g.Max, g.Min);
            }

            var query1 = students
                .GroupBy(g => 1)
                .Select(g =>
                new
                {
                    Grouy = g.Key,
                    Count = g.Count(),
                    Sum = g.Sum(x => x.Age),
                    Max = g.Max(x => x.Age),
                    Min = g.Min(x => x.Age)
                });

            foreach (var g in query1)
            {
                Console.WriteLine("Grouy: {0}, Count: {1}, Sumn: {2}, Max: {3},Min: {4}", g.Grouy, g.Count, g.Sum, g.Max, g.Min);
            }
        }
    }
}
