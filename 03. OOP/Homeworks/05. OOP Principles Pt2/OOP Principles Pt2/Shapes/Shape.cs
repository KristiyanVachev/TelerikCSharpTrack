namespace Shapes
{
    public abstract class Shape
    {
        //fields
        private double widht;
        private double height;

        //props
        public double Width { get { return this.widht; } set { this.widht = value; } }
        public double Height { get { return this.height; } set { this.height = value; } }

        //constructors
        public Shape(double width, double heigth)
        {
            this.Width = width;
            this.Height = heigth;
        }

        //methods
        public abstract  double CalculateSurface();

    }
}
