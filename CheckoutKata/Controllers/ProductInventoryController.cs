using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Controllers
{
    class ProductInventoryController : IProductRepository
    {
        IProductRepository productRepository;

        public ProductInventoryController()
        {
            this.productRepository = new ProductInventoryDictionary();
        }

        /// <summary>
        /// <see cref="IProductRepository.Add(Product)"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void Add(Product product)
        {
            this.productRepository.Add(product);
        }

        /// <summary>
        /// <see cref="IProductRepository.Contains(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool Contains(string sku)
        {
            return this.productRepository.Contains(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Get(string)"/>
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        /// <returns><see cref="Product"/></returns>
        public Product Get(string sku)
        {
            return this.productRepository.Get(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAll"/>
        /// </summary>
        /// <returns><see cref="IProductRepository.GetAll"/></returns>
        public IList<Product> GetAll()
        {
            return this.productRepository.GetAll();
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku"><see cref="Product.Sku"/></param>
        public bool Remove(string sku)
        {
            return this.productRepository.Remove(sku);
        }
    }
}
