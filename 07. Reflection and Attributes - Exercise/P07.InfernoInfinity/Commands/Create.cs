namespace P07.InfernoInfinity.Commands
{
    using Weapons;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Contracts;

    public class Create : IExecutable
    {
        private List<Weapon> list;
        private string[] data;

        public Create(string[] input, List<Weapon> list)
        {
            this.data = input;
            this.list = list;
        }

        public void Execute()
        {
            string[] weaponInfo = this.data[1].Split();
            string weaponType = weaponInfo[1];
            string levelOfRarity = weaponInfo[0];
            string name = this.data[2];

            var classType = typeof(Startup).Assembly.GetTypes().FirstOrDefault(x => x.Name == weaponType);

            var instance = (Weapon)Activator.CreateInstance(classType, new object[] { name, (DamageModified)Enum.Parse(typeof(DamageModified), levelOfRarity) });
            list.Add(instance);
        }
    }
}
