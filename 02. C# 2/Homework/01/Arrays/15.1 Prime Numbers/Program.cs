using System;

namespace _15._1_Prime_Numbers
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];

            for (int i = 2; i < n + 1; i++)
            {
                if (!primes[i])
                {
                    for (long j = 2; j * i <= n; j++)
                    {
                        primes[i * j] = true;
                    }
                }
            }

            for (long i = n; i >= 0; i--)
            {
                if (!primes[i])
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            //Console.WriteLine(primes[primes.Length - 1]);
            //Console.WriteLine(primes.Length);
        }
    }
}
