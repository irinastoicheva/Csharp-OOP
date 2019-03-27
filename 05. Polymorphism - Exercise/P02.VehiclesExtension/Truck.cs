using System;

namespace P02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double capacity) : base(fuelQuantity, capacity)
        {
            this.FuelConsumption = fuelConsumption + 1.6;
        }

        public override void AddFuel(double fuel)
        {
            base.AddFuel(fuel);
            this.FuelQuantity += (fuel * 0.95);
        }
    }
}
