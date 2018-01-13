using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Controllers
{
    class ShoppingTrolleyController : IProductRepositoryBulkActions
    {
        IProductRepositoryBulkActions shoppingTrolley;

        public ShoppingTrolleyController()
        {
            this.shoppingTrolley = new ShoppingTrolleyDictionary();
        }

        /// <summary>
        /// <see cref="IProductRepository.Add(Product)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void Add(Product product)
        {
            this.shoppingTrolley.Add(product);
        }

        /// <summary>
        /// <see cref="IProductRepositoryBulkActions.AddBulk(Product, int)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <param name="units">The number of products to add.</param>
        public void AddBulk(Product product, int units)
        {
            this.shoppingTrolley.AddBulk(product, units);
        }

        /// <summary>
        /// <see cref="IProductRepository.Contains(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool Contains(string sku)
        {
            return this.shoppingTrolley.Contains(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Count(string)"/>
        /// </summary>
        /// <param name="sku">The SKU of the product to count in the repository.</param>
        /// <returns>The number of products in repository with matching SKU.</returns>
        public int Count(string sku)
        {
            return this.shoppingTrolley.Count(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Get(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns><see cref="Product"/></returns>
        public Product Get(string sku)
        {
            return this.shoppingTrolley.Get(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAll"/>
        /// </summary>
        /// <returns><see cref="IProductRepository.GetAll"/></returns>
        public IList<Product> GetAll()
        {
            return this.shoppingTrolley.GetAll();
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns>Whether the product was successfully removed from the shopping trolley.</returns>
        public bool Remove(string sku)
        {
            return this.shoppingTrolley.Remove(sku);
        }

        /// <summary>
        /// <see cref="IProductRepositoryBulkActions.RemoveBulk(string, int)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <param name="units">The number of products to remove.</param>
        /// <returns>The number of products removed.</returns>
        public int RemoveBulk(string sku, int units)
        {
            return this.shoppingTrolley.RemoveBulk(sku, units);
        }
    }
}
