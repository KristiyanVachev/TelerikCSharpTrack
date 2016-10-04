using System;

namespace _11.Binary_Search
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
            int x = int.Parse(Console.ReadLine());

            int mid = arr.Length / 2;
            int start = 0;
            int end = arr.Length;
            int index = -1;

            while ((end - start) > 1)
            {
                if (x == arr[mid])
                {
                    index = mid;
                    break;
                }
                else
                {
                    if (arr[mid] > x)
                    {
                        end = mid;
                        mid = (end + start) / 2;
                    }
                    else
                    {
                        start = mid;
                        mid = (end + start) / 2;
                    }
                }
            }

            Console.WriteLine(index);

        }
    }
}
