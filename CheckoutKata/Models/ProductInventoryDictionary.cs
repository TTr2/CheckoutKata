using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    class ProductInventoryDictionary : IProductInventory
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
        /// <see cref="IProductInventory.Add(Product)"/>
        /// </summary>
        /// <param name="product"></param>
        public void Add(Product product)
        {
            this.inventory.Add(product.Sku, product);
        }

        /// <summary>
        /// <see cref="IProductInventory.Get(string)"/>
        /// </summary>
        /// <param name="product">The SKU of the product to retrieve.</param>
        public Product Get(string sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="IProductInventory.IsProductInInventory(string)"/>
        /// </summary>
        /// <param name="sku">The SKU of the product to check for.</param>
        public bool IsProductInInventory(string sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="IProductInventory.Remove(string)"/>
        /// </summary>
        /// <param name="product">The SKU of the product to remove.</param>
        public void Remove(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
