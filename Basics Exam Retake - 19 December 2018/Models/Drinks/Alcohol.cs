namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        public const decimal AlcoholInitial = 3.50M;
        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, AlcoholInitial, brand)
        {
        }
    }
}
