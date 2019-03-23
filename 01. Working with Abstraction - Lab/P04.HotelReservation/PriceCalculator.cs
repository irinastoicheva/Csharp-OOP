namespace P04.HotelReservation
{
    public class PriceCalculator
    {
        public double Calculate(Holiday holiday, DiscountForSeason discountForSeason, VisitorDiscount visitorDiscount)
        {
            double total = holiday.PriceForDay * holiday.NumberOfDays * discountForSeason.Discount(holiday) * (1 - visitorDiscount.Discount(holiday));
            return total;
        }
    }
}
