using System;

namespace _02.Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(null);
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] tempArr = Console.ReadLine().Split(null);

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(tempArr[j]);
                }
            }

            int maxSum = int.MinValue;
            int currSum = 0;
            for (int i = 0; i <= n - 3; i++)
            {
                for (int j = 0; j <= m - 3; j++)
                {
                    currSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2];
                    currSum += matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2];
                    currSum += matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    //for (int k = i; k < k + 3; k++)
                    //{
                    //    for (int l = 0; l < l + 3; l++)
                    //    {
                    //        currSum += matrix[k, l];
                    //    }
                    //}
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                    }
                    currSum = 0;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
