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
        /// <param name="sku"></param>
        /// <returns>Whether the item was removed.</returns>
        bool Remove(string sku);

        /// <summary>
        /// Calculate and return the total price of all items including special offers.
        /// </summary>
        /// <returns>The total price of all items including special offers.</returns>
        int GetTotalPrice();
    }
}
