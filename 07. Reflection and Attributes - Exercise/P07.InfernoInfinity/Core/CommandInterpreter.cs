namespace P07.InfernoInfinity.Core
{
    using Contracts;
    using Weapons;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter
    {
        private List<Weapon> list;
        private string[] data;

        public CommandInterpreter(string[] input, List<Weapon> list)
        {
            this.data = input;
            this.list = list;
        }

        public void InterpretedCommand()
        {
            string commandName = this.data[0];

            Type classType = typeof(CommandInterpreter).Assembly.GetTypes().FirstOrDefault(x => x.Name == commandName);

            IExecutable command = (IExecutable)Activator.CreateInstance(classType, new Object[] { this.data, this.list});
            command.Execute();
        }
    }
}
