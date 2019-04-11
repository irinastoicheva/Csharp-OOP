namespace StorageMaster
{
    using Models.Storage;
    using Models.Vehicles;
    using Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private List<Product> products;
        private List<Storage> storages;
        private Vehicle selectedVehicle = null;
        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storages = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var classType = typeof(StorageMaster).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (classType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            var instance = (Product)Activator.CreateInstance(classType, new object[] { price });

            this.products.Add(instance);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var classType = typeof(StorageMaster).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (classType == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            var instance = (Storage)Activator.CreateInstance(classType, new object[] { name });

            this.storages.Add(instance);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            this.selectedVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.selectedVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int count = 0;
            foreach (var productName in productNames)
            {
                if (this.products.Any(x => x.GetType().Name == productName))
                {
                    Product product = this.products.FirstOrDefault(x => x.GetType().Name == productName);
                    this.selectedVehicle.LoadProduct(product);
                    this.products.Remove(product);
                    count++;
                }
            }

            return $"Loaded {count}/{productNames.Count()} products into {selectedVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourseStorage = this.storages.FirstOrDefault(x => x.Name == sourceName);
            if (sourseStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Vehicle vehicle = sourseStorage.GetVehicle(sourceGarageSlot);

            Storage destinationStorege = this.storages.FirstOrDefault(x => x.Name == destinationName);
            if (destinationStorege == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }


            int index = sourseStorage.SendVehicleTo(sourceGarageSlot, destinationStorege);

            return $"Sent {vehicle.GetType().Name} to {destinationStorege.Name} (slot {index})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int counterTruncProducts = vehicle.Trunk.Count;

            int counter = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {counter}/{counterTruncProducts} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);

            var sortedProducts = storage.Products.GroupBy(x => x.GetType().Name).OrderByDescending(x => x.Count()).ThenBy(x => x.GetType().Name);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Stock({products.Sum(x => x.Weight)}/{ storage.Capacity}): [{string.Join(", ", sortedProducts)}]");

            sb.AppendLine($"Garage: [{string.Join("|", storage.Garage)}]");

            return sb.ToString();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var storage in this.storages.OrderByDescending(x => x.Products.Sum(y => y.Price)))
            {
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(x => x.Price):f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
