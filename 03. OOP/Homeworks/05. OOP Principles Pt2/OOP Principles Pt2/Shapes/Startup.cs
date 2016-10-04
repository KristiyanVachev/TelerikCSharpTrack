using System;
using System.Collections.Generic;

namespace Shapes
{
    class Startup
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Triangle(3,2),
                new Rectangle(3,2),
                new Square(2)
            };

            Triangle koala = new Triangle(2, 3);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
