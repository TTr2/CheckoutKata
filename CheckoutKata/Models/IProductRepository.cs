using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
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
        /// Gets the number of a given product in repository.
        /// </summary>
        /// <param name="sku">THe SKU of the products to count.</param>
        /// <returns>The number of the given Products in the repository.</returns>
        int Count(string sku);
    }
}
