using System;

namespace _07.Selection_Sort
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

            int temp;
            int smallest = 0; 


            for (int i = 0; i < n; i++)
            {
                smallest = i;
                for (int j = i; j < n; j++)
                {
                    if (arr[j] < arr[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;                
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }
    }
}
