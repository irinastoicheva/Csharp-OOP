namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string inputLine = Console.ReadLine();

            List<string> commands = new List<string>();

            Family family = new Family();
            while (inputLine != "End")
            {
                string[] information = inputLine.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (information.Length == 1)
                {
                    string[] informationForPerson = information[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = $"{informationForPerson[0]} {informationForPerson[1]}";
                    string birthday = informationForPerson[2];

                    if (!family.People.Any(x => x.Name == name))
                    {
                        Person currentPerson = new Person(name, birthday);
                        family.People.Add(currentPerson);
                    }
                }
                else
                {
                    commands.Add(inputLine);
                }

                inputLine = Console.ReadLine();
            }

            foreach (string command in commands)
            {
                string[] information = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string parent = information[0];
                string child = information[1];

                Person currentPerson;
                if (parent.Split(" ", StringSplitOptions.RemoveEmptyEntries).Count() == 1)
                {
                    currentPerson = family.People.FirstOrDefault(x => x.Birthday == parent);
                }
                else
                {
                    currentPerson = family.People.FirstOrDefault(x => x.Name == parent);
                }

                currentPerson.Children.Add(child);

                if (child.Split(" ", StringSplitOptions.RemoveEmptyEntries).Count() == 1)
                {
                    currentPerson = family.People.FirstOrDefault(x => x.Birthday == child);
                }
                else
                {
                    currentPerson = family.People.FirstOrDefault(x => x.Name == child);
                }

                currentPerson.Perents.Add(parent);
            }

            Person person;
            if (input.Length == 1)
            {
                person = family.People.FirstOrDefault(x => x.Birthday == input[0]);
            }
            else
            {
                string name = $"{input[0]} {input[1]}";
                person = family.People.FirstOrDefault(x => x.Name == name);
            }

            Console.WriteLine(person);
            Console.WriteLine("Parents:");
            foreach (string parent in person.Perents)
            {
                Person currentParent = family.GetParent(parent);               
                Console.WriteLine(currentParent);
            }

            Console.WriteLine("Children:");
            foreach (string child in person.Children)
            {
                Person currentChild = family.GetChild(child);
                Console.WriteLine(currentChild);
            }
        }
    }
}