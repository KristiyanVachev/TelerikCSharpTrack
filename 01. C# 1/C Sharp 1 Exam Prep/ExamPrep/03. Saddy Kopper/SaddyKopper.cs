using System;
using System.Numerics;

namespace _03.Saddy_Kopper
{
    class SaddyKopper
    {
        static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            //long n = long.Parse(Console.ReadLine());

            string nStr;
            long sum = 0;
            int trans = 0;


            while (trans < 10)
            {
                nStr = n.ToString();
                sum = 0;
                n = 1;

                while (nStr.Length > 1)
                {
                    //remove the last digit
                    nStr = nStr.Remove(nStr.Length - 1);

                    for (int j = 0; j < nStr.Length; j += 2)
                    {
                        sum += (nStr[j] - '0'); //stackoverflow hack
                    }
                    if (sum != 0)
                    {
                        n *= sum;
                    }

                    sum = 0;
                }

                trans++;

                if (n.ToString().Length == 1)
                {
                    Console.WriteLine(trans);
                    break;
                }

            }

            Console.WriteLine(n);

        }
    }
}
