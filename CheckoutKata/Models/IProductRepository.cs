using System;
namespace CheckoutKata.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a repository of products.
    /// </summary>
    internal interface IProductRepository
    {
        /// <summary>
        /// Add a product to the repository.
        /// </summary>
        /// <param name="product">The product to add to the repository.</param>
        void Add(Product product);

        /// <summary>
        /// Get a product from the repository.
        /// </summary>
        /// <param name="sku">The SKU of the product to retrieve.</param>
        /// <returns>The product with matching SKU or null.</returns>
        Product Get(string sku);

        /// <summary>
        /// Get all products in repository.
        /// </summary>
        /// <returns>All products in the repository.</returns>
        IList<Product> GetAll();

        /// <summary>
        /// Checks whether product with given SKU is in repository.
        /// </summary>
        /// <param name="sku">The SKU of the product to check for.</param>
        /// <returns>Whether product with given SKU is in repository.</returns>
        bool Contains(string sku);

        /// <summary>
        /// Remove the product with matching SKU from repository.
        /// </summary>
        /// <param name="sku">The SKU of the product to remove.</param>
        /// <returns>Whether this product was successfully removed from the repository.</returns>
        bool Remove(string sku);

        /// <summary>
        /// Replace the product with a new instance.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to replace> an existing <see cref="Product"/></see> with matching SKU.</param>
        /// <returns>Whether the replacement was successful.</returns>
        bool Replace(Product product);

        /// <summary>
        /// Gets the number of a given product in repository.
        /// </summary>
        /// <param name="sku">THe SKU of the products to count.</param>
        /// <returns>The number of the given Products in the repository.</returns>
        int Count(string sku);
    }
}
