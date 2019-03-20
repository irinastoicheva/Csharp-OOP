using System;

namespace _05.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double GetCalories()
        {
            return this.Weight * 2 * ModifierType();
        }

        private double ModifierType()
        {
            double extraCaloriesPerGram = 0;
            switch (this.type.ToLower())
            {
                case "meat":
                    extraCaloriesPerGram = 1.2;
                    break;
                case "veggies":
                    extraCaloriesPerGram = 0.8;
                    break;
                case "cheese":
                    extraCaloriesPerGram = 1.1;
                    break;
                case "sauce":
                    extraCaloriesPerGram = 0.9;
                    break;
            }

            return extraCaloriesPerGram;
        }

    }
}
