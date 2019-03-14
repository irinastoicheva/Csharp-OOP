namespace P04.HotelReservation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            double priceForDay = double.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            string discount = string.Empty;

            if (input.Length == 3)
            {
               discount = "None";
            }
            else if (input.Length == 4)
            {
                discount = input[3];
            }

            Holiday holiday = new Holiday(priceForDay, numberOfDays, season, discount);
            PriceCalculator priceCalculator = new PriceCalculator();
            DiscountForSeason discountForSeason = new DiscountForSeason();
            VisitorDiscount visitorDiscount = new VisitorDiscount();

            double price = priceCalculator.Calculate(holiday, discountForSeason, visitorDiscount);

            Console.WriteLine($"{price:F2}");
        }
    }
}
