namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        public const int ServingSizeInitial = 500;

        public MainCourse(string name, decimal price) : base(name, ServingSizeInitial, price)
        {
        }
    }
}
