    using System;
    using System.Collections.Generic;

    namespace _04.Konspiration_ListofLists
    {
        class KonListList
        {
            static void Main()
            {
                //Reading input
                int lines = int.Parse(Console.ReadLine());
                string[] line = new string[lines];
                for (int i = 0; i < lines; i++)
                {
                    line[i] = Console.ReadLine();
                }

                List<List<string>> list = new List<List<string>>();

                string currentMethod;
                int nameStart;
                int nameEnd;
                int listCount = -1;
                bool beginOfMethods = false;
                bool oddInvoke = false;
                string oddMethod = "";
                int oddIndex = 0;

                for (int i = 0; i < lines; i++)
                {
                    if (line[i].IndexOf("static") != -1)
                    {
                        beginOfMethods = true;
                        //get the name of the method
                        nameStart = line[i].IndexOf(' ', line[i].IndexOf("static") + 7);
                        nameEnd = line[i].IndexOf('(', nameStart);
                        currentMethod = line[i].Substring(nameStart + 1, nameEnd - nameStart - 1);
                        List<string> newMethod = new List<string>();
                        newMethod.Add(currentMethod);
                        list.Add(newMethod);
                        listCount++;
                    }

                    if (beginOfMethods)
                    {
                        //check for invocation of a declared method without a dot
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (line[i].Contains(list[k][0]))
                            {
                                oddInvoke = true;
                                oddMethod = list[k][0];
                                oddIndex = line[i].IndexOf(oddMethod);
                                //lets say that there wouldnt be more than one
                            }
                        }
                        nameStart = 0;
                        nameEnd = 0;
                        while (true)
                        {
                            nameStart = line[i].IndexOf('.', nameEnd);
                            if (nameStart < 0)
                            {
                                break;
                            }
                            if (nameStart != -1)
                            {
                                nameEnd = line[i].IndexOf('(', nameStart);
                                if (nameEnd < 0)
                                {
                                    break;
                                }
                                if (nameStart > 0 && nameEnd > 0)
                                {
                                    if (oddInvoke)
                                    {
                                        if (oddIndex < nameStart)
                                        {
                                            list[listCount].Add(oddMethod);
                                            oddInvoke = false;
                                        }
                                    }
                                    list[listCount].Add(line[i].Substring(nameStart + 1, nameEnd - nameStart - 1));
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        if (oddInvoke)
                        {
                            list[listCount].Add(oddMethod);
                            oddInvoke = false;
                        }
                   
                    }


                }

                for (int i = 0; i < list.Count; i++)
                {
                      if (list[i].Count <=2)
                    {
                        Console.Write("{0} ->", list[i][0]);
                        Console.WriteLine("None");
                    }
                    else
                    {
                        Console.Write("{0} -> {1} ->", list[i][0], list[i].Count - 2);

                        for (int j = 2; j < list[i].Count - 1; j++)
                        {
                            Console.Write(" {0},", list[i][j]);
                        }
                        Console.Write(" {0}", list[i][list[i].Count - 1]);
                    }
                
                    Console.WriteLine();
                }


            }
        }
    }