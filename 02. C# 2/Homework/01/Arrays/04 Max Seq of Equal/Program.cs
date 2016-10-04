using System;

namespace _04_Max_Seq_of_Equal
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
            int curr = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == curr)
                {
                    len++;
                    if (len > largest)
                    {
                        largest = len;
                    }
                }
                else
                {
                    curr = arr[i];
                    len = 1;
                }
            }
            Console.WriteLine(largest);
        }
    }
}
