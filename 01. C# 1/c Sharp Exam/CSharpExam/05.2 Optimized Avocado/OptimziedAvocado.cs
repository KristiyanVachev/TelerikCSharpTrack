using System;

namespace _05._2_Optimized_Avocado
{
    class OptimziedAvocado
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int comb;
            //int[] combs = new int[c];
            int bestComb = 0;
            int teeth = 0;
            int bestTeeth = 0;
            int headLen = Convert.ToString(n, 2).Length;
            int combLen = 0;
            int shortest;
            bool koala = true;
            int mask;


            for (int l = 0; l < c; l++)
            {
                comb = int.Parse(Console.ReadLine());

                Console.WriteLine(n & comb);

                combLen = Convert.ToString(comb, 2).Length;

                //for all combs
                for (int i = 0; i < c; i++)
                {
                    combLen = Convert.ToString(comb, 2).Length;
                    koala = true;

                    shortest = Math.Min(headLen, combLen);
                    for (int j = 0; j < shortest; j++)
                    {
                        mask = 1 << j;
                        //if tooth 
                        if ((comb & mask) != 0)
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
                            if ((comb & mask) != 0)
                            {
                                teeth++;
                            }
                        }

                        if (teeth > bestTeeth)
                        {
                            bestTeeth = teeth;
                            teeth = 0;
                            //Console.WriteLine("koala " + bestTeeth);
                            bestComb = comb;
                        }
                    }
                }
            }
            Console.WriteLine(bestComb);

        }
    }

}
