namespace CheckoutKata.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the functionality of a supermarket checkout.
    /// </summary>
    class Checkout : ICheckout
    {
        IProductRepository productInventory; // Temporary DI, replace with ServiceLocator

        private Dictionary<string, IList<string>> scannedProducts;
        private Dictionary<int, IList<Product>> completedTransactions;

        /// <summary>
        /// Constructor for an instance of a checkout object.
        /// </summary>
        public Checkout(IProductRepository productInventory)
        {
            this.productInventory = productInventory;
            this.scannedProducts = new Dictionary<string, IList<string>>();
            this.completedTransactions = new Dictionary<int, IList<Product>>();
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
            int totalPrice = 0;
            IList<Product> processedProducts = new List<Product>();
            foreach(KeyValuePair<string, IList<string>> products in this.scannedProducts) 
            {
                Product productMaster = this.productInventory.Get(products.Key);
                MultiDeal multiDealMaster = productMaster.MultiDeal;
                int productsCount = products.Value.Count;

                if (productMaster.IsMultiDealValid(DateTime.Now))
                {
                    while (productsCount >= multiDealMaster.Units)
                    {
                        totalPrice += multiDealMaster.MultiDealPrice;
                        productsCount -= multiDealMaster.Units;
                    }
                }

                while (productsCount > 0)
                {
                    totalPrice += productMaster.Price;
                    productsCount -= 1;
                }
            }

            return totalPrice;            
        }

        /// <summary>
        /// <see cref="ICheckout.CompleteCheckout"/>
        /// </summary>
        /// <returns>The total price of scanned products including special offers.</returns>
        public int CompleteCheckout()
        {
            int totalPrice = this.GetTotalPrice();

            IList<Product> processedProducts = new List<Product>();
            foreach (KeyValuePair<string, IList<string>> products in this.scannedProducts)
            {
                Product productMaster = this.productInventory.Get(products.Key);
                for (int i=0; i < products.Value.Count; i++)
                {
                    processedProducts.Add(productMaster);
                }
            }

            if (totalPrice > 0)
            {
                int nextId = this.completedTransactions.Values.Count() + 1;
                this.completedTransactions.Add(nextId, processedProducts);
            }

            this.scannedProducts = new Dictionary<string, IList<string>>();

            return totalPrice;
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
                return this.scannedProducts[product.Sku].Remove(product.Sku);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a product SKU to this checkout's list of scanend products. 
        /// </summary>
        /// <param name="product">The <see cref="Product"/> to scan.</param>
        public void Scan(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            if (!this.scannedProducts.ContainsKey(product.Sku))
            {
                this.scannedProducts.Add(product.Sku, new List<string>());
            }

            this.scannedProducts[product.Sku].Add(product.Sku);
        }
    }
}
