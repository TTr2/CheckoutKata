namespace CheckoutKata.Controllers
{
    using CheckoutKata.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Controls public interactions with a product inventory.
    /// </summary>
    class ProductInventoryController : IProductRepository
    {
        IProductRepository productRepository;

        /// <summary>
        /// Constructor for the Product Inventor Controller.
        /// </summary>
        public ProductInventoryController()
        {
            this.productRepository = new ProductInventoryDictionary();
        }

        /// <summary>
        /// <see cref="IProductRepository.Add(Product)"/>
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to add to the repository.</param>
        public void Add(Product product)
        {
            this.productRepository.Add(product);
        }

        /// <summary>
        /// <see cref="IProductRepository.Contains(string)"/>
        /// </summary>
        /// <param name="sku">The <see cref="Product.Sku"/> of the <see cref="Product"/> to check for in the repository.</param>
        public bool Contains(string sku)
        {
            return this.productRepository.Contains(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Count(string)"/>
        /// </summary>
        /// <param name="sku">The SKU of the <see cref="Product"/> to count in the repository.</param>
        /// <returns>The number of products in repository with matching SKU.</returns>
        public int Count(string sku)
        {
            return this.productRepository.Count(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.CountAll"/>.
        /// </summary>
        /// <returns>The total number of Products in inventory.</returns>
        public int CountAll()
        {
            return productRepository.CountAll();
        }

        /// <summary>
        /// <see cref="IProductRepository.Get(string)"/>
        /// </summary>
        /// <param name="sku">The <see cref="Product.Sku"/> of the <see cref="Product"/> to retrieve.</param>
        /// <returns>The <see cref="Product"/>.</returns>
        public Product Get(string sku)
        {
            return this.productRepository.Get(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.GetAll"/>
        /// </summary>
        /// <returns>A collection of <see cref="Product"/> in repository.</returns>
        public IList<Product> GetAll()
        {
            return this.productRepository.GetAll();
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku">The <see cref="Product.Sku"/> of the product to remove.</param>
        public bool Remove(string sku)
        {
            return this.productRepository.Remove(sku);
        }

        /// <summary>
        /// <see cref="IProductRepository.Remove(string)"
        /// </summary>
        /// <param name="sku">The new <see cref="Product.Sku"/>.</param>
        public bool Replace(Product product)
        {
            return productRepository.Replace(product);
        }
    }
}
