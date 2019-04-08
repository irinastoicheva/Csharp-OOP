namespace SoftUniRestaurant.Models.Tables
{
    public class InsideTable : Table
    {
        public const decimal PricePerPersonInicial = 2.50M;
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, PricePerPersonInicial)
        {
        }
    }
}
