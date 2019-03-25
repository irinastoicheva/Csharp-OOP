namespace P09.CollectionHierarchy
{
    using System.Collections.Generic;

    public class MyList : IAdd, IRemove
    {
        private List<string> list;
        public MyList()
        {
            this.list = new List<string>();
            this.Counter = 0;
        }

        public int Counter { get; set; }

        public int Add(string element)
        {
            this.list.Insert(0, element);
            this.Counter++;
            return 0;
        }

        public string RemoveElement()
        {
            string element = this.list[0];
            this.list.RemoveAt(0);
            this.Counter--;
            return element;
        }
    }
}
