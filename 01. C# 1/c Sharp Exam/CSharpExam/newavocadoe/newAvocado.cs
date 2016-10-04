using System;

namespace _05.Avocado
{
    class Program
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            uint[] combs = new uint[c];


            for (int i = 0; i < c; i++)
            {
                combs[i] = uint.Parse(Console.ReadLine());
            }

            uint bestComb = combs[0];
            int teeth = 0;
            int bestTeeth = 0;
            int headLen = Convert.ToString(n, 2).Length;
            int combLen = Convert.ToString(combs[0], 2).Length;
            int shortest;
            bool koala = true;
            int mask;
            //for all combs
            for (int i = 0; i < c; i++)
            {

                if ((n & combs[i]) == 0) //if not overlapping
                {
                    combLen = Convert.ToString(combs[i], 2).Length;
                    koala = true;

                    shortest = Math.Min(headLen, combLen);
                    for (int j = 0; j < shortest; j++)
                    {
                        mask = 1 << j;
                        //if tooth 
                        if ((combs[i] & mask) != 0)
                        {
                            //teeth++; //add tooth
                            if ((n & mask) != 0)
                            //if (head[headLen - j] == '1') //if
                            {
                                koala = false;
                                //teeth = 0;
                                break;
                            }
                        }
                    }

                    if (koala) //if no overlapping
                    {
                        teeth = 0;
                        for (int k = 0; k < combLen; k++)
                        {
                            mask = 1 << k;
                            if ((combs[i] & mask) != 0)
                            {
                                teeth++;
                            }
                        }

                        if (teeth > bestTeeth)
                        {
                            bestTeeth = teeth;
                            teeth = 0;
                            //Console.WriteLine("koala " + bestTeeth);
                            bestComb = combs[i];
                        }
                    }
                }

            }

            Console.WriteLine(bestComb);

        }
    }
}
