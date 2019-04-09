using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure :IProcedure
    {
        private readonly List<IAnimal> procedureHistory;
        public Procedure()
        {
            this.ProcedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory { get; set; }
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var item in this.procedureHistory)
            {
                sb.AppendLine($"    - {item.Name} - Happiness: {item.Happiness} - Energy: {item.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            else
            {
                animal.ProcedureTime -= procedureTime;
            }
        }
    }
}
