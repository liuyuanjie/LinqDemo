using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    public class Demo2 : ILinqDemo
    {
        public void Output()
        {
            var numbers = new List<int> {2, 12, 5, 15};

            var lowNums = from number in numbers
                where number < 10
                select number;

            numbers[0] = 4;

            foreach (var x in lowNums)
            {
                Console.Write("{0}, ",x);
            }
        }
    }
}
