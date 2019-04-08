namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        public const decimal PricePerPersonInicial = 3.50M;
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, PricePerPersonInicial)
        {
        }
    }
}
