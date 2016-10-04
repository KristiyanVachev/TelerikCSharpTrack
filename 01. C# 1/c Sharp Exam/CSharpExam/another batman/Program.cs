using System;


namespace _04.batman
{
    class Program
    {
        static void Main()
        {
            int s = int.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            //char c = '#';

            int row = 0;
            int col = 0;
            int height = 3 * (s / 2) - 1;


            int maxbody = s / 2 - 1;

            if (maxbody > 3)
            {
                maxbody -= 1;
                height = 2 * (s / 2) + 3;
            }

            int width = 3 * s;


            char[,] batman = new char[height, width];


            //FILL WITH BLANK
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < 3 * s; j++)
                {
                    batman[i, j] = ' ';
                }
            }

            //LEFT WING
            for (int i = 0; i < s / 2; i++)
            {
                col = 0 + i;

                for (int j = 0; j < s - i; j++)
                {
                    batman[row, col] = c;
                    col++;

                }
                row++;
            }

            //RIGHT WING
            col = s + s - 1;
            row = 0;
            for (int i = 0; i < s / 2; i++)
            {
                for (int j = 0; j < s - i; j++)
                {
                    col++;
                    batman[row, col] = c;
                }
                col = s + s - 1;
                row++;
            }

            //EARS
            batman[s / 2 - 1, width / 2 - 1] = c;
            batman[s / 2 - 1, width / 2 + 1] = c;

            //BODY
            //n/2 .... n/2


            for (int i = 0; i < maxbody; i++)
            {
                for (int j = s / 2; j < width - (s / 2); j++)
                {
                    batman[row, j] = c;
                }
                row++;
            }

            //TAIL
            //7,5,3,1
            int center = width / 2;
            row = height - s / 2;

            for (int i = s - 2; i > 0; i -= 2)
            {
                //Console.WriteLine("koala");
                col = center - (i / 2);
                for (int j = 0; j < i; j++)
                {
                    batman[row, col] = c;
                    col++;
                }
                row++;
                //Console.WriteLine(row);
            }

            //PRINT
            //PRINT
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < 3 * s; j++)
                {
                    Console.Write(batman[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
