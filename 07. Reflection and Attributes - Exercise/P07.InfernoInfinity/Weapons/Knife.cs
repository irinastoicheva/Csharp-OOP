namespace P07.InfernoInfinity.Weapons
{
    using Gems;

    public class Knife : Weapon
    {
        public Knife(string name, DamageModified levelOfRarity)
            : base(name, levelOfRarity)
        {
            this.MinDamage = 3 * (int)levelOfRarity;
            this.MaxDamage = 4 * (int)levelOfRarity;
            this.Sockets = new Gem[2];
        }
    }
}
