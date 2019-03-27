namespace P01.Vehicles
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] carInformation = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformation[1]);
            double carFuelConsumption = double.Parse(carInformation[2]);
            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckFuelConsumption = double.Parse(truckInformation[2]);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] commandLine = Console.ReadLine().Split();

                string command = commandLine[0];
                string vehicle = commandLine[1];
                double number = double.Parse(commandLine[2]);

                switch (command)
                {
                    case "Drive":
                        switch (vehicle)
                        {
                            case "Car":
                                Console.WriteLine(car.Drive(number)); break;

                            case "Truck":
                                Console.WriteLine(truck.Drive(number)); break;
                        }
                        break;

                    case "Refuel":
                        switch (vehicle)
                        {
                            case "Car":
                                car.AddFuel(number); break;

                            case "Truck":
                                truck.AddFuel(number); break;
                        }
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
