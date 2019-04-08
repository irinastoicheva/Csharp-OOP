namespace SoftUniRestaurant.Models.Tables
{
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
        }

        public decimal Price => this.PricePerPerson * this.numberOfPeople;
        public bool IsReserved { get; private set; }
        public decimal PricePerPerson { get; private set; }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int TableNumber { get; private set; }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            return this.drinkOrders.Sum(x => x.Price) + this.foodOrders.Sum(x => x.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            sb.Append("Food orders: ");
            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine($"{this.foodOrders.Count}");
                foreach (IFood item in this.foodOrders)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }

            sb.Append("Drink orders: ");
            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine($"{this.drinkOrders.Count}");
                foreach (IDrink item in this.drinkOrders)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            if (this.Capacity >= numberOfPeople && this.IsReserved == false)
            {
                this.NumberOfPeople = numberOfPeople;
                this.IsReserved = true;
            }
        }
    }
}
