using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Merge_Sort
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> primes = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                primes.Add(i);
            }

            for (int i = 2; i <= n; i++)
            {
                for (int j = 2; j < n; j++)
                {
                    if (primes.Contains(j * i))
                    {
                        primes.Remove(j * i);
                    }
                }
            }

            Console.WriteLine(primes.Last());


        }
    }
}
