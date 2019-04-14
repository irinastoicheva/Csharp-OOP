using MortalEngines.Core.Contracts;
using System;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;
        public Engine(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "Quit")
            {
                try
                {
                    MoveCommand(inputLine, machinesManager);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetBaseException().Message}");
                }

                inputLine = Console.ReadLine();
            }

        }

        public void MoveCommand(string inputLine, IMachinesManager mm)
        {
            string[] input = inputLine.Split();
            string command = input[0];
            switch (command)
            {
                case "HirePilot":
                    Console.WriteLine(mm.HirePilot(input[1])); break;
                case "PilotReport":
                    Console.WriteLine(mm.PilotReport(input[1])); break;
                case "ManufactureTank":
                    Console.WriteLine(mm.ManufactureTank(input[1], double.Parse(input[2]), double.Parse(input[3]))); break;
                case "ManufactureFighter":
                    Console.WriteLine(mm.ManufactureFighter(input[1], double.Parse(input[2]), double.Parse(input[3]))); break;
                case "MachineReport":
                    Console.WriteLine(mm.MachineReport(input[1])); break;
                case "AggressiveMode":
                    Console.WriteLine(mm.ToggleFighterAggressiveMode(input[1])); break;
                case "DefenseMode":
                    Console.WriteLine(mm.ToggleTankDefenseMode(input[1])); break;
                case "Engage":
                    Console.WriteLine(mm.EngageMachine(input[1], input[2])); break;
                case "Attack":
                    Console.WriteLine(mm.AttackMachines(input[1], input[2])); break;
                default: break;
            }
        }
    }
}
