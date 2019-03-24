namespace P05.Mordor_sCruelPlan
{
    using System;

   public class StartUp
    {
        public static void Main()
        {
            string[] foods = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            FoodFactory foodFactory = new FoodFactory(foods);
            int points = foodFactory.Eat();
            Console.WriteLine(points);

            MoodFactory moodFactory = new MoodFactory(points);
            Console.WriteLine(moodFactory.Mood());
        }
    }
}
