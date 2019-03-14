namespace P04.HotelReservation
{
    public class DiscountForSeason
    {
        public int Discount(Holiday holiday)
        {
            int discount;
            if (holiday.Season == "Autumn")
            {
                discount = (int)Seasons.Autumn;
            }
            else if (holiday.Season == "Summer")
            {
                discount = (int)Seasons.Summer;
            }
            else if (holiday.Season == "Spring")
            {
                discount = (int)Seasons.Spring;
            }
            else if (holiday.Season == "Winter")
            {
                discount = (int)Seasons.Winter;
            }
            else
            {
                discount =0;
            }
            return discount;
        }
    }
}
