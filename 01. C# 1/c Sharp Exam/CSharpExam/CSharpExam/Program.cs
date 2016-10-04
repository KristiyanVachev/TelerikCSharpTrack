using System;


namespace CSharpExam
{
    class Program
    {
        static void Main()
        {
            double b = double.Parse(Console.ReadLine());
            double f = double.Parse(Console.ReadLine());

            if (f == 0 || b == 0)
            {
                Console.WriteLine("0.0000");
            }
            else
            {
                double fPerBird = f / b;

                if (b % 2 == 0)
                {
                    fPerBird = fPerBird * 123123123123;
                }
                else
                {
                    fPerBird = fPerBird / 317;
                }

                Console.WriteLine("{0:F4}", fPerBird);
            }


        }
    }
}
