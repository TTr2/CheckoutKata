namespace CheckoutKata.Models
{
    interface IProductRepositoryBulkActions : IProductRepository
    {
        /// <summary>
        /// Adds products in bulk to Shopping Trolley.
        /// </summary>
        /// <param name="sku">The <see cref="Product"/> to add in bulk.</param>
        /// <param name="units">The number of units to add.</param>
        void AddBulk(Product product, int units);

        /// <summary>
        /// Removes products in bulk from shopping trolley.
        /// </summary>
        /// <param name="sku">The SKU of the <see cref="Product"/> to add in bulk.</param>
        /// <param name="units">The number of units to remove.</param>
        /// <returns>The number of products removed from the shopping trolley.</returns>
        int RemoveBulk(string sku, int units);
    }
}
