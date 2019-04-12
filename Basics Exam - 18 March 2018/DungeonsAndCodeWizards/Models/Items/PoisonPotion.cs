namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private const int WeightConst = 5;

        public PoisonPotion()
            : base(WeightConst) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
            if (character.Health < 0)
            {
                character.Health = 0;
            }
        }
    }
}
