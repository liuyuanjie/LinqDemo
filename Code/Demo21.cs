using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LINQDemo.Model;

namespace LINQDemo
{
    public class Demo21 : ILinqDemo
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

            Console.WriteLine("------First Name contain 'L'-------");
            var query = GetQuickSearchQueryByContains(students.AsQueryable(), "FirstName", "L");
            foreach (var q in query)
            {
                Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", q.FirstName, q.LastName, q.Age);
            }

            Console.WriteLine("------Last Name contain 'ng'-------");
            query = GetQuickSearchQueryByContains(students.AsQueryable(), "LastName", "ng");
            foreach (var q in query)
            {
                Console.WriteLine("First Name: {0}, Last Name: {1}, Age: {2}", q.FirstName, q.LastName, q.Age);
            }
        }

        private IQueryable<T> GetQuickSearchQueryByContains<T>(IQueryable<T> source ,string field, string searchText)
        {
            Type type = typeof (T);
            ParameterExpression parameter = Expression.Parameter(type, "x");
            Expression property = Expression.Property(parameter, field);
            Expression value = Expression.Constant(searchText);

            MethodInfo containsmethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            Expression[] methodArgs = { value };
            Expression call = Expression.Call(property, containsmethod, methodArgs);
            Expression lambda = Expression.Lambda<Func<T, bool>>(call, parameter);
            Expression expr = Expression.Call(typeof(Queryable), "Where", new[] { type }, source.Expression, lambda);
            IQueryable<T> query = source.Provider.CreateQuery<T>(expr);

            return query;
        }
    }
}
