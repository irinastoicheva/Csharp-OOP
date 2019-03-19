namespace P06_Sneaking
{
    public class Enemy
    {
        public Enemy(char name, Position position)
        {
            this.Name = name;
            this.Position = position;
        }
        public char Name { get; set; }

        public Position Position { get; set; }
    }
}
