namespace P05_GreedyTimes
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            long bagLimit = long.Parse(Console.ReadLine());
            Bag bag = new Bag(bagLimit);

            string[] seif = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < seif.Length; i += 2)
            {
                long amount = long.Parse(seif[i + 1]);
                string value = seif[i];

                if (value.Length == 3)
                {
                    Cash cash = new Cash(value, amount);
                    bag.AddCash(cash);
                }

                if (value.ToLower().EndsWith("gem") && value.Length >= 4)
                {
                    Gem gem = new Gem(value, amount);
                    bag.AddGem(gem);
                }

                if (value.ToLower() == "gold")
                {
                    Gold gold = new Gold(amount);
                    bag.AddGold(gold);
                }
            }

            Console.WriteLine(bag);
        }
    }
}
