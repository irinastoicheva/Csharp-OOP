namespace P06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<IIdentificator> creatures = new List<IIdentificator>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] information = input.Split();

                if (information.Length == 5 && information[0] == "Citizen")
                {
                    string name = information[1];
                    int age = int.Parse(information[2]);
                    string id = information[3];
                    string birthdate = information[4];
                    IIdentificator human = new Human(name, age, id, birthdate);
                    creatures.Add(human);
                }
                else if (information.Length == 3 && information[0] == "Pet")
                {
                    string name = information[1];
                    string birthdate = information[2];
                    IIdentificator pet = new Pet(name, birthdate);
                    creatures.Add(pet);
                }

                input = Console.ReadLine();
            }

            string birthYear = Console.ReadLine();

            foreach (var item in creatures.Where(x => x.Birthdate.EndsWith(birthYear)))
            {
                Console.WriteLine($"{item.Birthdate}");
            }
        }
    }
}
