namespace P05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<IIdentificator> waiting = new List<IIdentificator>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] information = input.Split();

                if (information.Length == 3)
                {
                    string name = information[0];
                    int age = int.Parse(information[1]);
                    string id = information[2];
                    IIdentificator human = new Human(name, age, id);
                    waiting.Add(human);
                }
                else if (information.Length == 2)
                {
                    string model = information[0];
                    string id = information[1];
                    IIdentificator robot = new Robot(model, id);
                    waiting.Add(robot);
                }

                input = Console.ReadLine();
            }

            string controlId = Console.ReadLine();

            foreach (var item in waiting.Where(x => x.Id.EndsWith(controlId)))
            {
                Console.WriteLine($"{item.Id}");
            }
        }
    }
}
