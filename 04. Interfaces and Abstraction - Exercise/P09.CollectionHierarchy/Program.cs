namespace P09.CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> addAddCollection = new List<int>();
            List<int> addAddRemoveCollection = new List<int>();
            List<int> addMyList = new List<int>();

            foreach (var item in input)
            {
                addAddCollection.Add(addCollection.Add(item));
                addAddRemoveCollection.Add(addRemoveCollection.Add(item));
                addMyList.Add(myList.Add(item));
            }

            List<string> removeAddRemoveCollection = new List<string>();
            List<string> removeMyList = new List<string>();

            int numberRemove = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberRemove; i++)
            {
                removeAddRemoveCollection.Add(addRemoveCollection.RemoveElement());
                removeMyList.Add(myList.RemoveElement());
            }

            Console.WriteLine(string.Join(" ", addAddCollection));
            Console.WriteLine(string.Join(" ", addAddRemoveCollection));
            Console.WriteLine(string.Join(" ", addMyList));
            Console.WriteLine(string.Join(" ", removeAddRemoveCollection));
            Console.WriteLine(string.Join(" ", removeMyList));
        }
    }
}
