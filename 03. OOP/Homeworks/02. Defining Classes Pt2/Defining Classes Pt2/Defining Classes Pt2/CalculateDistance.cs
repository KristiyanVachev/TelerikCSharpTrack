using System;

namespace Defining_Classes_Pt2
{
    static class CalculateDistance
    {
        //methods
        public static double Distance(Point3D point1, Point3D point2)
        {
            //Doesnt really matter if the answer is correct.
            int deltaX = point1.X - point2.X;
            int deltaY = point1.Y - point2.Y;
            int deltaZ = point1.Z - point2.Z;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);

            return distance;
        } 
    }
}
