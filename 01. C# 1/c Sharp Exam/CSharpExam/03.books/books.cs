using System;


namespace _03.books
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int digits = 0;

            for (int i = n; i > 0; i--)
            {
                digits += i.ToString().Length;
            }

            Console.WriteLine(digits);
        }
    }
}
