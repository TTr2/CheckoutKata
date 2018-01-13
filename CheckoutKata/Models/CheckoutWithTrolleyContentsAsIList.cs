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
        /// <param name="sku"></param>
        /// <returns></returns>
        public bool Remove(string sku)
        {
            throw new NotImplementedException();
        }

        public void Scan(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
