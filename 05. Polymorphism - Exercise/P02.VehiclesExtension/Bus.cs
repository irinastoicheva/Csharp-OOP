namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double capacity) : base(fuelQuantity, capacity)
        {
            this.FuelConsumption = fuelConsumption + 1.4;
        }

        public override void AddFuel(double fuel)
        {
            base.AddFuel(fuel);
            this.FuelQuantity += fuel;
        }

        public string DriveEmpty(double distance)
        {
            if (distance <= this.FuelQuantity / (this.FuelConsumption - 1.4))
            {
                this.FuelQuantity -= distance * (this.FuelConsumption - 1.4);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}
