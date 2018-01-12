using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    /// <summary>
    /// Represents an inventory of products that are can be added to a shopping trolley,
    /// and provides accessors to retrieve the details of included products.
    /// </summary>
    class ProductInventoryDictionary : IProductRepository
    {
        private Dictionary<string, Product> inventory;

        /// <summary>
        /// Constructor for a product inventory dictionary.
        /// </summary>
        public ProductInventoryDictionary()
        {
            this.inventory = new Dictionary<string, Product>();
        }

        /// <summary>
        /// <see cref="IProductRepository.Add(Product)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void Add(Product product)
        {
            this.inventory.Add(product.Sku, product);
        }

        /// <summary>
        /// <see cref="IProductRepository.Get(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns><see cref="Product"/></returns>
        public Product Get(string sku)
        {
            Product value;
            this.inventory.TryGetValue(sku, out value);
            return value;
        }

        /// <summary>
        /// <see cref="IProductRepository.Contains(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool Contains(string sku)
        {
            return this.inventory.ContainsKey(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns>Whether the product was successfully removed from the inventory.</returns>
        public bool Remove(string sku)
        {
            return this.inventory.Remove(sku);
        }
    }
}
