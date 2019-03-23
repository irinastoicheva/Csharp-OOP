namespace P03_JediGalaxy
{
    public class Matrix
    {
        public Matrix(int x, int y)
        {
            this.Values = new int[x, y];
        }
        public int[,] Values { get; set; }

        public void FillIn()
        {
            int value = 0;
            for (int i = 0; i < this.Values.GetLength(0); i++)
            {
                for (int j = 0; j < this.Values.GetLength(1); j++)
                {
                    this.Values[i, j] = value++;
                }
            }
        }          
    }
}
