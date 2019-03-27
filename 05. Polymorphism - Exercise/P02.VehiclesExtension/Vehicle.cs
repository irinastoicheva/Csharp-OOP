using System;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double capacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.Capacity = capacity;
            if (this.FuelQuantity > this.Capacity)
            {
                this.FuelQuantity = 0;
            }
        }
        protected double FuelQuantity { get; set; }
       
        protected double FuelConsumption { get; set; }
        protected double Capacity { get; set; }

        public virtual void AddFuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (fuel + this.FuelQuantity > this.Capacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
        }
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
