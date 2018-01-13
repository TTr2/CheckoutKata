using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    interface IShoppingTrolley : IProductRepository
    {
        /// <summary>
        /// Adds products in bulk to Shopping Trolley.
        /// </summary>
        /// <param name="sku"><see cref="Product"/></param>
        /// <param name="units">The number of units to add.</param>
        void AddBulk(Product product, int units);

        /// <summary>
        /// Removes products in bulk from shopping trolley.
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <param name="units">The number of units to remove.</param>
        /// <returns>The number of items removed from the shopping trolley.</returns>
        int RemoveBulk(string sku, int units);
    }
}
