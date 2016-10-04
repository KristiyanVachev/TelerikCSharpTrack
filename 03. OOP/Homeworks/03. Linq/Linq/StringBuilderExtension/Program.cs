using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExtension
{
    class Program
    {
        static void Main()
        {

            var TestBuilder = new StringBuilder("This is simple test string. We hope my new extension method can split it.");
            var resultOfSplit = TestBuilder.Substring(0, 27);
            Console.WriteLine(resultOfSplit);

            resultOfSplit = TestBuilder.Substring(0, 0);
            Console.WriteLine(resultOfSplit);

            Console.WriteLine(TestBuilder.Length);
        }
    }

    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            var output = new StringBuilder(input.ToString(index, input.Length - index));
            return output;
        }
    }
}
