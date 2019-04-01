namespace P07.InfernoInfinity.Weapons
{
    using Gems;

    public class Axe : Weapon
    {
        public Axe(string name, DamageModified levelOfRarity)
            : base(name, levelOfRarity)
        {
            this.MinDamage = 5 * (int)levelOfRarity;
            this.MaxDamage = 10 * (int) levelOfRarity;
            this.Sockets = new Gem[4];
        }
    }
}
