namespace GSM
{
    public class Display
    {
        private double size;
        private uint colors;

        public Display()
        {
            this.size = 0;
            this.colors = 0;
        }
        public Display(double size, uint colors)
        {
            this.size = size;
            this.colors = colors;
        }
    }
}
