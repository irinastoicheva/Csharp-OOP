using AnimalCentre.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure :IProcedure
    {
        private List<IAnimal> procedureHistory;
        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        

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
        }
    }
}
