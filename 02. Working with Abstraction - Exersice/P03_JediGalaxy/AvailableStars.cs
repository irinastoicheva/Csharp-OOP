namespace P03_JediGalaxy
{
    public class AvailableStars
    {
        public AvailableStars(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }

        public Matrix Change(Matrix matrix)
        {
            int x = this.X;
            int y = this.Y;

            while (x >= 0 && y >= 0)
            {
                if (x >= 0 && x < matrix.Values.GetLength(0) && y >= 0 && y < matrix.Values.GetLength(1))
                {
                   matrix.Values[x,y] = 0;
                }
                x--;
                y--;
            }

            return matrix;
        }
    }
}
