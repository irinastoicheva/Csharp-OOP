namespace P06.Animals
{
    using System;

    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        protected string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }
        protected int Age
        {
            get => this.age;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }
        protected string Gender
        {
            get => this.gender;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }


        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}\n{this.Name} {this.Age} {this.Gender}\n{ProduceSound()}";
        }
    }
}
