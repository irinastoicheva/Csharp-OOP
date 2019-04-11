namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int CapacityConst = 10;

        public Semi()
            : base(CapacityConst) { }
    }
}
