namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using Models.Foods.Contracts;
    using Models.Drinks.Contracts;
    using System.Collections.Generic;

    public interface ITable
    {
        decimal Price { get;}
        bool IsReserved { get; }
        decimal PricePerPerson { get; }
        int NumberOfPeople { get; }
        int Capacity { get; }
        int TableNumber { get; }

        void Reserve(int numberOfPeople);
        void OrderFood(IFood food);
        void OrderDrink(IDrink drink);
        decimal GetBill();
        void Clear();
        string GetFreeTableInfo();
        string GetOccupiedTableInfo();
    }
}
