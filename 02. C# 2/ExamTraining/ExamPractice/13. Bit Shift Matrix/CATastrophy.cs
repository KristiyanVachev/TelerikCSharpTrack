using System;
using System.Collections.Generic;

namespace _13.Bit_Shift_Matrix
{
    class CATastrophy
    {

        static List<string> CheckDeclarations(string line)
        {
            string[] types = { "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal", "bool", "char", "string" };
            string[] words = line.Split(new[] { ' ', '(', '?', ')' }, StringSplitOptions.RemoveEmptyEntries);
            //list for the found declarations - if more than one
            //TO-DO >> int a,b,c;

            List<string> names = new List<string>();

            foreach (var type in types)
            {
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (words[i] == type)
                    {
                        string[] namesFound = words[i + 1].Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var nameFound in namesFound)
                        {
                            names.Add(nameFound);
                        }
                    }
                }
            }
            return names;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            int area = 0; //0 - Methods, 1 - Loops, 2 Conditionals
            List<string> methods = new List<string>();
            List<string> loops = new List<string>();
            List<string> conditionals = new List<string>();

            List<List<string>> areaTypes = new List<List<string>>();
            areaTypes.Add(methods);
            areaTypes.Add(loops);
            areaTypes.Add(conditionals);


            List<string> temp = new List<string>();

            List<int> areaPath = new List<int>();
            int brackets = 0;
            bool afterMain = false;

            //DEBUGGING
            for (int i = 0; i < n; i++)
            {
                //if in a method
                if (lines[i].Contains(" static "))
                {
                    afterMain = true;
                    area = 0;
                    areaPath.Add(area);

                    temp = CheckDeclarations(lines[i]);
                    //Dont add the first word. Its the name of the method// Looks like the last ?!?
                    if (temp.Count > 0)
                    {
                        for (int j = 0; j < temp.Count - 1; j++)
                        {
                            areaTypes[areaPath[areaPath.Count - 1]].Add(temp[j]);
                        }
                    }
                    //skip the next row
                }
                else
                {
                    //if in a Loop
                    if (lines[i].Contains(" for ") || lines[i].Contains(" while ") || lines[i].Contains(" foreach "))
                    {
                        area = 1;
                        areaPath.Add(area);
                        //CHECK FOR DECLARATIONS
                        temp = CheckDeclarations(lines[i]);
                        if (temp.Count > 0)
                        {
                            for (int j = 0; j < temp.Count; j++)
                            {
                                areaTypes[areaPath[areaPath.Count - 1]].Add(temp[j]);
                            }
                        }

                    }
                    //if in a conditional
                    else if (lines[i].Contains(" if ") || lines[i].Contains("else if") || lines[i].Contains("else"))
                    {
                        area = 2;
                        areaPath.Add(area);
                        //CHECK FOR DECLARATIONS
                        temp = CheckDeclarations(lines[i]);
                        if (temp.Count > 0)
                        {
                            for (int j = 0; j < temp.Count; j++)
                            {
                                areaTypes[areaPath[areaPath.Count - 1]].Add(temp[j]);
                            }
                        }
                    }
                    //just check for
                    else
                    {
                        if (afterMain)
                        {
                            if (lines[i].Contains("}"))
                            {
                                brackets--;
                                if (brackets > 0)
                                {
                                    areaPath.RemoveAt(areaPath.Count - 1);
                                }
                            }
                            else if (lines[i].Contains("{"))
                            {
                                brackets++;
                            }
                        }
                       
                        //DECLARATIONS
                        temp = CheckDeclarations(lines[i]);
                        if (temp.Count > 0)
                        {
                            for (int j = 0; j < temp.Count; j++)
                            {
                                areaTypes[areaPath[areaPath.Count - 1]].Add(temp[j]);
                            }
                        }
                    }

                }

            }

            string[] areaNames = { "Methods", "Loops ", "Conditional Statements" };
            //PRINT
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0} -> {1} -> {2}", areaNames[i], areaTypes[i].Count, string.Join(", ", areaTypes[i].ToArray()));
            }


        }
    }
}
