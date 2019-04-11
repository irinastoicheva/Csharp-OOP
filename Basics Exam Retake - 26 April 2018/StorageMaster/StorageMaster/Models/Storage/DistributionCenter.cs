namespace StorageMaster.Models.Storage
{
    using Models.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int CapacityConst = 2;
        private const int GarageSlotsConst = 5;

        public DistributionCenter(string name)
            : base(name, CapacityConst, GarageSlotsConst, new Vehicle[] { new Van(), new Van(), new Van() }) { }
    }
}
