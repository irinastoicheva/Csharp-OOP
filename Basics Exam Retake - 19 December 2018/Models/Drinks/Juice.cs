namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        public const decimal JuiceInitial = 1.80M;

        public Juice(string name, int servingSize, string brand) 
            : base(name, servingSize, JuiceInitial, brand)
        {
        }
    }
}
