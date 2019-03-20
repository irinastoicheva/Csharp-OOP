using System;
using System.Collections.Generic;

namespace P04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length == 0 || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            this.bag.Add(product);
            this.money -= product.Cost;
        }

        public override string ToString()
        {
            if (this.bag.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.bag)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought ";
            }
        }
    }
}
