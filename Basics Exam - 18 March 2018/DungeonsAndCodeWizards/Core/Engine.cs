using System;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        private bool gameOver;
        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
            gameOver = false;
        }

        public void Run()
        {
            string inputLine = Console.ReadLine();

            while (this.gameOver == false)
            {
                try
                {
                    MoveCommand(inputLine, dungeonMaster);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetBaseException().Message}");
                }

                if (this.gameOver == true)
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(dungeonMaster.GetStats());
                    return;
                }

                inputLine = Console.ReadLine();
            }

        }

        public void MoveCommand(string inputLine, DungeonMaster dm)
        {
            string[] input = inputLine.Split();
            string command = input[0];

            string[] args = new string[input.Length - 1];
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = input[i + 1];
            }

            switch (command)
            {
                case "JoinParty":
                    Console.WriteLine(dm.JoinParty(args)); break;
                case "AddItemToPool":
                    Console.WriteLine(dm.AddItemToPool(args)); break;
                case "PickUpItem":
                    Console.WriteLine(dm.PickUpItem(args)); break;
                case "UseItem":
                    Console.WriteLine(dm.UseItem(args)); break;
                case "UseItemOn":
                    Console.WriteLine(dm.UseItemOn(args)); break;
                case "GiveCharacterItem":
                    Console.WriteLine(dm.GiveCharacterItem(args)); break;
                case "GetStats":
                    Console.WriteLine(dm.GetStats()); break;
                case "Attack":
                    Console.WriteLine(dm.Attack(args)); break;
                case "Heal":
                    Console.WriteLine(dm.Heal(args)); break;
                case "EndTurn":
                    Console.WriteLine(dm.EndTurn(args));
                    this.gameOver = dm.IsGameOver(); break;

                default: break;
            }
        }
    }
}
