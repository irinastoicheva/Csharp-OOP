namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                string[] nameInput = Console.ReadLine().Split();
                string name = nameInput[1];

                string[] doughInformation = Console.ReadLine().Split();
                string flourType = doughInformation[1];
                string bakingTechnique = doughInformation[2];
                double weight = double.Parse(doughInformation[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);

                Pizza pizza = new Pizza(name, dough);

                string toppingInformation = Console.ReadLine();
                while (toppingInformation != "END")
                {
                    string[] parts = toppingInformation.Split();
                    string type = parts[1];
                    weight = double.Parse(parts[2]);

                    Topping topping = new Topping(type, weight);
                    pizza.AddTopping(topping);

                    toppingInformation = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

    }
}
