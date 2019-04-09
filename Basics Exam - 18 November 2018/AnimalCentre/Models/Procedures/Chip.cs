using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal,procedureTime);

            if (animal.IsChipped == false)
            {
                animal.IsChipped = true;
                animal.Happiness -= 5;
                this.procedureHistory.Add(animal);
            }
            else
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
        }
    }
}
