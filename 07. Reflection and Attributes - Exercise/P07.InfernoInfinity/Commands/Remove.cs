namespace P07.InfernoInfinity.Commands
{
    using Contracts;
    using Weapons;
    using System.Collections.Generic;
    using System.Linq;

    public class Remove : IExecutable
    {
        private List<Weapon> list;
        private string[] data;

        public Remove(string[] input, List<Weapon> list)
        {
            this.data = input;
            this.list = list;
        }

        public void Execute()
        {
            string name = this.data[1];
            int index = int.Parse(this.data[2]);
            Weapon instance = list.FirstOrDefault(x => x.Name == name);
            instance.RemoveGem(index);
        }
    }
}
