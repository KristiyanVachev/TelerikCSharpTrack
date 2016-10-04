    using System;

    namespace _02.Reverse_String
    {
        class Program
        {
            static void Main()
            {
                string str = Console.ReadLine();

                for (int i = str.Length - 1; i >= 0; i--)
                {
                    Console.Write(str[i]);
                }
            }
        }
    }
