using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = new List<int>();
            List<int> second = new List<int>();

            first.Add(1);
            first.Add(2);
            first.Add(3);

            second = first;

            foreach (var item in second)
            {
                Console.WriteLine(item);
            }
        }
    }
}
