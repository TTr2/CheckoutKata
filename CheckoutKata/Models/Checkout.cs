using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    class Checkout : ICheckout
    {
        public Checkout()
        {
        }

        /// <summary>
        /// <see cref="ICheckout.Count"/>
        /// </summary>
        /// <returns>The number of products scanned.</returns>
        public int Count()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Scan(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
