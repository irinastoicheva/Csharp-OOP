namespace SoftUniRestaurant.Core
{
    using Models.Foods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal income;
        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.income = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            var classType = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);
            IFood food = (IFood)Activator.CreateInstance(classType, new object[] {name, price});

            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var classType = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            IDrink drink = (IDrink)Activator.CreateInstance(classType, new object[] { name, servingSize, brand });

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var classType = typeof(RestaurantController).Assembly.GetTypes().FirstOrDefault(x => x.Name == type + "Table");

            ITable table = (ITable)Activator.CreateInstance(classType, new object[] { tableNumber, capacity });

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.Where(x => x.IsReserved == false).FirstOrDefault(x => x.Capacity >= numberOfPeople);

            if (table != null)
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }

            return $"No available table for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood food = this.menu.FirstOrDefault(x => x.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table with { tableNumber}";
            }

            IDrink drink = this.drinks.Where(x => x.Name == drinkName && x.Brand == drinkBrand).FirstOrDefault();

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            decimal bill = table.GetBill();

            this.income += bill;

            table.Clear();

            return $"Table: {tableNumber}\nBill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine($"{item.GetFreeTableInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine($"{item.GetOccupiedTableInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
