
namespace CheckoutKataTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CheckoutKata.Models;
    using CheckoutKata.Controllers;
    using System.Collections.Generic;

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
            shoppingTrolley.AddBulk(new Product("A", 50, new MultiDeal(3, 130, lastWeek, nextWeek)), 8); // Expected cost = 360
            shoppingTrolley.AddBulk(new Product("B", 30, new MultiDeal(2, 145, lastWeek, nextWeek)), 5); // Expected cost = 120
            shoppingTrolley.AddBulk(new Product("C", 20), 10); // Expected cost = 200
            shoppingTrolley.AddBulk(new Product("D", 15), 4); // Expected cost = 60
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
        public void Checkout_create_checkout()
        {
            // Setup
            // Act
            ICheckout checkout = new CheckoutController(productInventory);

            // Assert
            Assert.IsNotNull(checkout);
        }

        [TestMethod]
        public void Checkout_scan_item_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);

            // Act
            Product product = productInventory.Get("A");
            checkout.Scan(product);

            // Assert
            Assert.AreEqual(1, checkout.CountAll());            
        }

        [TestMethod]
        public void Checkout_scan_items_in_bulk_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            IList<Product> trolleyContents = shoppingTrolley.GetAll();

            // Act
            foreach (Product product in trolleyContents)
            {
                checkout.Scan(product);
            }

            // Assert
            Assert.AreEqual(trolleyContents.Count, checkout.CountAll());
        }

        [TestMethod]
        public void Checkout_remove_item_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            
            // Act
            Product product = productInventory.Get("A");
            checkout.Scan(product);
            Assert.AreEqual(1, checkout.CountAll());

            // Assert
            checkout.Remove(product);
            Assert.AreEqual(0, checkout.CountAll());

        }

        [TestMethod]
        public void Checkout_get_total_price_single_item_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product product = productInventory.Get("A");
            int price = product.Price;
            checkout.Scan(product);

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(price, totalPrice);
        }

        [TestMethod]
        public void Checkout_get_total_price_single_item_at_checkout_inc_price_change_of_instance()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product product = productInventory.Get("A");
            int productInstanceOriginalPrice = product.Price;
            int inventoryOriginalPrice = productInventory.Get(product.Sku).Price;

            // Changing product instance doesn't affect checkout
            checkout.Scan(product);
            Assert.AreEqual(productInstanceOriginalPrice, checkout.GetTotalPrice());
            checkout.Remove(product);
            product = new Product("A", product.Price * 2);
            Assert.AreEqual(inventoryOriginalPrice, checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Checkout_get_total_price_single_item_at_checkout_inc_price_change_of_inventory()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            string testSku = "A";
            Product product = productInventory.Get(testSku);
            int productInstanceOriginalPrice = product.Price;
            int inventoryOriginalPrice = productInventory.Get(product.Sku).Price;
            int multiplier = 3;

            // Act
            checkout.Scan(product);
            Assert.AreEqual(productInstanceOriginalPrice, checkout.GetTotalPrice());
            productInventory.Replace(new Product(testSku, productInstanceOriginalPrice * multiplier));
            int newInventoryPrice = productInventory.Get(product.Sku).Price;

            // Assert
            // Changing inventory instance does affect checkout
            Assert.AreNotEqual(productInstanceOriginalPrice, newInventoryPrice);
            Assert.AreNotEqual(productInstanceOriginalPrice, checkout.GetTotalPrice());
            Assert.AreEqual(productInstanceOriginalPrice * multiplier, checkout.GetTotalPrice());
            Assert.AreEqual(productInventory.Get(testSku).Price, checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Checkout_get_total_price_mixed_single_items_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product productA = productInventory.Get("A");
            Product productB = productInventory.Get("B");

            int priceA = productA.Price;
            int priceB = productB.Price;

            checkout.Scan(productA);
            checkout.Scan(productB);

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(priceA + priceB, totalPrice);
        }

        [TestMethod]
        public void Checkout_get_total_price_bulk_matching_offer_same_item_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product inventoryProductA = productInventory.Get("A");
            int priceA = inventoryProductA.Price;
            MultiDeal multiDealA = inventoryProductA.MultiDeal;
            for (int i=0; i<multiDealA.Units; i++)
            {
                checkout.Scan(inventoryProductA);
            }

            // Act
            int totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(multiDealA.MultiDealPrice, totalPrice);
        }

        [TestMethod]
        public void Checkout_get_total_price_bulk_matching_offer_same_item_at_checkout_inc_offer_change()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            string testSku = "A";
            Product inventoryProductA = productInventory.Get(testSku);
            MultiDeal multiDealA = inventoryProductA.MultiDeal;
            for (int i = 0; i < multiDealA.Units; i++)
            {
                checkout.Scan(inventoryProductA);
            }
            int unitModifier = 1;
            int totalPriceModifier = 2;
            MultiDeal newMultiDeal = new MultiDeal(multiDealA.Units + unitModifier, multiDealA.MultiDealPrice * totalPriceModifier, multiDealA.ValidFromDate, multiDealA.ValidBeforeDate);

            // Act
            int totalPriceBeforeChange = checkout.GetTotalPrice();
            Assert.AreEqual(multiDealA.MultiDealPrice, totalPriceBeforeChange);
            // Change inventory multiDeal
            productInventory.Replace(new Product(testSku, inventoryProductA.Price, newMultiDeal));

            // Assert
            // prove that offer change is reflected
            Assert.AreNotEqual(totalPriceBeforeChange, checkout.GetTotalPrice());
            int totalPriceAfterChange = checkout.GetTotalPrice();
            Assert.AreEqual(multiDealA.MultiDealPrice * totalPriceModifier, totalPriceAfterChange);
        }

        [TestMethod]
        public void Checkout_get_total_price_bulk_matching_offer_mixed_items_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product inventoryProductA = productInventory.Get("A");
            MultiDeal multiDealA = inventoryProductA.MultiDeal;
            for (int i = 0; i < multiDealA.Units; i++)
            {
                checkout.Scan(inventoryProductA);
            }
            Product inventoryProductB = productInventory.Get("B");
            MultiDeal multiDealB = inventoryProductB.MultiDeal;
            for (int i = 0; i < multiDealB.Units; i++)
            {
                checkout.Scan(inventoryProductB);
            }
            int expectedPrice = multiDealA.MultiDealPrice + multiDealB.MultiDealPrice;

            // Act
            int actualTotalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(expectedPrice, actualTotalPrice);
        }

        [TestMethod]
        public void Checkout_get_total_price_bulk_matching_offer_plus_misc_same_item_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product productA = productInventory.Get("A");
            int priceA = productA.Price;
            MultiDeal multiDealA = productA.MultiDeal;
            for (int i = 0; i < multiDealA.Units; i++)
            {
                checkout.Scan(productA);
            }
            checkout.Scan(productA);
            int expectedTotalPrice = multiDealA.MultiDealPrice + productA.Price;

            // Act
            int actualTotalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(expectedTotalPrice, actualTotalPrice);
        }

        [TestMethod]
        public void Checkout_get_total_price_bulk_matching_offer_plus_misc_mixed_items_at_checkout()
        {
            // Setup
            ICheckout checkout = new CheckoutController(productInventory);
            Product productA = productInventory.Get("A");
            MultiDeal multiDealA = productA.MultiDeal;
            for (int i = 0; i < multiDealA.Units; i++)
            {
                checkout.Scan(productA);
            }
            checkout.Scan(productA);
            Product productB = productInventory.Get("B");
            MultiDeal multiDealB = productB.MultiDeal;
            for (int i = 0; i < multiDealB.Units; i++)
            {
                checkout.Scan(productB);
            }
            int expectedPrice = multiDealA.MultiDealPrice + productA.Price + multiDealB.MultiDealPrice + productB.Price;

            // Act
            int actualTotalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.AreEqual(expectedPrice, actualTotalPrice);
        }
    }
}
