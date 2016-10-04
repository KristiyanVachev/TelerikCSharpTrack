using System;

namespace _14.Integer_Calculation
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[5];
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < 5; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            Console.WriteLine(Minimum(arr));
            Console.WriteLine(Maximum(arr));
            Console.WriteLine("{0:F2}",Average(arr));
            Console.WriteLine(Sum(arr));
            Console.WriteLine(Product(arr));
        }

        static int Minimum(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static int Maximum(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static float Average(int[] arr)
        {
            return (float)Sum(arr) / arr.Length;
        }

        static int Sum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static long Product(int[] arr)
        {
            long product = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }
    }
}
