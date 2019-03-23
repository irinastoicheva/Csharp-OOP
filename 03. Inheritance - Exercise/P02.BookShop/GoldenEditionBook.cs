namespace P02.BookShop
{
    using System;

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
        {
        }

        public override decimal Price
        {
            get => base.Price;
            set
            {
                base.Price = value * 1.3M;
            }
        }
    }
}
