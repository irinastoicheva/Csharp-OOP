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
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public bool IsVaccinated { get; set; }
        public bool IsChipped { get; set; }
        public bool IsAdopt { get; set; }
        public string Owner { get; set; }
        public int ProcedureTime { get; set; }
        public string Name { get; private set; }
        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public abstract string ToString();
    }
}
