using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    class ShoppingTrolleyDictionary : IShoppingTrolley
    {
        private IProductRepository productTypesInTrolley;
        private Dictionary<string, int> shoppingTrolley;

        public ShoppingTrolleyDictionary()
        {
            this.productTypesInTrolley = new ProductInventoryDictionary();
            this.shoppingTrolley = new Dictionary<string, int>();
        }

        /// <summary>
        /// <see cref="IProductRepository.AddProduct(Product)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void AddProduct(Product product)
        {
            int count;
            bool present = this.shoppingTrolley.TryGetValue(product.Sku, out count);
            if (present)
            {
                this.shoppingTrolley[product.Sku] = count + 1;
            }
            else
            {
                this.productTypesInTrolley.AddProduct(product);
                this.shoppingTrolley.Add(product.Sku, 1);
            }
        }

        /// <summary>
        /// <see cref="IShoppingTrolley.AddBulkProducts(Product, int)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <param name="units">The number of products to add.</param>
        public void AddBulkProducts(Product product, int units)
        {
            int count;
            bool present = this.shoppingTrolley.TryGetValue(product.Sku, out count);
            if (present)
            {
                this.shoppingTrolley[product.Sku] = count + 1;
            }
            else
            {
                this.productTypesInTrolley.AddProduct(product);
                this.shoppingTrolley.Add(product.Sku, 1);
            }
        }

        /// <summary>
        /// <see cref="IProductRepository.ContainsProduct(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool ContainsProduct(string sku)
        {
            return this.productTypesInTrolley.ContainsProduct(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.GetProduct(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns><see cref="Product"/></returns>
        public Product GetProduct(string sku)
        {
            return this.productTypesInTrolley.GetProduct(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAllProducts"/>
        /// </summary>
        /// <returns><see cref="IProductRepository.GetAllProducts"/></returns>
        public IList<Product> GetAllProducts()
        {
            IList<Product> products = new List<Product>();
            foreach (Product product in this.productTypesInTrolley.GetAllProducts())
            {
                for (int i = 0; i < this.shoppingTrolley[product.Sku]; i++)
                {
                    products.Add(product.ShallowCopy());
                }
            }

            return products;
        }

        /// <summary>
        /// <see cref="IProductRepository.RemoveProduct(string)"
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns>Whether the product was successfully removed from the inventory.</returns>
        public bool RemoveProduct(string sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="IShoppingTrolley.RemoveBulkProducts(string, int)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <param name="units">The number of products to remove.</param>
        /// <returns>The number of products removed.</returns>
        public int RemoveBulkProducts(string sku, int units)
        {
            throw new NotImplementedException();
        }
    }
}
