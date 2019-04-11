namespace StorageMaster
{
    using Models.Storage;
    using Models.Vehicles;
    using Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> products;
        private List<Storage> storages;
        private Vehicle selectedVehicle = null;
        public StorageMaster()
        {
            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var classType = typeof(StorageMaster).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);

            if (classType == null || classType.IsAbstract)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            var instance = (Product)Activator.CreateInstance(classType, new object[] { price });

            if (!this.products.ContainsKey(type))
            {
                this.products[type] = new Stack<Product>();
            }

            this.products[type].Push(instance);

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
                if (this.selectedVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(productName) || this.products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product product = this.products[productName].Pop();
                this.selectedVehicle.LoadProduct(product);
                count++;
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

            Storage destinationStorege = this.storages.FirstOrDefault(x => x.Name == destinationName);
            if (destinationStorege == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Vehicle vehicle = sourseStorage.GetVehicle(sourceGarageSlot);

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

            Dictionary<string, int> productsAndCount = new Dictionary<string, int>();
            foreach (var item in storage.Products)
            {
                string productTypeName = item.GetType().Name;

                if (!productsAndCount.ContainsKey(productTypeName))
                {
                    productsAndCount[productTypeName] = 0;
                }

                productsAndCount[productTypeName]++;
            }

            double productsSum = storage.Products.Sum(x => x.Weight);

            string[] productsAsString = productsAndCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} ({x.Value})")
                .ToArray();

            string[] storageString = storage.Garage.Select(x => x == null ? "empty" : x.GetType().Name).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Stock ({productsSum}/{storage.Capacity}): [{string.Join(", ", productsAsString)}]");
            sb.AppendLine($"Garage: [{string.Join("|", storageString)}]");

            return sb.ToString().TrimEnd();
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
