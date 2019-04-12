namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int WeightConst = 10;

        public ArmorRepairKit()
            : base(WeightConst) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}
