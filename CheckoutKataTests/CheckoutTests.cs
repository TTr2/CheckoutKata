using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata.Models;
using CheckoutKata.Controllers;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutTests
    {
        IProductRepository productInventory;
        IProductRepositoryBulkActions shoppingTrolley;
        TimeSpan sevenDayInterval;
        DateTime lastWeek, nextWeek, now;
        public CheckoutTests()
        {
            // Setup dates for MultiDeal
            sevenDayInterval = new TimeSpan(3, 12, 0, 0);
            lastWeek = DateTime.Now.Subtract(sevenDayInterval);
            nextWeek = DateTime.Now.Add(sevenDayInterval);
            now = DateTime.Now;

            // Setup products
            Product productA = new Product("A", 50, new MultiDeal(3, 130, lastWeek, nextWeek));
            Product productB = new Product("B", 30, new MultiDeal(2, 145, lastWeek, nextWeek));
            Product productC = new Product("C", 20);
            Product productD = new Product("D", 15);

            // Populate inventory
            productInventory = new ProductInventoryController();
            productInventory.Add(productA);
            productInventory.Add(productB);
            productInventory.Add(productC);
            productInventory.Add(productD);

            // Populate shopping trolley
            shoppingTrolley = new ShoppingTrolleyController();
            shoppingTrolley.AddBulk(productA, 8); // Expected cost = 360
            shoppingTrolley.AddBulk(productB, 5); // Expected cost = 120
            shoppingTrolley.AddBulk(productC, 10); // Expected cost = 200
            shoppingTrolley.AddBulk(productD, 4); // Expected cost = 60
            // Total expected cost = 740

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void Create_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Scan_item_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Scan_items_in_bulk_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Enter_item_manually_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Remove_item_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Remove_items_in_bulk_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_single_item_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_single_item_at_checkout_inc_price_change()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_mixed_single_items_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_same_item_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_same_item_at_checkout_inc_price_change()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_same_item_at_checkout_inc_price_and_offer_change()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_mixed_items_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_plus_misc_same_item_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_price_bulk_matching_offer_plus_misc_mixed_items_at_checkout()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Get_total_offer_savings_at_checkout()
        {
            throw new NotImplementedException();
        }
    }
}
