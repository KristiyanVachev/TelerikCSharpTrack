using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Busses
{
    class busses
    {
        static void Main(string[] args)
        {
            int c = int.Parse(Console.ReadLine());
            int[] s = new int[c];
            for (int i = 0; i < c; i++)
            {
                s[i] = int.Parse(Console.ReadLine());
            }

            int groups = 1;
            int turtle = s[0];

           

            for (int i = 1; i < c; i++)
            {
                if (s[i] <= turtle)
                {
                    groups++;
                    turtle = s[i];
                }
               
            }

            Console.WriteLine(groups);
        }
    }
}
