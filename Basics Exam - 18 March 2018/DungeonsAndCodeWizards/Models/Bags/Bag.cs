namespace DungeonsAndCodeWizards.Models
{
    using Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public abstract class Bag
    {
        private const int CapacityConst = 100;
        private List<Item> items;

        public Bag()
        {
            this.Capacity = CapacityConst;
            this.items = new List<Item>();
        }
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }
        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();
        public int Load => this.items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);
            return item;
        }
    }
}
