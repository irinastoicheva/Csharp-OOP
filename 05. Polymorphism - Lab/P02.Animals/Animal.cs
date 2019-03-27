namespace Animals
{
    public class Animal
    {
        private string name;
        private string favoriteFood;
        public Animal(string name, string food)
        {
            this.name = name;
            this.favoriteFood = food;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favoriteFood}";
        }
    }
}
