using System;


namespace _09.Most_frequent_number
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

            Array.Sort(arr);
            int curN = arr[0];
            int bestN = arr[0];
            int curLen = 1;
            int bestLen = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] != curN)
                {
                    curLen = 1;
                    curN = arr[i];
                }
                else
                {
                    curLen++;
                    if (curLen > bestLen)
                    {
                        bestLen = curLen;
                        bestN = curN;
                    }
                }
            }

            Console.WriteLine("{0} ({1} times)",bestN, bestLen);
        }
    }
}
