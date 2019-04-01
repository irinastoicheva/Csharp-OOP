namespace P07.InfernoInfinity.Gems
{
    public class Ruby : Gem
    {
        public Ruby(ClarityModified clarity)
            : base(clarity)
        {
            this.Strength = 7 + (int)this.Clarity;
            this.Agility = 2 + (int)this.Clarity;
            this.Vitality = 5 + (int)this.Clarity;
        }
    }
}
