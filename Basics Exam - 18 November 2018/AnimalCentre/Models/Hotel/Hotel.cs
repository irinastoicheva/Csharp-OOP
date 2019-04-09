using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        public const int CapacityConst = 10;
        private int capacity;

        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = CapacityConst;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;
        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (this.animals.ContainsKey(animalName))
            {
                IAnimal animal = this.animals[animalName];
                animal.Owner = owner;
                animal.IsAdopt = true;
                this.animals.Remove(animalName);
            }
            else
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }
    }
}
