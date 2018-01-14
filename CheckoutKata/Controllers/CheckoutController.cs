using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Controllers
{
    class CheckoutController : ICheckout
    {
        ICheckout checkout;

        public CheckoutController()
        {
            this.checkout = new Checkout();
        }

        public int Count(string sku)
        {
            return checkout.Count(sku);
        }

        public int CountAll()
        {
            return checkout.CountAll();
        }

        public int GetTotalPrice()
        {
            return this.checkout.GetTotalPrice();
        }

        public bool Remove(Product product)
        {
            return this.checkout.Remove(product);
        }

        public void Scan(Product product)
        {
            this.checkout.Scan(product);
        }
    }
}
