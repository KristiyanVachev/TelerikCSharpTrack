using System;

namespace _06.First_Larger_than_neighbours
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string[] input = Console.ReadLine().Split(null);
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Console.WriteLine(IndexOfFirstLarger(arr));
        }

        static int IndexOfFirstLarger(int[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
