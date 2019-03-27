namespace P03.WildFarm
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string inputLine = Console.ReadLine();
            
            while (inputLine != "End")
            {
                string[] information = inputLine.Split();

                Animal animal = CreateAnimal(information);

                string[] informationFood = Console.ReadLine().Split();

                Food food = CreateFood(informationFood);

                if (animal != null)
                {
                    animals.Add(animal);
                    Console.WriteLine(animal.AskForFood());

                    if (food != null)
                    {
                        try
                        {
                            animal.Eat(food);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                }

                inputLine = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

        }

        private static Food CreateFood(string[] informationFood)
        {
            string type = informationFood[0];
            int quantity = int.Parse(informationFood[1]);
            switch (type)
            {
                case "Vegetable":
                    Food food = new Vegetable(quantity);
                    return food;

                case "Fruit":
                    food = new Fruit(quantity);
                    return food;

                case "Meat":
                    food = new Meat(quantity);
                    return food;

                case "Seeds":
                    food = new Seeds(quantity);
                    return food;

                default:
                    return null;
            }
        }

        private static Animal CreateAnimal(string[] information)
        {
            string type = information[0];
            string name = information[1];
            double weight = double.Parse(information[2]);

            switch (type)
            {
                case "Owl":
                    double wingSize = double.Parse(information[3]);
                    Animal animal = new Owl(name, weight, wingSize);
                    return animal;

                case "Hen":
                    wingSize = double.Parse(information[3]);
                    animal = new Hen(name, weight, wingSize);
                    return animal;

                case "Mouse":
                    string livingRegion = information[3];
                    animal = new Mouse(name, weight, livingRegion);
                    return animal;

                case "Dog":
                    livingRegion = information[3];
                    animal = new Dog(name, weight, livingRegion);
                    return animal;

                case "Cat":
                    livingRegion = information[3];
                    string breed = information[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    return animal;

                case "Tiger":
                    livingRegion = information[3];
                    breed = information[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    return animal;
                default:
                    return null;
            }
        }
    }
}
