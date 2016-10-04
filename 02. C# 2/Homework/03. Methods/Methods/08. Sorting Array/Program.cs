using System;


namespace _08.Sorting_Array
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

            arr = SortArray(arr);

            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

        }

        static int IndexOfSmallest(int[] arr, int index)
        {
            int bestInd = index;

            for (int i = index + 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[bestInd])
                {
                    bestInd = i;
                }
            }
            return bestInd;
        }

        static int[] SortArray(int[] arr)
        {
            int temp;
            int largestInd;
            for (int i = 0; i < arr.Length; i++)
            {
                largestInd = IndexOfSmallest(arr, i);

                temp = arr[i];
                arr[i] = arr[largestInd];
                arr[largestInd] = temp;
            }

            return arr;
        }
    }
}
