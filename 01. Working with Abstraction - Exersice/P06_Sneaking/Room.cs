namespace P06_Sneaking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Room
    {
        public Room(int numberOfRowRoom)
        {
            this.Values = new char[numberOfRowRoom][];
        }
        public char[][] Values { get; set; }

        public void Complete(int numberOfRow, char[] row)
        {
            this.Values[numberOfRow] = row;
        }

        public List<int> GetCoordinates(char hero)
        {
            List<int> coordinats = new List<int>();
            for (int row = 0; row < this.Values.GetLength(0); row++)
            {
                if (this.Values[row].Contains(hero))
                {
                    coordinats.Add(row);

                    int col = this.Values[row].ToList().IndexOf(hero);

                    coordinats.Add(col);
                    break;
                }
            }

            return coordinats;
        }

        public List<List<int>> GetEnemies(char hero)
        {
            List<List<int>> enemies = new List<List<int>>();

            for (int row = 0; row < this.Values.Length; row++)
            {
                if (this.Values[row].Contains(hero))
                {
                    List<int> coordinates = new List<int>();

                    int col = this.Values[row].ToList().IndexOf(hero);

                    coordinates.Add(row);
                    coordinates.Add(col);
                    enemies.Add(coordinates);
                }
            }

            return enemies;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Values.Length; i++)
            {
                sb.AppendLine(string.Join("", this.Values[i]));
            }

            return sb.ToString();
        }
    }
}
