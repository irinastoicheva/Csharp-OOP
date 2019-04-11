namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private StorageMaster sm;

        public Engine(StorageMaster sm)
        {
            this.sm = sm;
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                try
                {
                    MoveCommand(inputLine, sm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetBaseException().Message}");
                }


                inputLine = Console.ReadLine();
            }

            Console.WriteLine(sm.GetSummary());
        }

        public void MoveCommand(string inputLine, StorageMaster sm)
        {
            string[] input = inputLine.Split();
            string command = input[0];

            switch (command)
            {
                case "AddProduct":
                    Console.WriteLine(sm.AddProduct(input[1], double.Parse(input[2]))); break;
                case "RegisterStorage":
                    Console.WriteLine(sm.RegisterStorage(input[1], input[2])); break;
                case "SelectVehicle":
                    Console.WriteLine(sm.SelectVehicle(input[1], int.Parse(input[2]))); break;
                case "LoadVehicle":
                    List<string> collection = new List<string>();
                    for (int i = 1; i < input.Length; i++)
                    {
                        collection.Add(input[i]);
                    }
                    Console.WriteLine(sm.LoadVehicle(collection)); break;
                case "SendVehicleTo":
                    Console.WriteLine(sm.SendVehicleTo(input[1], int.Parse(input[2]), input[3])); break;
                case "UnloadVehicle":
                    Console.WriteLine(sm.UnloadVehicle(input[1], int.Parse(input[2]))); break;
                case "GetStorageStatus":
                    Console.WriteLine(sm.GetStorageStatus(input[1])); break;
                default: break;
            }
        }
    }
}
