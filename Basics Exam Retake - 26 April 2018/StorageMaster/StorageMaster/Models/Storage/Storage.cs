namespace StorageMaster.Models.Storage
{
    using Models.Products;
    using Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;
        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];
            this.FiilGarageWhitInitialVehicles(vehicles);
            this.products = new List<Product>();
        }

      
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;
       
        public Vehicle GetVehicle(int garageSlot)
        {
            if (this.GarageSlots < garageSlot)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int indexFreeSlot = deliveryLocation.AddVihicleToGarage(vehicle);
            this.garage[garageSlot] = null;

            return indexFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int counter = 0;
            while (!IsFull && !vehicle.IsEmpty)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);
                counter++;
            }
           
            return counter;
        }

        private int AddVihicleToGarage(Vehicle vehicle)
        {
            int indexFreeSlot = -1;
            for (int i = 0; i < this.garage.Length; i++)
            {
                if (this.garage[i] == null)
                {
                    indexFreeSlot = i;
                    break;
                }
            }

            if (indexFreeSlot != -1)
            {
                this.garage[indexFreeSlot] = vehicle;
            }
            else
            {
                throw new InvalidOperationException("No room in garage!");
            }

            return indexFreeSlot;
        }

        private void FiilGarageWhitInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            int counter = 0;
            foreach (var item in vehicles)
            {
                this.garage[counter] = item;
                counter++;
            }
        }
    }
}
