using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.Database
{
    public class Database
    {
        private const int DefaultSize = 16;
        private int[] database;
        private int index;

        public Database(params int[] database)
        {
            this.index = 0;
            this.DatabaseElements = database;
        }

        public int[] DatabaseElements
        {
            get
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < this.index; i++)
                {
                    numbers.Add(this.database[i]);
                }

                return numbers.ToArray();
            }
            set
            {
                if (value.Length > DefaultSize || value.Length < 1)
                {
                    throw new InvalidOperationException("Invalid collection size");
                }

                this.database = new int[DefaultSize];
                for (int i = 0; i < value.Length; i++)
                {
                    this.database[this.index] = value[i];
                    index++;
                }
            }
        }

        public void Add(int number)
        {
            if (index >= 16)
            {
                throw new InvalidOperationException("Database is full");
            }

            this.database[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }
            this.database[this.index - 1] = default(int);
            this.index--;
        }
    }
}
