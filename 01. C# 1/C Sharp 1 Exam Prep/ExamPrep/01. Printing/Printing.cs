using System;

namespace template
{
    class Printing
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int S = int.Parse(Console.ReadLine());
            double P = double.Parse(Console.ReadLine());

            int sheets = N * S;
            double pricePerSheet = P / 500;
            double total = sheets * pricePerSheet;

            Console.WriteLine("{0:F2}", total);


        }
    }
}