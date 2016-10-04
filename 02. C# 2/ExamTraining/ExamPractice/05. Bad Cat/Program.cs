using System;

namespace _05.Bad_Cat
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] str = new string[n];
            for (int i = 0; i < n; i++)
            {
                str[i] = Console.ReadLine();
            }
            string result = "";
            string currStr = "";
            int index;
            string first = "";
            string second = "";

            for (int i = 0; i < n; i++)
            {
                if (str[i].Contains("before"))
                {
                    if (result.Contains(str[i][0].ToString()))
                    {
                        //put the other after
                        index = result.IndexOf(str[i][0].ToString());
                        result.Insert(index, str[i][str[i].Length - 1].ToString());
                    }
                    else if(result.Contains(str[i][str[i].Length - 1].ToString()))
                    {
                        //put the other before
                        index = result.IndexOf(str[i][str[i].Length - 1].ToString());
                        result.Insert(index - 1, str[i][0].ToString());
                    }
                    else //if not contained
                    {
                        currStr = str[i][0].ToString() + str[i][str[i].Length - 1].ToString();
                        if (result.Length == 0)
                        {
                            result = currStr;
                        }
                        else
                        {
                            if (Convert.ToInt32(currStr[0]) < Convert.ToInt32(result[0]))
                            {
                                result = currStr + result;
                            }
                            else if (Convert.ToInt32(currStr[0]) > Convert.ToInt32(result[0]))
                            {
                                result = result + currStr;
                            }
                            else
                            {
                                if (Convert.ToInt32(currStr[1]) < Convert.ToInt32(result[1]))
                                {
                                    result = currStr + result;
                                }
                                else
                                {
                                    result = result + currStr;

                                }
                            }
                        }
                       
                    }
                }
                else //first after second
                {
                    first = str[i][0].ToString();
                    second = str[i][str[i].Length - 1].ToString();
                        

                    if (result.Contains(first))
                    {
                        //put the other after
                        index = result.IndexOf(first);
                        result.Insert(index - 1, second );
                    }
                    else if (result.Contains(second))
                    {;
                        //put the other before
                        index = result.IndexOf(second);
                        result.Insert(index, first);
                    }
                    else //if not contained
                    {
                        currStr = second + first;
                        if (result.Length == 0)
                        {
                            result = currStr;
                        }
                        else
                        {
                            if (Convert.ToInt32(currStr[0]) < Convert.ToInt32(result[0]))
                            {
                                result = currStr + result;
                            }
                            else if (Convert.ToInt32(currStr[0]) > Convert.ToInt32(result[0]))
                            {
                                result = result + currStr;
                            }
                            else
                            {
                                if (Convert.ToInt32(currStr[1]) < Convert.ToInt32(result[1]))
                                {
                                    result = currStr + result;
                                }
                                else
                                {
                                    result = result + currStr;

                                }
                            }
                        }
                        //currStr = str[i][0].ToString() + str[i][str[i].Length - 1].ToString();
                        
                    }

                }
            }

            Console.WriteLine(result);
        }
    }
}
