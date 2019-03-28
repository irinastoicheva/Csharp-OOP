﻿namespace P03.DetailPrinter
{
    public class Employee : IPrint
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual string Print()
        {
            return $"{this.Name}";
        }
    }
}
