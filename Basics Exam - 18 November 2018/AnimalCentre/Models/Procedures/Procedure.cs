using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure :IProcedure
    {
        protected List<IAnimal> procedureHistory;
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
                sb.AppendLine(item.ToString());
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
