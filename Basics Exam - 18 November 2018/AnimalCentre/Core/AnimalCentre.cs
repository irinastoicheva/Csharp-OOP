using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IHotel hotel;
        private Dictionary<string, IProcedure> list;
        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.list = new Dictionary<string, IProcedure>();
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Type classType = typeof(AnimalCentre).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            IAnimal instance = (IAnimal)Activator.CreateInstance(classType, new object[] { name, energy, happiness, procedureTime });

            this.hotel.Accommodate(instance);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "Chip");

            return $"{animalName} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "Vaccinate");

            return $"{animalName} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "Fitness");

            return $"{animalName} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "Play");

            return $"{animalName} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "DentalCare");

            return $"{animalName} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            string animalName = MoveProcedure(name, procedureTime, "NailTrim");

            return $"{animalName} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = this.hotel.Animals[animalName];

            this.hotel.Adopt(animalName, owner);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            IProcedure procedure = this.list[type];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{type}");
            foreach (IAnimal animal in procedure.ProcedureHistory)
            {
                sb.AppendLine($"    {animal.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string MoveProcedure(string name, int procedureTime, string type)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = this.hotel.Animals[name];
                        
            if (!this.list.ContainsKey(type))
            {
                Type classType = typeof(AnimalCentre).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

                IProcedure newProcedure = (IProcedure)Activator.CreateInstance(classType, new object[] { });

                this.list[type] = newProcedure;
            }

            IProcedure procedure = list[type];

            procedure.DoService(animal, procedureTime);

            return $"{animal.Name}";
        }
    }
}
