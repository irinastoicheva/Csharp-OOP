namespace P02.VehiclesExtension
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] information = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(information[1]);
            double fuelConsumption = double.Parse(information[2]);
            double capacity = double.Parse(information[3]);
            Car car = new Car(fuelQuantity, fuelConsumption, capacity);

            information = Console.ReadLine().Split();
            fuelQuantity = double.Parse(information[1]);
            fuelConsumption = double.Parse(information[2]);
            capacity = double.Parse(information[3]);
            Truck truck = new Truck(fuelQuantity, fuelConsumption, capacity);

            information = Console.ReadLine().Split();
            fuelQuantity = double.Parse(information[1]);
            fuelConsumption = double.Parse(information[2]);
            capacity = double.Parse(information[3]);
            Bus bus = new Bus(fuelQuantity, fuelConsumption,capacity);

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] commandLine = Console.ReadLine().Split();

                string command = commandLine[0];
                string vehicle = commandLine[1];
                double number = double.Parse(commandLine[2]);

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            switch (vehicle)
                            {
                                case "Car":
                                    Console.WriteLine(car.Drive(number)); break;

                                case "Truck":
                                    Console.WriteLine(truck.Drive(number)); break;

                                case "Bus":
                                    Console.WriteLine(bus.Drive(number)); break;
                            }
                            break;

                        case "Refuel":
                            switch (vehicle)
                            {
                                case "Car":
                                    car.AddFuel(number); break;

                                case "Truck":
                                    truck.AddFuel(number); break;

                                case "Bus":
                                    bus.AddFuel(number); break;
                            }
                            break;

                        case "DriveEmpty":
                            Console.WriteLine(bus.DriveEmpty(number));
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
