namespace P07_FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void Add(Person person)
        {
            this.People.Add(person);
        }

        public Person GetChild(string child)
        {
            Person currentChild;
            if (child.Split(" ", StringSplitOptions.RemoveEmptyEntries).Count() == 2)
            {
                currentChild = this.People.FirstOrDefault(x => x.Name == child);
            }
            else
            {
                currentChild = this.People.FirstOrDefault(x => x.Birthday == child);
            }

            return currentChild;
        }

        public Person GetParent(string parent)
        {
            Person currentParent;
            if (parent.Split(" ", StringSplitOptions.RemoveEmptyEntries).Count() == 2)
            {
                currentParent = this.People.FirstOrDefault(x => x.Name == parent);
            }
            else
            {
                currentParent = this.People.FirstOrDefault(x => x.Birthday == parent);
            }

            return currentParent;
        }
    }
}
