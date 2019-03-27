namespace P03.WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        protected string Name { get; set; }
        protected double Weight { get; set; }
        protected int FoodEaten { get; set; }

        public abstract string AskForFood();

        public abstract void Eat(Food food);
    }
}
