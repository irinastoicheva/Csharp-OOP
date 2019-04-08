namespace AnimalCentre.Models
{
    using Models.Contracts;
    using System;
    public abstract class Animal : IAnimal
    {
        private int happiness;
        private int energy;
        public Animal(string name, int energy, int happiness, int procedureTime) 
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.IsVaccinated = false;
            this.IsChipped = false;
            this.IsAdopt = false;
            this.Owner = "Centre";
        }

        public int Energy
        {
            get => this.energy;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public bool IsVaccinated { get; private set; }
        public bool IsChipped { get; private set; }
        public bool IsAdopt { get; private set; }
        public string Owner { get; private set; }
        public int ProcedureTime { get; private set; }
        public string Name { get; private set; }
        public int Happiness
        {
            get => this.happiness;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public override string ToString()
        {
            return $"Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
