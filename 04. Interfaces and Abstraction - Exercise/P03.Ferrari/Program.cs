namespace P03.Ferrari
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();
            ICar ferrari = new Ferrari(driverName);
            Console.WriteLine(ferrari);
        }
    }
}
