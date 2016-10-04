using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double heigth) : base(width, heigth)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
