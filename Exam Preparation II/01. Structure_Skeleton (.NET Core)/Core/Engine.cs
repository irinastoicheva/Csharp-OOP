using System;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController controller;
        public Engine(RestaurantController restaurantController)
        {
            this.controller = restaurantController;
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                try
                {
                    MoveCommand(inputLine, controller);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetBaseException().Message}");
                }
                
                inputLine = Console.ReadLine();
            }

            Console.WriteLine(controller.GetSummary());
        }

        public void MoveCommand(string inputLine, RestaurantController rc)
        {
            string[] input = inputLine.Split();
            string command = input[0];
            switch (command)
            {
                case "AddFood":
                    Console.WriteLine(rc.AddFood(input[1], input[2], decimal.Parse(input[3]))); break;
                case "AddDrink":
                    Console.WriteLine(rc.AddDrink(input[1], input[2], int.Parse(input[3]), input[4])); break;
                case "AddTable":
                    Console.WriteLine(rc.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3]))); break;
                case "ReserveTable":
                    Console.WriteLine(rc.ReserveTable(int.Parse(input[1]))); break;
                case "OrderFood":
                    Console.WriteLine(rc.OrderFood(int.Parse(input[1]), input[2])); break;
                case "OrderDrink":
                    Console.WriteLine(rc.OrderDrink(int.Parse(input[1]), input[2], input[3])); break;
                case "LeaveTable":
                    Console.WriteLine(rc.LeaveTable(int.Parse(input[1]))); break;
                case "GetFreeTablesInfo":
                    Console.WriteLine(rc.GetFreeTablesInfo()); break;
                case "GetOccupiedTablesInfo":
                    Console.WriteLine(rc.GetOccupiedTablesInfo()); break;
                default: break;
            }
        }
    }
}
