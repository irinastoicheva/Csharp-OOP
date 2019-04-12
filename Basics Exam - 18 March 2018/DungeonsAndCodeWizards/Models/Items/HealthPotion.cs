namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int WeightConst = 5;
        public HealthPotion()
            : base(WeightConst) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
