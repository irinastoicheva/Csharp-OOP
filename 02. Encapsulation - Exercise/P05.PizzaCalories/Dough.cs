using System;

namespace _05.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTehnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTehnique;
            this.Weight = weight;
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public double GetCalories()
        {
            return this.Weight * 2 * ModifierBakingTechnique() * ModifierFlourType();
        }

        private double ModifierFlourType()
        {
            double extraCaloriesPerGram = 0;
            switch (this.flourType.ToLower())
            {
                case "white": extraCaloriesPerGram = 1.5;
                    break;
                case "wholegrain": extraCaloriesPerGram = 1.0;
                    break;
            }

            return extraCaloriesPerGram;
        }

        private double ModifierBakingTechnique()
        {
            double extraCaloriesPerGram = 0;
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    extraCaloriesPerGram = 0.9;
                    break;
                case "chewy":
                    extraCaloriesPerGram = 1.1;
                    break;
                case "homemade":
                    extraCaloriesPerGram = 1.0;
                    break;
            }

            return extraCaloriesPerGram;
        }
    }
}
