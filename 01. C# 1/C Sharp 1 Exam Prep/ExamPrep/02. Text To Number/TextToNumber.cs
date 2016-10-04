using System;

namespace _02.Text_To_Number
{
    class TextToNumber
    {
        static void Main()
        {
            int M = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int result = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    Console.WriteLine(result);
                    break;
                }
                else if (text[i] > 47 && text[i] < 58)
                {
                    result *= ((int)text[i] - 48);
                }
                else if (text[i] > 64 && text[i] < 91)
                {
                    result += ((int)text[i] - 65);
                }
                else if (text[i] > 96 && text[i] < 123)
                {
                    result += ((int)text[i] - 97);
                }
                else
                {
                    result %= M;
                }
            }

        }
    }
}
