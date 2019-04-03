using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P02.ExtendedDatabase
{
    public class Database
    {
        private const int DefaultSize = 16;
        private IPerson[] database;
        private int index;

        public Database(params IPerson[] database)
        {
            this.index = 0;
            this.DatabaseElements = database;
        }

        public IPerson[] DatabaseElements
        {
            get
            {
                List<IPerson> persons = new List<IPerson>();
                for (int i = 0; i < this.index; i++)
                {
                    persons.Add(this.database[i]);
                }

                return persons.ToArray();
            }
            set
            {
                if (value.Length > DefaultSize || value.Length < 1)
                {
                    throw new InvalidOperationException("Invalid collection size");
                }

                this.database = new IPerson[DefaultSize];
                for (int i = 0; i < value.Length; i++)
                {
                    if (!ChecksForTheExistenceOfThisPerson(value[i]))
                    {
                        throw new InvalidOperationException("Invalid collection");
                    }

                    this.database[this.index] = value[i];
                    index++;
                }
            }
        }

        public void Add(IPerson person)
        {
            if (!ChecksForTheExistenceOfThisPerson(person))
            {
                throw new InvalidOperationException("This user already exists in the collection");
            }

            if (this.index == DefaultSize)
            {
                throw new InvalidOperationException("This collection is full");
            }

            this.database[this.index] = person;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }
            this.database[this.index - 1] = null;
            this.index--;
        }

        public IPerson FindByUsername(string name)
        {
            Person person = null;
            for (int i = 0; i < this.index; i++)
            {
                if (this.database[i].Name == name)
                {
                    person = new Person(database[i].Id, database[i].Name);
                    return person;
                }
            }

            throw new InvalidOperationException("Is no such this person");
        }

        public IPerson FindById(long id)
        {
            IPerson person = null;
            for (int i = 0; i < this.index; i++)
            {
                if (this.database[i].Id == id)
                {
                    person = new Person(database[i].Id, database[i].Name);
                }
            }

            if (person == null)
            {
                throw new InvalidOperationException("Is no such this person");
            }
            else if (person != null && person.Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id is negative");
            }
            else
            {
                return person;
            }

        }

        public bool ChecksForTheExistenceOfThisPerson(IPerson person)
        {
            bool isNoSuchPerson = true;

            for (int i = 0; i < this.database.Length; i++)
            {
                if (this.database[i] != null)
                {
                    if (this.database[i].Name == person.Name)
                    {
                        isNoSuchPerson = false;
                    }
                }
            }

            for (int i = 0; i < this.database.Length; i++)
            {
                if (this.database[i] != null)
                {
                    if (this.database[i].Id == person.Id)
                    {
                        isNoSuchPerson = false;
                    }
                }
            }

            return isNoSuchPerson;
        }
    }
}
