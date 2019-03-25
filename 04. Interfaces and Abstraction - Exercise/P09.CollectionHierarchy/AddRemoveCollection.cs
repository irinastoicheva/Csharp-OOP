namespace P09.CollectionHierarchy
{
    using System.Collections.Generic;

    public class AddRemoveCollection : IAdd, IRemove
    {
        private List<string> list;

        public AddRemoveCollection()
        {
            this.list = new List<string>();
        }
        public int Add(string element)
        {
            this.list.Insert(0, element);
            return 0;
        }

        public string RemoveElement()
        {
            string element = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            return element;
        }
    }
}
