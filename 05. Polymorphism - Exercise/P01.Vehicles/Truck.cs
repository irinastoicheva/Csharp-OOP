namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity)
        {
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override void AddFuel(double fuel)
        {
            this.FuelQuantity += (fuel * 0.95);
        }
    }
}
