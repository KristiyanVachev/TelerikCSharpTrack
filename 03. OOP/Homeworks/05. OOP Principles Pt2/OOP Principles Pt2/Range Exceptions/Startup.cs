using System;

namespace Range_Exceptions
{
    class Startup
    {
        static void Main()
        {
            Console.WriteLine("Enter number in the range [1...100] (or don't): ");
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 100)
            {
                throw new InvalidRangeException("Number out of the range [1...100].");
            }

            Console.WriteLine("Enter a date in the format [1.1.1980] and in the range [1.1.1980 ... 31.12.2013]:");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date.Year < 1980 || date.Year > 2014)
            {
                throw new InvalidRangeException("Date out of the range [1.1.1980 - 31.12.2013].");
            }
        }
    }
}
