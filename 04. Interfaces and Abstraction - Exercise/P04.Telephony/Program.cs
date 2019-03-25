namespace P04.Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> phoneNumbers = Console.ReadLine().Split().ToList();
            List<string> uRLs = Console.ReadLine().Split().ToList();

            Smartphone smartphone = new Smartphone();

            Console.WriteLine(smartphone.Call(phoneNumbers));
            Console.WriteLine(smartphone.Web(uRLs));
        }
    }
}
