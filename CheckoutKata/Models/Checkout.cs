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
        IProductRepository productInventory; // Temporary DI, replace with ServiceLocator

        private Dictionary<string, IList<Product>> scannedProducts;
        private IList<Product> processedProducts;

        /// <summary>
        /// Constructor for an instance of a checkout object.
        /// </summary>
        public Checkout(IProductRepository productInventory)
        {
            this.productInventory = productInventory;
            this.scannedProducts = new Dictionary<string, IList<Product>>();
            this.processedProducts = new List<Product>();
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


//            for(int i = this.scannedProducts.Values.Count - 1; i >= 0; i--)

//            IList<Product> products in this.scannedProducts.Values)
            foreach(KeyValuePair<string, IList<Product>> products in this.scannedProducts) 
            {
                Product productMaster = this.productInventory.Get(products.Key);
                MultiDeal multiDealMaster = productMaster.MultiDeal;

                if (productMaster.IsMultiDealValid(DateTime.Now))
                {
                    while (products.Value.Count >= multiDealMaster.Units)
                    {

                        totalPrice += multiDealMaster.MultiDealPrice;
                        int startingIndex = products.Value.Count - 1;
                        for (int i = startingIndex; i > startingIndex - multiDealMaster.Units; i--)
                        {
                            products.Value.RemoveAt(i);
                            this.processedProducts.Add(productMaster);
                        }
                    }
                }

                while (products.Value.Count > 0)
                {
                    totalPrice += productMaster.Price;
                    this.scannedProducts[productMaster.Sku].RemoveAt(products.Value.Count - 1);
                    this.processedProducts.Add(productMaster);
                }
            }

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
