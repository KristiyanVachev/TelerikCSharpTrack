using System;
using System.Linq;

namespace _08.Sum_Integers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Console.ReadLine().Split(' ').Select(int.Parse).Sum());

        }
    }
}
