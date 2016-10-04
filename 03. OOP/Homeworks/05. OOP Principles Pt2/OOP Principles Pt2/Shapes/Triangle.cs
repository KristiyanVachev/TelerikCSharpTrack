using System;

namespace Shapes
{
    public class Triangle : Shape
    {


        //constructors
        public Triangle(double width, double height) : base(width, height)
        {

        }

        //methods
        public override double CalculateSurface()
        {
            return this.Height * this.Width / 2;
        }
    }
}
