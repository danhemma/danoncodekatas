using System;

namespace KataPotter
{
    public class Order
    {
        private readonly int[] books;
        private readonly decimal[] discounts;

        public Order(params int[] books)
        {
            discounts = new[] { 1m, 0.95m, 0.9m, 0.8m, 0.75m };
            this.books = books;
        }

        public decimal GetPrice()
        {
            decimal minPrice = 8 * books.Length;
            return GetMinPriceForSet(new BookSet(books), minPrice);
        }

        private decimal GetMinPriceForSet(BookSet originalBookSet, decimal minPrice)
        {
            if (originalBookSet.IsEmpty())
                return 0m;

            for (int includeAtMost = 2; includeAtMost <= 5; includeAtMost++)
            {
                var bookSet = originalBookSet.Clone();
                var cart = bookSet.PopCart(includeAtMost);
                minPrice = Math.Min(minPrice,
                    GetPrice(cart, 8m) + GetMinPriceForSet(bookSet, minPrice));
            }
            return minPrice;
        }

        private decimal GetPrice(int[] cart, decimal price)
        {
            return price * cart.Length * discounts[cart.Length - 1];
        }
    }
}