namespace P07.InfernoInfinity.Weapons
{
    using Gems;

    public abstract class Weapon
    {
        protected int strength;
        protected int agility;
        protected int vitality;

        public Weapon(string name, DamageModified levelOfRarity)
        {
            this.Name = name;
            this.LevelOfRarity = levelOfRarity;
            this.strength = 0;
            this.agility = 0;
            this.vitality = 0;
        }
        public string Name { get; set; }

        public int MinDamage { get; set; }

        public int MaxDamage { get; set; }

        public Gem[] Sockets { get; set; }

        public DamageModified LevelOfRarity {get; set;}

        public void AddGem(int index, Gem gem)
        {
            if (this.Sockets.Length - 1 >= index)
            {
                this.Sockets[index] = gem;
            }
        }
        public void RemoveGem(int index)
        {
            if (this.Sockets.Length - 1 >= index)
            {
                this.Sockets[index] = null;
            }
        }

        public void CalculateStatistic()
        {
            foreach (Gem item in this.Sockets)
            {
                if (item != null)
                {
                    this.MinDamage += 2 * item.Strength;
                    this.MaxDamage += 3 * item.Strength;
                    this.MinDamage += 1 * item.Agility;
                    this.MaxDamage += 4 * item.Agility;
                    this.strength += item.Strength;
                    this.agility += item.Agility;
                    this.vitality += item.Vitality;
                }
            }
        }

        public string Print()
        {
            CalculateStatistic();
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.strength} Strength, +{this.agility} Agility, +{this.vitality} Vitality";
        }
    }
}
