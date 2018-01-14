namespace CheckoutKata.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    class Checkout : ICheckout
    {
        private Dictionary<string, IList<Product>> scannedProducts;

        /// <summary>
        /// Constructor for an instance of a checkout object.
        /// </summary>
        public Checkout()
        {
            this.scannedProducts = new Dictionary<string, IList<Product>>();
        }

        /// <summary>
        /// <see cref="ICheckout.Count"/>
        /// </summary>
        /// <returns>The number of products scanned.</returns>
        public int Count(string sku)
        {
            return this.scannedProducts.ContainsKey(sku) ? this.scannedProducts[sku].Count() : 0;
        }

        /// <summary>
        /// <see cref="ICheckout.CountAll"/>
        /// </summary>
        /// <returns>The total number of scanned Products.</returns>
        public int CountAll()
        {
            return this.scannedProducts.Values.Sum(list => list.Count);
        }

        /// <summary>
        /// <see cref="ICheckout.GetTotalPrice"/>
        /// </summary>
        /// <returns>The total price of scanned products including special offers.</returns>
        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Remove(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (this.scannedProducts.ContainsKey(product.Sku))
            {
                return this.scannedProducts[product.Sku].Remove(product);
            }
            else
            {
                return false;
            }
        }

        public void Scan(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!this.scannedProducts.ContainsKey(product.Sku))
            {
                this.scannedProducts.Add(product.Sku, new List<Product>());
            }

            this.scannedProducts[product.Sku].Add(product);
        }
    }
}
