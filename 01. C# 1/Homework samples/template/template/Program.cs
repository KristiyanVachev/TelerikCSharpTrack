using System;

namespace template
{
    class Program
    {
        static void Main()
        {

            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine();
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToString(int.Parse(arr[i]), 2);

                if (arr[i].Length < 30)
                {
                    //Console.WriteLine("poop");
                    arr[i] = arr[i].PadLeft(30, '0');
                    //Console.WriteLine(arr[i].Length);

                }
                else
                {
                    //Console.WriteLine("koala");
                    arr[i] = arr[i].Substring(0, 30);
                    //Console.WriteLine(arr[i].Length);
                }
            }

            string koala = "";

            for (int i = 0; i < n; i++)
            {
                koala = string.Concat(koala, arr[i]);
            }

            //Console.WriteLine(koala);

            //find longest seq
            int zeros = 0;
            int zerosLon = 0;
            int ones = 0;
            int onesLon = 0;

            for (int j = 0; j < koala.Length; j++)
            {
                //Console.WriteLine(koala[j]);

                if (koala[j] == '0')
                {
                    zeros++;
                    if (zeros > zerosLon)
                    {
                        zerosLon = zeros;
                    }
                    ones = 0;
                }
                else
                {
                    ones++;
                    if (ones > onesLon)
                    {
                        onesLon = ones;
                    }
                    zeros = 0;
                }
            }

            Console.WriteLine(zerosLon);
            Console.WriteLine(onesLon);


        }
    }
}
