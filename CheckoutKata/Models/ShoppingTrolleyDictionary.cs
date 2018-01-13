using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    class ShoppingTrolleyDictionary : IProductRepositoryBulkActions
    {
        private Dictionary<string, List<Product>> shoppingTrolley;

        public ShoppingTrolleyDictionary()
        {
            this.shoppingTrolley = new Dictionary<string, List<Product>>();
        }

        /// <summary>
        /// <see cref="IProductRepository.Add(Product)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void Add(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!this.shoppingTrolley.ContainsKey(product.Sku))
            {
                this.shoppingTrolley.Add(product.Sku, new List<Product>());
            }

            this.shoppingTrolley[product.Sku].Add(product);
        }

        /// <summary>
        /// <see cref="IProductRepositoryBulkActions.AddBulk(Product, int)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <param name="units">The number of products to add.</param>
        public void AddBulk(Product product, int units)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!this.shoppingTrolley.ContainsKey(product.Sku))
            {
                this.shoppingTrolley.Add(product.Sku, new List<Product>());
            }

            for (int i=0; i < units; i++)
            {
                this.shoppingTrolley[product.Sku].Add(product);
            }
        }

        /// <summary>
        /// <see cref="IProductRepository.Contains(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool Contains(string sku)
        {
            return this.shoppingTrolley.ContainsKey(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Get(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns><see cref="Product"/></returns>
        public Product Get(string sku)
        {
            Product product = null;
            if (this.shoppingTrolley.ContainsKey(sku))
            {
                product = this.shoppingTrolley[sku][0];
            }

            return product;
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAll"/>
        /// </summary>
        /// <returns><see cref="IProductRepository.GetAll"/></returns>
        public IList<Product> GetAll()
        {
            List<Product> products = null;

            foreach (string sku in this.shoppingTrolley.Keys)
            {
                foreach (Product product in this.shoppingTrolley[sku])
                {
                    products.Add(product);
                }
            }

            return products;
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns>Whether the product was successfully removed from the inventory.</returns>
        public bool Remove(string sku)
        {
            if (sku == null) return false;

            if (this.shoppingTrolley.ContainsKey(sku))
            {
                this.shoppingTrolley[sku].RemoveAt(0);
                if (this.shoppingTrolley[sku].Count == 0)
                {
                    this.shoppingTrolley.Remove(sku);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// <see cref="IProductRepositoryBulkActions.RemoveBulk(string, int)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <param name="units">The number of products to remove.</param>
        /// <returns>The number of products removed.</returns>
        public int RemoveBulk(string sku, int units)
        {
            if (sku == null || units == 0) return 0;

            if (this.shoppingTrolley.ContainsKey(sku))
            {
                int count = 0;
                while (count < units || this.shoppingTrolley[sku].Count > 0)
                {
                    this.shoppingTrolley[sku].RemoveAt(0);
                    count += 1;
                }

                if (this.shoppingTrolley[sku].Count == 0)
                {
                    this.shoppingTrolley.Remove(sku);
                }

                return count;
            }

            return 0;
        }
    }
}
