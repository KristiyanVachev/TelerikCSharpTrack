using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes_Pt2
{
    class Startup
    {
        static void Main()
        {
            Point3D point = new Point3D(1, 2, 3);
            point.ToString();
            Console.WriteLine(point.O.ToString());
            Console.WriteLine(CalculateDistance.Distance(point.O, point));

            Path path = new Path();
            path.sequence.Add(point);

            PathStorage.SavePath(path);


            //Generic 
            var test = new GenericList<int>();

            for (int i = 0; i < 11; i++)
            {
                test.Add(i);
            }
            Console.WriteLine(test.ToString());

            test.AddAtIndex(4, 56);

            Console.WriteLine(test.ToString());

            Console.WriteLine(test.Max());   // Testing Min and Max methods Task 7
            Console.WriteLine(test.Min());
        }
    }
}
