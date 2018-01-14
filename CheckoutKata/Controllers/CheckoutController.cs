namespace CheckoutKata.Controllers
{
    using CheckoutKata.Models;

    /// <summary>
    /// A controller for a managing a checkout.
    /// </summary>
    class CheckoutController : ICheckout
    {
        ICheckout checkout;

        /// <summary>
        /// Constructor for a CheckoutController instance.
        /// </summary>
        /// <param name="productInventory">The <see cref="IProductRepository"/> that this checkout should consult for product details.</param>
        public CheckoutController(IProductRepository productInventory)
        {
            this.checkout = new Checkout(productInventory);
        }

        /// <summary>
        /// <see cref="ICheckout.CompleteCheckout"/>
        /// </summary>
        /// <returns>The total price for all scanned items.</returns>
        public int CompleteCheckout()
        {
            return checkout.CompleteCheckout();
        }

        /// <summary>
        /// <see cref="ICheckout.Count(string)"/>
        /// </summary>
        /// <param name="sku">The <see cref="Product.Sku"/> for the scanned products to count.</param>
        /// <returns>The number of scanned products with matching <see cref="Product.Sku"/>.</returns>
        public int Count(string sku)
        {
            return checkout.Count(sku);
        }

        /// <summary>
        /// <see cref="ICheckout.CountAll"/>
        /// </summary>
        /// <returns>The total number of scanned products.</returns>
        public int CountAll()
        {
            return checkout.CountAll();
        }

        /// <summary>
        /// <see cref="ICheckout.GetTotalPrice"/>
        /// </summary>
        /// <returns>The total number of scanned products.</returns>
        public int GetTotalPrice()
        {
            return this.checkout.GetTotalPrice();
        }

        /// <summary>
        /// <see cref="ICheckout.Remove(Product)"/>
        /// </summary>
        /// <param name="product">The product to remove.</param>
        /// <returns>Whether an instance of this product was removed from the collection of scanned products.</returns>
        public bool Remove(Product product)
        {
            return this.checkout.Remove(product);
        }

        /// <summary>
        /// Adds an item to the colelction of scanned items.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to scan.</param>
        public void Scan(Product product)
        {
            this.checkout.Scan(product);
        }
    }
}
