namespace P04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInformation = Console.ReadLine().Split(";");
            for (int i = 0; i < peopleInformation.Length; i++)
            {
                string[] personInformation = peopleInformation[i].Split("=");
                string name = personInformation[0];
                decimal money = decimal.Parse(personInformation[1]);

                try
                {
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productsInformation = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInformation.Length; i++)
            {
                string[] productInformation = productsInformation[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = productInformation[0];
                decimal cost = decimal.Parse(productInformation[1]);
                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = Console.ReadLine(); ;
            while (command != "END")
            {
                string[] parts = command.Split();
                Person person = people.FirstOrDefault(x => x.Name == parts[0]);
                Product product = products.FirstOrDefault(x => x.Name == parts[1]);
                if (person != null && product != null)
                {
                    if (person.Money >= product.Cost)
                    {
                        person.AddProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
        }
    }
}
