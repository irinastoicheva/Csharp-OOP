namespace StorageMaster.Models.Storage
{
    using Models.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int CapacityConst = 1;
        private const int GarageSlotsConst = 2;

        public AutomatedWarehouse(string name)
            : base(name, CapacityConst, GarageSlotsConst, new Vehicle[] { new Truck() }) { }
    }
}
