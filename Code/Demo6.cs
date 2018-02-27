using System;
using System.Linq;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo6 : ILinqDemo
    {
        public void Output()
        {
            var entities = new LINQEntities();
            var students = entities.Students;

            var query = from s in students
                        where s.Age < 10
                        select s;

            query.First().Age += 100;

            foreach (var x in query)
            {
                Console.Write("{0}, ", x.Age);
            }
        }
    }
}
