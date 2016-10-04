using System;

namespace _03.Sequence_in_matrix
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

            int currSeq = 0;
            int maxSeq = 0;
            int currN;
            int next = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    currN = matrix[i, j];
                    next = 1;
                    //check down
                    while ((i + next) < n )
                    {
                        if (matrix[i+next,j] == currN )
                        {
                            currSeq++;
                            if (currSeq > maxSeq)
                            {
                                maxSeq = currSeq;
                            }
                            next++;
                        }
                        else
                        {
                            currSeq = 1;
                            break;
                        }
                    }

                    next = 1;
                    //check right
                    while (j + next < m)
                    {
                        if (matrix[i,j+next] == currN)
                        {
                            currSeq++;
                            if (currSeq > maxSeq)
                            {
                                maxSeq = currSeq;
                            }
                            next++;
                        }
                        else
                        {
                            currSeq = 1;
                            break;
                        }
                    }

                    next = 1;
                    //check diagonal down/right
                    while (((i + next) < n) && ((j + next) < m) )
                    {
                        if (matrix[i + next, j + next] == currN)
                        {
                            currSeq++;
                            if (currSeq > maxSeq)
                            {
                                maxSeq = currSeq;
                            }
                            next++;
                        }
                        else
                        {
                            currSeq = 1;
                            break;
                        }
                    }

                    next = 1;
                    //check diogonal down/left
                    while (((i + next) < n) && ((j - next) >= 0))
                    {
                        if (matrix[i + next, j - next] == currN)
                        {
                            currSeq++;
                            if (currSeq > maxSeq)
                            {
                                maxSeq = currSeq;
                            }
                            next++;
                        }
                        else
                        {
                            currSeq = 1;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(maxSeq);      
        }
    }
}
