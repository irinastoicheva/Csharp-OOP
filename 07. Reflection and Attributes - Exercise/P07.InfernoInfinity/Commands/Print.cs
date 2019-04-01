namespace P07.InfernoInfinity.Commands
{
    using Weapons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Print : IExecutable
    {

        private List<Weapon> list;
        private string[] data;

        public Print(string[] input, List<Weapon> list)
        {
            this.data = input;
            this.list = list;
        }

        public void Execute()
        {
            string name = this.data[1];
            Weapon instance = list.FirstOrDefault(x => x.Name == name);
            Console.WriteLine(instance.Print());
        }
    }
}
