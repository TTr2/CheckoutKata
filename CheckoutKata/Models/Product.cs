namespace CheckoutKata.Models
{
    using System;

    /// <summary>
    /// Represents a product consisting of an SKU code, a price and a MultiDeal,
    /// which can be added to an inventory of products.
    /// </summary>
    class Product
    {
        /// <summary>
        /// Constructor for a Product with optional MultiDeal reference 
        /// (defaults to a non-valid instance).
        /// </summary>
        /// <param name="sku">The SKU of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="multiDeal">The (optional) MultiDeal of the product.</param>
        public Product(string sku, int price, MultiDeal multiDeal = null)
        {
            this.Sku = string.IsNullOrEmpty(sku) ? throw new ArgumentNullException(nameof(sku)) : sku;
            this.Price = price > 1 ? price : throw new ArgumentException("Price must be greater than zero.");
            this.MultiDeal = multiDeal == null ? new MultiDeal() : multiDeal;
        }

        /// <summary>
        /// The SKU of the product.
        /// </summary>
        internal string Sku { get; }

        /// <summary>
        /// The price of the product (100 = 1 decimal unit).
        /// </summary>
        internal int Price { get; }

        /// <summary>
        /// The MultiDeal for the product, default is non-valid.
        /// </summary>
        internal MultiDeal MultiDeal {get; }

        /// <summary>
        /// Whether the given time is after this Product's MultiDeal starts and 
        /// before it's MultiDeal ends.
        /// </summary>
        /// <param name="now">The current time to check against the MultiDeals 
        /// valid from/before values.</param>
        /// <returns><see cref="Product.IsMultiDealValid(DateTime)"/></returns>
        internal bool IsMultiDealValid(DateTime now)
        {
            return now > this.MultiDeal.ValidFromDate 
                && now < this.MultiDeal.ValidBeforeDate;
        }
    }
}
