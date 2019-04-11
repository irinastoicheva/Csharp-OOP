namespace StorageMaster.Models.Storage
{
    using Models.Vehicles;

    public class Warehouse : Storage
    {
        private const int CapacityConst = 10;
        private const int GarageSlotsConst = 10;

        public Warehouse(string name)
            : base(name, CapacityConst, GarageSlotsConst, new Vehicle[] { new Semi(), new Semi(), new Semi() }) { }
    }
}
