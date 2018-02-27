using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo25 : ILinqDemo
    {
        public void Output()
        {
            var entities = new LINQEntities();
            var students = entities.Students;

            var query = from s in students
                        where s.Age < 10
                        select new StudentDomainModel { Age = s.Age, FirstName = s.FirstName };

            query.First().Age += 100;

            foreach (var x in query)
            {
                Console.Write("{0}, ", x.Age);
            }
        }
    }
}
