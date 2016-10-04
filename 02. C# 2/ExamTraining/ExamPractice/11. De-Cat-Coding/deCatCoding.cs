using System;

namespace _11.De_Cat_Coding
{
    class deCatCoding
    {
        static ulong TwentyOneToDecimal(string word, string alphabet)
        {
            ulong result = 0;
            int index;
            //miao  
            for (int i = word.Length - 1; i >= 0; i--)
            {
                index = (word.Length - 1) - i;
                result += (ulong)alphabet.IndexOf(word[index]) * Power(21, i);
            }
            return result;
        }

        static ulong Power(ulong number, int power)
        {
            ulong result = 1;
            ulong pow = (ulong)power;
            for (ulong i = 0; i < pow; i++)
            {
                result *= number;
            }

            return result;
        }

        static string DecimalToTwentySixth(ulong number, string alphabet)
        {
            string result = "";
            ulong remainer;
            int index;
            //hack
            while(((number *10) / 26) > 0)
            {
                remainer = (number % 26);
                index = Convert.ToInt32((remainer));
                result = alphabet[index] + result;
                number = number / 26;
            }
            

            return result;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            //Initiliazing the alphabet
            char[] alphabetChar = new char[26];
            for (ulong i = 0; i < 26; i++)
            {
                alphabetChar[i] = (char)(97 + i);
            }
            string alphabet = new string(alphabetChar);

            ulong dec;
            //new array for the decoded words
            string[] decoded = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                dec = TwentyOneToDecimal(words[i], alphabet);
                decoded[i] = DecimalToTwentySixth(dec, alphabet);
                Console.Write("{0} ", decoded[i]); 
            }
            Console.WriteLine();
            

        }
    }
}
