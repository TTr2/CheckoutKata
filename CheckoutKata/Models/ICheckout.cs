namespace CheckoutKata.Models
{
    /// <summary>
    /// Interface representing the actions required for a supermarket checkout.
    /// </summary>
    interface ICheckout
    {
        /// <summary>
        /// Scan an item to add to the total price.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to scan.</param>
        void Scan(Product product);

        /// <summary>
        /// Removes an item from the total price.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to remove.</param>
        /// <returns>Whether the product was removed.</returns>
        bool Remove(Product product);

        /// <summary>
        /// Calculate and return the total price of all products including special offers.
        /// </summary>
        /// <returns>The total price of all products including special offers.</returns>
        int GetTotalPrice();

        /// <summary>
        /// Empties scanned products list and adds processed products to a collction of 
        /// completed transactions. Processed Products are stored as <see cref="Product"/> instances to retain 
        /// the price and special offer conditions active at time of sale.
        /// </summary>
        /// <returns>The total price of all products including </returns>
        int CompleteCheckout();

        /// <summary>
        /// Gets the number of a given <see cref="Product"/> that have been scanned.
        /// </summary>
        /// <param name="sku">THe SKU of the products to count.</param>
        /// <returns>The number of the given Products in the repository.</returns>
        int Count(string sku);

        /// <summary>
        /// Returns the total number of Products scanned.
        /// </summary>
        /// <returns>The total number of Products scanned.</returns>
        int CountAll();
    }
}
