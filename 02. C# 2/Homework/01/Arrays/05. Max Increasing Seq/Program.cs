using System;

namespace _05.Max_Increasing_Seq
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
            int len = 1;
            int largest = 1;

            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i + 1] > arr[i])
                {
                    len++;
                    if (len > largest)
                    {
                        largest = len;
                    }
                }
                else
                {
                    len = 1;
                }
            }

            Console.WriteLine(largest);

        }
    }
}
