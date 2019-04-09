using AnimalCentre.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private AnimalCentre animalCentre;
        private Dictionary<string, List<string>> ownerAnimals;

        public Engine(AnimalCentre animalCentre)
        {
            this.animalCentre = animalCentre;
            this.ownerAnimals = new Dictionary<string, List<string>>();
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                try
                {
                    MoveCommand(inputLine, animalCentre);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetBaseException().GetType().Name}: {ex.GetBaseException().Message}");
                }


                inputLine = Console.ReadLine();
            }

            foreach (var owner in this.ownerAnimals.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }
        }

        public void MoveCommand(string inputLine, AnimalCentre ac)
        {
            string[] input = inputLine.Split();
            string command = input[0];

            switch (command)
            {
                case "RegisterAnimal":
                    Console.WriteLine(ac.RegisterAnimal(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]))); break;
                case "Chip":
                    Console.WriteLine(ac.Chip(input[1], int.Parse(input[2]))); break;
                case "Vaccinate":
                    Console.WriteLine(ac.Vaccinate(input[1], int.Parse(input[2]))); break;
                case "Fitness":
                    Console.WriteLine(ac.Fitness(input[1], int.Parse(input[2]))); break;
                case "Play":
                    Console.WriteLine(ac.Play(input[1], int.Parse(input[2]))); break;
                case "DentalCare":
                    Console.WriteLine(ac.DentalCare(input[1], int.Parse(input[2]))); break;
                case "NailTrim":
                    Console.WriteLine(ac.NailTrim(input[1], int.Parse(input[2]))); break;
                case "Adopt":
                    string animalName = input[1];
                    string owner = input[2];

                    Console.WriteLine(ac.Adopt(animalName, owner));

                    if (!this.ownerAnimals.ContainsKey(owner))
                    {
                        this.ownerAnimals[owner] = new List<string>();
                    }

                    this.ownerAnimals[owner].Add(animalName);

                    break;
                case "History":
                    Console.WriteLine(ac.History(input[1])); break;
                default: break;
            }
        }
    }
}
