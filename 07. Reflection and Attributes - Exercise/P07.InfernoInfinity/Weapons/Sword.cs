namespace P07.InfernoInfinity.Weapons
{
    using Gems;

    public class Sword : Weapon
    {
        public Sword(string name, DamageModified levelOfRarity)
            : base(name, levelOfRarity)
        {
            this.MinDamage = 4 * (int)levelOfRarity;
            this.MaxDamage = 6 * (int)levelOfRarity;
            this.Sockets = new Gem[3];
        }
    }
}
