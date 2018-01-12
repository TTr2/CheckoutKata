using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    class Product
    {
        /// <summary>
        /// Constructor for a Product with optional MultiDeal reference (defaults to non-valid).
        /// </summary>
        /// <param name="sku">The SKU of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="multiDeal">The (optional) MultiDeal of the product.</param>
        public Product(string sku, int price, MultiDeal multiDeal = null)
        {
            if (string.IsNullOrEmpty(sku))
            {
                throw new ArgumentNullException(nameof(sku));
            }
            this.Price = price;
            this.MultiDeal = multiDeal == null ? new MultiDeal() : multiDeal;
        }

        /// <summary>
        /// The SKU of the product.
        /// </summary>
        internal string Sku { get; }

        /// <summary>
        /// The price of the product (100 = 1 decimal unit).
        /// </summary>
        internal int Price { get; set; }

        /// <summary>
        /// The MultiDeal for the product, default is non-valid.
        /// </summary>
        internal MultiDeal MultiDeal {get; set;}
    }
}
