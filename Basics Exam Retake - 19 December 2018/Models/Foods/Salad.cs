namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        public const int ServingSizeInitial = 300;

        public Salad(string name, decimal price) : base(name, ServingSizeInitial, price)
        {
        }
    }
}
