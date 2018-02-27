using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo27 : ILinqDemo
    {
        public void Output()
        {
            var entities = new LINQEntities();
            var students = entities.Students;

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
