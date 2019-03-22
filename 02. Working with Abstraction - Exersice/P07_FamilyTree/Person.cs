namespace P07_FamilyTree
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Perents = new List<string>();
            this.Children = new List<string>();
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<string> Perents { get; set; }

        public List<string> Children { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}