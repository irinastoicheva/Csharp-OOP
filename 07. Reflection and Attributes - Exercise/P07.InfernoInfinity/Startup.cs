namespace P07.InfernoInfinity
{
    using P07.InfernoInfinity.Core;
    using P07.InfernoInfinity.Weapons;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string[] commandLine = Console.ReadLine().Split(";");
            List<Weapon> list = new List<Weapon>();

            while (commandLine[0] != "END")
            {
                CommandInterpreter command = new CommandInterpreter(commandLine, list);
                command.InterpretedCommand();

                commandLine = Console.ReadLine().Split(";");
            }
        }
    }
}
