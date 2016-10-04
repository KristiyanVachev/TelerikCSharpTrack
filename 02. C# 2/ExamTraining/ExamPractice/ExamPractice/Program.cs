using System;

namespace ExamPractice
{
    class Program
    {
        static long EvenDiff(int a, int b)
        {
            if (a > b)
            {
                return a - b;
            }
            else
            {
                return b - a;
            }
        }

        static void Main()
        {
            //Input reading
            string[] input = Console.ReadLine().Split(' ');
            int[] arr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = int.Parse(input[i]);
            }
            //int[] arr = { 1, 6, 8, 10, 3, 1, 1 };

            long sum = 0;
            long eDiff;
            for (int i = 1; i < arr.Length; i++)
            {
                eDiff = EvenDiff(arr[i - 1], arr[i]);
                if (eDiff % 2 == 0) //even
                {
                    sum += eDiff;
                    i++;
                }
                else //odd
                {

                }
            }
            Console.WriteLine(sum);
        }
    }
}
