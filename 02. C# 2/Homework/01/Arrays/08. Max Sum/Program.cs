using System;

namespace _08.Max_Sum
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;    

            for (int i = 0; i < n; i++)
            {
                if (sum + arr[i] < 0)
                {
                    sum = 0;
                }
                else
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
