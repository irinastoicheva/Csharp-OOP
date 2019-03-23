namespace P04.HotelReservation
{
     public class Holiday
    {
        public Holiday (double priceForDay, int numberOfDays, string season, string discount)
        {
            this.PriceForDay = priceForDay;
            this.NumberOfDays = numberOfDays;
            this.Season = season;
            this.Discount = discount;
        }

        public double PriceForDay { get; set; }

        public int NumberOfDays { get; set; }

        public string Season { get; set; }

        public string Discount { get; set; }
    }
}
