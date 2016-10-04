using System;

namespace _06.Max_K_sum
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] biggest = new int[k];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < k; i++)
            {
                biggest[i] = int.MinValue;
            }

            int smInd = 0;
            bool found = false;
            bool foundOne = true;
            

            for (int i = 0; i < n; i++) //for every number
            {
                foundOne = true;
                for (int j = 0; j < k; j++) //check with the largest K elements
                {
                    if (arr[i] > biggest[j]) //if Curr is smaller than K elements
                    {
                        if (foundOne)
                        {
                            smInd = j;
                            foundOne = false;
                        }
                        found = true; //we have a new smaller
                        if (biggest[j] < biggest[smInd]) 
                        {
                            smInd = j;
                        }
                    }
                }
                if (found)
                {
                    biggest[smInd] = arr[i];
                    found = false;
                }
            }

            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += biggest[i];
                //Console.WriteLine("koala {0} = {1}",i, biggest[i]);
            }
            Console.WriteLine(sum);


        }
    }
}
