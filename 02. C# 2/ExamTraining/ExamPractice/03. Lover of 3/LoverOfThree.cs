using System;

namespace _03.Lover_of_3
{
    class LoverOfThree
    {
        static void Main()
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            bool[,] matrix = new bool[r, c];
            int n = int.Parse(Console.ReadLine());
            string[] dir = new string[n];
            for (int i = 0; i < n; i++)
            {
                dir[i] = Console.ReadLine();
            }


            int row = r;
            int col = 0;
            //Initialize the matrix
            for (int i = 0; i < n; i++)
            {
                string[] curDir = dir[i].Split(' ');
                int deltaRow = curDir[0].Contains("U") ? 1 : -1;  //direction
                int deltaCol = curDir[0].Contains("R") ? 1 : -1;
            }
        }
    }
}
