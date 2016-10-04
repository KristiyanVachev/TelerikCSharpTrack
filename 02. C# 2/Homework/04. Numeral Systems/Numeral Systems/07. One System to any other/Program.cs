using System;
using System.Numerics;


namespace _07.One_System_to_any_other
{
    class Program
    {
        static void Main()
        {
            int sBase = int.Parse(Console.ReadLine());
            string n = Console.ReadLine().ToUpper();
            int dBase = int.Parse(Console.ReadLine());

            //turn n in sBase into n in base 10
            BigInteger toDecimal = IntoDecimal(sBase, n);
            //turn n in base 10 into n in base 9
            string result = DecimalTodBase(dBase, toDecimal);
            Console.WriteLine(result);

            //Console.WriteLine(DecimalTodBase(13,207));


        }
        static BigInteger IntoDecimal(int inBase, string n)
        {
            BigInteger result = 0;
            BigInteger multiplier;
            //for every digit in the number, startng from the left
            //multiplying each digit by base^(place of the digit from right to left)
            for (int i = n.Length - 1; i >= 0; i--)
            {
                multiplier = 1;
                //manual .Pow 
                for (int j = 0; j < i; j++)
                {
                    multiplier *= inBase;
                }

                //if the digit is a numer (1-9)
                if (n[n.Length - 1 - i] < 57)
                {
                    result += (BigInteger)(n[n.Length - 1 - i] - '0') * multiplier;
                }
                else //if nto a numebr - ABCDEF 
                {
                    result += (n[n.Length - 1 - i] - 55) * multiplier;
                }
            }
            return result;
        }

        static string DecimalTodBase(int outBase, BigInteger n)
        {
            BigInteger multiplier = 1;
            string result = "";
            BigInteger timesMet;

            //finding largest n to the power, i.e. the biggest digit of the new number
            while (n / multiplier > 0)
            {
                multiplier *= outBase;
            }
            multiplier /= outBase;

            do //for every digit (example: 9^3, 9^2, 9^1, 9^0) getting the "timesmet" (example: 8 * 9^3)
            {
                timesMet = n / multiplier;
                n = n - (timesMet * multiplier);
                if (timesMet < 10) //if its a real number
                {
                    result = result + timesMet;
                }
                else //if not, asign it with a letter (ABCDEF...)
                {
                    result = result + (char)(55 + timesMet);
                  
                }
                multiplier /= outBase;
            }
            while (multiplier >= 1); //while its multiplier is bigger or equal to (example 9^0)

            return result;
        }
    }
}
