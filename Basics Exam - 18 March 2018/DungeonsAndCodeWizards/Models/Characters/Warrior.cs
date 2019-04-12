namespace DungeonsAndCodeWizards.Models.Characters
{
    using Contracts;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction) { }


        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                if (this.Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
