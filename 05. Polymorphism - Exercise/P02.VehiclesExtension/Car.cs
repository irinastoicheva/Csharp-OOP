namespace P02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double capacity) : base(fuelQuantity, capacity)
        {
            this.FuelConsumption = fuelConsumption + 0.9;
        }

        public override void AddFuel(double fuel)
        {
            base.AddFuel(fuel);
            this.FuelQuantity += fuel;
        }
    }
}
