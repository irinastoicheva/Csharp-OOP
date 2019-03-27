namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override void AddFuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
