namespace P07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<IBuyer> people = new List<IBuyer>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] information = Console.ReadLine().Split();

                if (information.Length == 4)
                {
                    string name = information[0];
                    int age = int.Parse(information[1]);
                    string id = information[2];
                    string birthdate = information[3];
                    IBuyer human = new Human(name, age, id, birthdate);
                    people.Add(human);
                }
                else if (information.Length == 3)
                {
                    string name = information[0];
                    int age = int.Parse(information[1]);
                    string group = information[2];
                    IBuyer buyer = new Rebel(name, age, group);
                    people.Add(buyer);
                }
            }

            string buyingFood = Console.ReadLine();
            List<string> names = new List<string>();

            while (buyingFood != "End")
            {
                names.Add(buyingFood);

                buyingFood = Console.ReadLine();
            }

            foreach (var name in names)
            {
                if (people.Any(x => x.Name == name))
                {
                    IBuyer person = people.FirstOrDefault(x => x.Name == name);
                    person.BuyFood();
                }
            }

            int sumFood = 0;
            foreach (var person in people)
            {
                sumFood += person.Food;
            }

            Console.WriteLine(sumFood);
        }
    }
}
