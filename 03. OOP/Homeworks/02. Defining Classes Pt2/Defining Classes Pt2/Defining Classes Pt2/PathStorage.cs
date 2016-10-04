using System.IO;

namespace Defining_Classes_Pt2
{
    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            StreamWriter streamWriter = new StreamWriter("path.txt");
            using (streamWriter)
            {
                for (int i = 0; i < path.sequence.Count; i++)
                {
                    streamWriter.WriteLine("{0}, {1}, {2}", path.sequence[i].X, path.sequence[i].Y, path.sequence[i].Z);
                }
            }
        }
    }
}
