namespace P06.Animals
{
    using System;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                try
                {
                    string typeAnimal = Console.ReadLine();
                    if (typeAnimal == "Beast!")
                    {
                        break;
                    }

                    string[] informationForAnimal = Console.ReadLine().Split();
                    string name = informationForAnimal[0];
                    if (!int.TryParse(informationForAnimal[1], out int age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = string.Empty;
                    if (informationForAnimal.Length == 3)
                    {
                        gender = informationForAnimal[2];
                    }

                    switch (typeAnimal)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
