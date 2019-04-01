namespace P07.InfernoInfinity.Gems
{
    public abstract class Gem
    {
        protected Gem(ClarityModified clarity)
        {
            this.Clarity = clarity;
        }
        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Vitality { get; set; }

        protected ClarityModified Clarity { get; set; }
    }
}
