﻿namespace SoftUniRestaurant.Models.Tables
{
    using Models.Foods.Contracts;
    using Models.Drinks.Contracts;
    using System.Collections.Generic;
    using System;
    using System.Text;
    using Models.Tables.Contracts;
    using System.Linq;

    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        public int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
        }

        public int TableNumber { get; private set; }
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

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }
        public decimal GetBill()
        {
            decimal bill = this.foodOrders.Sum(x => x.Price) + this.drinkOrders.Sum(x => x.Price) + this.Price;
            return bill;
        }
        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                foreach (var item in this.foodOrders)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                foreach (var item in this.drinkOrders)
                {
                    sb.AppendLine(item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
