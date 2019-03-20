using System;
using System.Collections.Generic;

namespace _05.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set
            {
                this.dough = value;
            }
        }

        public int ToppingsCount
        {
            get => this.toppings.Count;
            
        }

        private double GetCalories()
        {
            double calories = this.Dough.GetCalories();
            foreach (var item in this.toppings)
            {
                calories += item.GetCalories();
            }
            return calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {GetCalories():F2} Calories.";
        }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}
