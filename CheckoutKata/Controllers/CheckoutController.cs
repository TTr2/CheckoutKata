using CheckoutKata.Models;

namespace CheckoutKata.Controllers
{
    class CheckoutController : ICheckout
    {
        ICheckout checkout;

        public CheckoutController(IProductRepository productInventory)
        {
            this.checkout = new Checkout(productInventory);
        }

        public int CompleteCheckout()
        {
            return checkout.CompleteCheckout();
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
