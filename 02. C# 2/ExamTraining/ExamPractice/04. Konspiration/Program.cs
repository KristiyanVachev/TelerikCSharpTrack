using System;
using System.Collections.Generic;

namespace _04.Konspiration
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string[] line = new string[lines];
            for (int i = 0; i < lines; i++)
            {
                line[i] = Console.ReadLine();
            }

            List<string> methods = new List<string>();

            string currentMethod;
            int nameStart;
            int nameEnd;
            int methodCount = 0;
            int beginOfMethods = 0;

            for (int i = 0; i < lines; i++)
            {
                if (line[i].IndexOf("static") != -1)
                {
                    beginOfMethods = i;
                    //get the name of the method
                    nameStart = line[i].IndexOf(' ', line[i].IndexOf("static") + 7);
                    nameEnd = line[i].IndexOf('(');
                    currentMethod = line[i].Substring(nameStart + 1, nameEnd - nameStart - 1);
                    methods.Add(currentMethod);
                    methodCount++;
                }             
            }

            List<string>[] invoked = new List<string>[methodCount];
            for (int i = beginOfMethods; i < lines; i++)
            {

            }
        }
    }
}
