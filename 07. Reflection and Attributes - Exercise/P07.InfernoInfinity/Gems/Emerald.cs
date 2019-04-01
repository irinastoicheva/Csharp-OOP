namespace P07.InfernoInfinity.Gems
{
    public class Emerald : Gem
    {
        public Emerald(ClarityModified clarity) 
            : base(clarity)
        {
            this.Strength = 1 + (int)this.Clarity;
            this.Agility = 4 + (int)this.Clarity;
            this.Vitality = 9 + (int)this.Clarity;
        }
    }
}
