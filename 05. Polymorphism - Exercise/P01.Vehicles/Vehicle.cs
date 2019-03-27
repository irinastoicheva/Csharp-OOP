namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity)
        {
            this.FuelQuantity = fuelQuantity;
        }
        protected double FuelQuantity { get; set; }
        protected double FuelConsumption { get; set; }

        public abstract void AddFuel(double fuel);
        public string Drive(double distance)
        {
            if (distance <= this.FuelQuantity / this.FuelConsumption)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
