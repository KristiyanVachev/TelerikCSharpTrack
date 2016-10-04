using System;

namespace _18.Remove_elements
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

            //pseudo
            //if we encouter smaller than last
            //check if it the next is smaller than current 
            //if true remove the current
            //if false remove prev

            int prev = arr[0];
            int curr = arr[1];
            int next = arr[2];
            int removed = 0;
            bool removedCurr = false;

            for (int i = 1; i < n; i++)
            {
                if (removedCurr)
                {
                    prev = arr[i - 2];
                    removedCurr = false;
                }
                else
                {
                    prev = arr[i - 1];
                }
                curr = arr[i];
                if (i == n - 1)
                {
                    next = arr[i];
                }
                else
                {
                    next = arr[i + 1];
                }
                //if we encouter smaller than last
                if (curr < prev)
                {
                    //check if it the next is smaller than current 
                    if (next < curr)
                    {
                        //if true remove the current
                        removed++;
                        removedCurr = true;
                    }
                    else
                    {
                        //if false remove prev
                        removed++;
                    }
                }
            }

            Console.WriteLine(removed);
        }
    }
}
