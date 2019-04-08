namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        public const decimal FuzzyDrinkInitial = 2.50M;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkInitial, brand)
        {
        }
    }
}
