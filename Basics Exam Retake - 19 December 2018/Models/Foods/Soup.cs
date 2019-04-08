namespace SoftUniRestaurant.Models.Foods
{
    using Models.Foods.Contracts;

    public class Soup : Food
    {
        public const int ServingSizeInitial = 245;

        public Soup(string name, decimal price) : base(name, ServingSizeInitial, price)
        {
        }
    }
}
