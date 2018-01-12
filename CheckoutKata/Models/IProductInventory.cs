using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    /// <summary>
    /// Interface for an inventory of products.
    /// </summary>
    internal interface IProductInventory
    {
        /// <summary>
        /// Add a product to the inventory.
        /// </summary>
        /// <param name="product">The product to add to the inventory.</param>
        void Add(Product product);

        /// <summary>
        /// Get a product from the inventory.
        /// </summary>
        /// <param name="sku">The SKU of the product to retrieve.</param>
        /// <returns>The product with matching SKU or null.</returns>
        Product Get(string sku);

        /// <summary>
        /// Checks whether product with given SKU is in inventory.
        /// </summary>
        /// <param name="sku">The SKU of the product to check for.</param>
        /// <returns>Whether product with given SKU is in inventory.</returns>
        bool IsProductInInventory(string sku);

        /// <summary>
        /// Remove the product with matching SKU from inventory.
        /// </summary>
        /// <param name="sku">The SKU of the product to remove.</param>
        void Remove(string sku);
    }
}
