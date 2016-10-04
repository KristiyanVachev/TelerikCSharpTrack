using System;

namespace _05.Avocado
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string head = Convert.ToString(n, 2);
            int c = int.Parse(Console.ReadLine());
            string[] combs = new string[c];


            for (int i = 0; i < c; i++)
            {
                //combs[i] = Console.ReadLine();
                //Console.WriteLine("comb " + combs[i]);

                combs[i] = Convert.ToString(int.Parse(Console.ReadLine()), 2);
                //Console.WriteLine("binary " + combs[i]);
            }

            string bestComb = combs[0];
            int teeth = 0;
            int bestTeeth = 0;
            int headLen = head.Length;
            int combLen = combs[0].Length;
            int shortest;
            //bool koala = true;
            //for all combs
            for (int i = 0; i < c; i++)
            {
                teeth = 0;
                //combLen = combs[i].Length;

                //if (headLen > combLen)
                //{
                //    shortest = combLen;
                //}
                //else
                //{
                //    shortest = headLen;
                //}
                shortest = Math.Min(headLen, combLen);
                for (int j = 1; j <= shortest; j++)
                {
                    //Console.WriteLine("comb{0} - combs[{1}] comblen{2}", i, combLen - j, combLen);
                    //if tooth 
                    if (combs[i][combLen - j] == head[headLen - j])
                    {
                        teeth = 0;
                        break;

                    }
                    else
                    {
                        teeth++; //add tooth
                        if (combs[i][combLen - j] == '1') //if
                        {
                            teeth++;
                            //koala = false;

                        }
                    }


                    //if (combs[i][combLen - j] == '1')
                    //{
                    //    teeth++; //add tooth
                    //    if (head[headLen - j] == '1') //if
                    //    {
                    //        koala = false;
                    //        teeth = 0;
                    //        break;
                    //    }
                    //}
                }

                //if (koala)
                //{
                if (teeth > bestTeeth)
                {
                    bestTeeth = teeth;
                    teeth = 0;
                    //Console.WriteLine("koala " + bestTeeth);
                    bestComb = combs[i];
                }
                //}

                //koala = true;

            }

            Console.WriteLine(Convert.ToInt32(bestComb, 2).ToString());


        }
    }
}
