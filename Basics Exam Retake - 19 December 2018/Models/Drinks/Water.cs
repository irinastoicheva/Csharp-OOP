namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        public const decimal WaterInitial = 1.50M;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, WaterInitial, brand)
        {
        }
    }
}
