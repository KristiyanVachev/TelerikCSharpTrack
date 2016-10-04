using System;
using System.Text;

namespace _10.conductors
{
    class conductors
    {
        static void Main()
        {
            string p = Convert.ToString(int.Parse(Console.ReadLine()), 2);
            int m = int.Parse(Console.ReadLine());
            string[] tickets= new string[m];

            for (int i = 0; i < m; i++)
            {
                tickets[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2);
            }

            int len = p.Length;
            bool found = true;
            //
            for (int i = 0; i < m; i++)
            {
                for (int j = tickets[i].Length - len; j >= 0; j--)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if (tickets[i][j + k] != p[k])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)//place zeroes
                    {
                        StringBuilder sb = new StringBuilder(tickets[i]);
                        for (int k = 0; k < len; k++)
                        {
                            sb[j + k] = '0';
                        }
                        tickets[i] = sb.ToString();
                    }
                    found = true;
                }
            }

            //print
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(Convert.ToInt32(tickets[i], 2).ToString());
            }
        }
    }
}
