using System;

namespace _07.Largest_Area_in_matrix
{
    class Program
    {

        private static int[,] matrix;
        private static bool[,] visited;

        static void Main()
        {
            //INPUT
            string[] input = Console.ReadLine().Split(null);
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] tempArr = Console.ReadLine().Split(null);

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(tempArr[j]);
                }
            }


            int count = 1;
            int bestCount = 1;
            //TO-DO 
            //Optimize by skipping already visited methods
            visited = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j])
                    {
                        //Console.WriteLine("{0} {1}", i, j);
                        count += RightCheck(i, j);
                        count += DownCheck(i, j);

                        if (count > bestCount)
                        {
                            bestCount = count;
                        }
                        count = 1;
                    }
                }
            }

            Console.WriteLine(bestCount);

        }


        static int RightCheck(int row, int col)
        {
            if (col + 1 < matrix.GetLength(1)) // check if inside the array
            {
                if (matrix[row, col] == matrix[row, col + 1]) //check if equal
                {
                    visited[row, col + 1] = true;
                    //its comming from left, so don't check there
                    int count = 1;
                    //
                    count += RightCheck(row, col + 1);
                    count += DownCheck(row, col + 1);
                    count += UpCheck(row, col + 1);
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        static int DownCheck(int row, int col)
        {
            if (row + 1 < matrix.GetLength(0)) // check if inside the array
            {
                if (matrix[row, col] == matrix[row + 1, col]) //check if equal
                {
                    visited[row + 1, col] = true;
                    //its comming from left, so don't check there
                    int count = 1;
                    //
                    count += RightCheck(row + 1, col);
                    count += DownCheck(row + 1, col);
                    count += LeftCheck(row + 1, col);
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        static int LeftCheck(int row, int col)
        {
            if (col - 1 >= 0) // check if inside the array
            {
                if (matrix[row, col] == matrix[row, col - 1]) //check if equal
                {
                    visited[row, col - 1] = true;
                    //Comming from 
                    int count = 1;
                    //
                    count += DownCheck(row, col - 1);
                    count += LeftCheck(row, col - 1);
                    count += UpCheck(row, col - 1);
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        static int UpCheck(int row, int col)
        {
            if (row - 1 >= 0) // check if inside the array
            {
                if (matrix[row, col] == matrix[row - 1, col]) //check if equal
                {
                    visited[row - 1, col] = true;
                    //its comming from left, so don't check there
                    int count = 1;
                    //
                    count += LeftCheck(row - 1, col);
                    count += UpCheck(row - 1, col);
                    count += RightCheck(row - 1, col);
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

    }
}
