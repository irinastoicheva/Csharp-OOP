namespace DungeonsAndCodeWizards.Models
{
    using DungeonsAndCodeWizards.Contracts;
    using Models.Items;
    using System;
    public abstract class Character : IAttackable, IHealable
    {
        private const double RestHealMultiplierDefault = 0.2;

        private double health;
        private string name;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = RestHealMultiplierDefault;
        }

        public Faction Faction { get; private set; }
        public bool IsAlive => this.Health > 0 ? true : false;
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }

                this.armor = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }

                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }

                this.health = value;
            }
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }
        public double AbilityPoints { get; private set; }
        public Bag Bag { get; private set; }
        public double RestHealMultiplier { get; set; }


        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor - hitPoints < 0)
                {
                    double difference = Math.Abs(this.Armor - hitPoints);
                    this.Armor = 0;
                    this.Health -= difference;
                    if (this.Health < 0)
                    {
                        this.Health = 0;
                    }
                }
                else
                {
                    this.Armor -= hitPoints;
                }
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health += (this.BaseHealth * RestHealMultiplier);
                if (this.Health > this.BaseHealth)
                {
                    this.Health = this.BaseHealth;
                }
            }
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                this.Bag.GetItem(item.GetType().Name);
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            string value = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {value}";
        }

        void IAttackable.Attack(Character character)
        {
        }

        void IHealable.Heal(Character character)
        {
        }
    }
}