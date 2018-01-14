using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
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
        /// <returns>Whether the item was removed.</returns>
        bool Remove(Product product);

        /// <summary>
        /// Calculate and return the total price of all items including special offers.
        /// </summary>
        /// <returns>The total price of all items including special offers.</returns>
        int GetTotalPrice();

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
