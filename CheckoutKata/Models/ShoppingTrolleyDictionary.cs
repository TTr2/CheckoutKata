namespace CheckoutKata.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a shopping trolley repository of products.
    /// </summary>
    class ShoppingTrolleyDictionary : IProductRepositoryBulkActions
    {
        private Dictionary<string, List<Product>> shoppingTrolley;

        /// <summary>
        /// Constructor for a shopping trolley instance.
        /// </summary>
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
            return this.shoppingTrolley.ContainsKey(sku) ? this.shoppingTrolley[sku][0] : null;
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAll"/>
        /// </summary>
        /// <returns><see cref="IProductRepository.GetAll"/></returns>
        public IList<Product> GetAll()
        {
            List<Product> products = new List<Product>();

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
            else
            {
                return false;
            }
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
                while (this.shoppingTrolley[sku].Count > 0 && count < units)
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
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// <see cref="IProductRepository.Count(string)"/>
        /// </summary>
        /// <param name="sku">The SKU of the Products to count.</param>
        /// <returns>The number of products with matching SKU in the repository.</returns>
        public int Count(string sku)
        {
            return this.shoppingTrolley.ContainsKey(sku) ? this.shoppingTrolley[sku].Count() : 0;
        }

        /// <summary>
        /// <see cref="IProductRepository.Replace(Product)"/>
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to replace> an existing <see cref="Product"/></see> with matching SKU.</param>
        /// <returns>Whether the replacement was successful.</returns>
        public bool Replace(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (this.shoppingTrolley.ContainsKey(product.Sku))
            {
                this.shoppingTrolley[product.Sku][0] = product;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// <see cref="IProductRepository.CountAll"/>
        /// </summary>
        /// <returns>The total number of Products in trolley.</returns>
        public int CountAll()
        {
            return this.shoppingTrolley.Values.Sum(list => list.Count);
        }
    }
}
