using System;

namespace _03.Compare_char
{
    class Program
    {
        static void Main(string[] args)
        {
            string arr1 = Console.ReadLine();
            string arr2 = Console.ReadLine();
            bool koala = false;

            if (arr1.Length != arr2.Length)
            {
                if (arr1.Length > arr2.Length)
                {
                    Console.WriteLine(">");
                }
                else
                {
                    Console.WriteLine("<");
                }
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        if (arr1[i] > arr2[i])
                        {
                            Console.WriteLine(">");
                            koala = !koala;
                        }
                        else
                        {
                            Console.WriteLine("<");
                            koala = !koala;
                        }
                    }
                }
                if (koala)
                {
                    Console.WriteLine("=");

                }
            }

        }
    }
}
