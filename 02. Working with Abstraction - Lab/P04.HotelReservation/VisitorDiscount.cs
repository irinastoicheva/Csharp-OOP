using System;
using System.Collections.Generic;
using System.Text;

namespace P04.HotelReservation
{
    public class VisitorDiscount
    {
        public double Discount(Holiday holiday)
        {
            double discount;
            if (holiday.Discount == "VIP")
            {
                discount = (int)DiscountType.VIP * 1.0 / 100;
            }
            else if (holiday.Discount == "SecondVisit")
            {
                discount = (int)DiscountType.SecondVisit * 1.0 / 100;
            }
            else
            {
                discount = 0;
            }

            return discount;
        }
    }
}
