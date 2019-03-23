using System;

namespace P01.Person
{
    public class Child : Person
    {
        private string name;
        private int age;
        public Child(string name, int age) : base(name, age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
            }
        }
    }
}
