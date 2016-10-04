using System;

namespace _07.Speeds
{
    class Speeds
    {
        static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            int[] cars = new int[c];
            for (int i = 0; i < c; i++)
            {
                cars[i] = int.Parse(Console.ReadLine());
            }


            int turtle = cars[0];
            int longestGroup = 1;
            int group = 1;
            int sum = cars[0];
            int longestSum = cars[0];

            for (int i = 1; i < c; i++)
            {
                if (cars[i] > turtle)
                {
                    group++;
                    sum += cars[i];
                    if (group >= longestGroup)
                    {
                        longestGroup = group;
                        longestSum = sum;
                    }
                }
                else
                {
                    turtle = cars[i];
                    group = 1;
                    sum = cars[i];
                }
            }

            Console.WriteLine(longestSum);
        }
    }
}
