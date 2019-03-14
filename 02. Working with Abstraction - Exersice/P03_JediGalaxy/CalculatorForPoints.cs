namespace P03_JediGalaxy
{
    public class CalculatorForPoints
    {
        public CalculatorForPoints(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }

        public long Calculate(Matrix matrix)
        {
            int x = this.X;
            int y = this.Y;
            long sum = 0;
            while (x >= 0 && y < matrix.Values.GetLength(1))
            {
                if (x >= 0 && x < matrix.Values.GetLength(0) && y >= 0 && y < matrix.Values.GetLength(1))
                {
                    sum += matrix.Values[x, y];
                }

                y++;
                x--;
            }

            return sum;
        }
    }
}
