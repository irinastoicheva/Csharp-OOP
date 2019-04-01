namespace P07.InfernoInfinity.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(ClarityModified clarity) 
            : base(clarity)
        {
            this.Strength = 2 + (int)this.Clarity;
            this.Agility = 8 + (int)this.Clarity;
            this.Vitality = 4 + (int)this.Clarity;
        }
    }
}
