using System;

namespace Defining_Classes_Pt2
{
    public struct Point3D
    {
        //Fiels
        private static readonly Point3D o = new Point3D(0,0,0);

        //Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D O {
            get { return o; }
        }

        //Constructors
        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //Methods
        public override string ToString()
        {
            Console.WriteLine("{0}, {1}, {2}", this.X, this.Y, this.Z);
            return base.ToString();
        }
    }
}
