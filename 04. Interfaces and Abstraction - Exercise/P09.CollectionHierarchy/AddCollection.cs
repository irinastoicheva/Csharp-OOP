using System.Collections.Generic;

namespace P09.CollectionHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> list;
        public AddCollection()
        {
            this.list = new List<string>();
        }

        public int Add(string element)
        {
            this.list.Add(element);
            return this.list.Count - 1;
        }
    }
}
