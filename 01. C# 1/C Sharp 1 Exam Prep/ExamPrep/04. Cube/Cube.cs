using System;

namespace _04.Cube
{
    class Cube
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int len = (2 * n) - 1;
            string[,] cube = new string[len, len];
            int row;
            int col;

            //fill with blank
            for (row = 0; row < len; row++)
            {
                for (col = 0; col < len; col++)
                {
                    cube[row, col] = " ";
                }
            }

            //DOUBLE DOTS
            //first col
            for (col = n - 1; col < len; col++)
            {
                cube[0, col] = ":";
            }

            //last outer row
            for (row = 1; row < n; row++)
            {
                cube[row, len - 1] = ":";
            }

            //first diagonal
            col = n - 2;
            for (row = 1; row < n; row++)
            {
                cube[row, col] = ":";
                col--;
            }

            //second diagonal
            col = len - 2;
            for (row = 1; row < n; row++)
            {
                cube[row, col] = ":";
                col--;
            }

            //third diagonal
            col = len - 1;
            for (row = n - 1; row < len; row++)
            {
                cube[row, col] = ":";
                col--;
            }

            //second col
            for (col = 1; col < n - 1; col++)
            {
                cube[n - 1, col] = ":";
            }

            //second row
            for (row = n; row < len; row++)
            {
                cube[row, 0] = ":";
            }

            //third row
            for (row = n; row < len; row++)
            {
                cube[row, n-1] = ":";
            }

            //third col
            for (col = 1; col < n - 1; col++)
            {
                cube[len - 1, col] = ":";
            }

            //FILL WITH /
            for (int i = 0; i < n - 2; i++)
            {
                col = n - 1 + i;
                for (row = 1; row < n - 1; row++)
                {
                    cube[row, col] = "/";
                    col--;
                }
            }

            //FILL WITH X
            for (int i = 0; i < n - 2; i++)
            {
                col = len - 2;
                for (row = 2 + i; row < n + i; row++)
                {
                    cube[row, col] = "X";
                    col--;
                }
            }

            //PRINT
            for (row = 0; row < len; row++)
            {
                for (col = 0; col < len; col++)
                {
                    Console.Write(cube[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
