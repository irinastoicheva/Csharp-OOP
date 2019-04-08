namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        public const int ServingSizeInitial = 200;
        public Dessert(string name, decimal price) : base(name, ServingSizeInitial, price)
        {
        }
    }
}
