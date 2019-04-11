namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int CapacityConst = 5;

        public Truck()
            : base(CapacityConst) { }
    }
}
