namespace P07.InfernoInfinity.Commands
{
    using Weapons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gems;
    using Contracts;

    public class Add : IExecutable
    {

        private List<Weapon> list;
        private string[] data;

        public Add(string[] input, List<Weapon> list)
        {
            this.data = input;
            this.list = list;
        }

        public void Execute()
        {
            string[] gemInfo = this.data[3].Split();
            string gemType = gemInfo[1];
            string clarity = gemInfo[0];

            Type classType = typeof(Add).Assembly.GetTypes().FirstOrDefault(x => x.Name == gemType);

            var gem = (Gem)Activator.CreateInstance(classType, new object[] { (ClarityModified)Enum.Parse(typeof(ClarityModified), clarity) });

            string name = this.data[1];
            int index = int.Parse(this.data[2]);
            Weapon instance = list.FirstOrDefault(x => x.Name == name);
            instance.AddGem(index, gem);
        }
    }
}
