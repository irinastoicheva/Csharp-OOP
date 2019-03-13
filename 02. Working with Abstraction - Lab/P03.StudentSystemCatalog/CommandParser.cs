namespace P03.StudentSystemCatalog
{
    using System;
    using System.Linq;

    public class CommandParser
    {
        public Command Parse(string input)
        {
            string[] parts = input.Split();
            string name = parts[0];
            string[] arguments = parts.Skip(1).ToArray();
            Command command = new Command(name, arguments);

            return command;
        }
    }
}
