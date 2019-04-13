namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.5M;

        public FuzzyDrink(string name, int servingSize, string brand)
            : base(name, servingSize, FuzzyDrinkPrice, brand) { }
    }
}
