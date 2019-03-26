namespace P10.ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
       public static void Main()
        {
            string input = Console.ReadLine();
            List<Citizen> citizens = new List<Citizen>();

            while (input != "End")
            {
                string[] information = input.Split();
                string name = information[0];
                string country = information[1];
                int age = int.Parse(information[2]);

                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);

                input = Console.ReadLine();
            }

            foreach (var item in citizens)
            {
                IResident resident = item;
                IPerson person = item;
                Console.WriteLine($"{person.GetName()}\n{resident.GetName()}");
            }
        }
    }
}
