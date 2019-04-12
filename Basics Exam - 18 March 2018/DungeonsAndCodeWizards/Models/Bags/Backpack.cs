namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private const int CapacityConst = 100;

        public Backpack() 
            : base(CapacityConst) { }
    }
}
