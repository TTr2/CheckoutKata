using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata.Models;

namespace CheckoutKataTests
{
    /// <summary>
    /// Summary description for ProductTests
    /// </summary>
    [TestClass]
    public class ProductTests
    {
        public ProductTests()
        {
            //
            // TODO: Add constructor logic here
            //
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Product_create_product()
        {
            //Setup
            Product productNotNullMultiDeal;
            Product productNullMultiDeal;

            // Act
            productNotNullMultiDeal = new Product("A", 50, new MultiDeal());
            productNullMultiDeal = new Product("C", 20);

            // Assert
            Assert.IsNotNull(productNotNullMultiDeal);
            Assert.IsNotNull(productNullMultiDeal);
        }

        [TestMethod]
        public void Product_retrieve_product_sku_test()
        {
            // Setup
            string sku = "A";

            // Act
            Product product = new Product(sku, 10);

            // Assert
            StringAssert.Equals(product.Sku, sku);
        }

        [TestMethod]
        public void Product_retrieve_product_price_test()
        {
            // Setup
            int price = 50;

            // Act
            Product product = new Product("A", price);

            // Assert
            Assert.IsTrue(product.Price.Equals(price));
        }

        [TestMethod]
        public void Product_retrieve_product_offer_test()
        {
            // Setup
            Product productNotNullMultiDeal;
            Product productNullMultiDeal;

            // Act
            productNotNullMultiDeal = new Product("A", 50, new MultiDeal());
            productNullMultiDeal = new Product("C", 20);

            // Assert
            Assert.IsInstanceOfType(productNotNullMultiDeal.MultiDeal, typeof(MultiDeal));
            Assert.IsNotNull(productNotNullMultiDeal.MultiDeal);

            Assert.IsInstanceOfType(productNullMultiDeal.MultiDeal, typeof(MultiDeal));
            Assert.IsNotNull(productNullMultiDeal.MultiDeal);
        }

        [TestMethod]
        public void Product_check_product_offer_is_valid_test()
        {
            // Setup
            TimeSpan interval = new TimeSpan(2, 0, 0, 0);
            DateTime lastWeek = DateTime.Now.Subtract(interval);
            DateTime nextWeek = DateTime.Now.Add(interval);
            DateTime now = DateTime.Now;

            // A valid MultiDeal (for now)
            MultiDeal multiDeal_1 = new MultiDeal(3, 130, lastWeek, nextWeek);

            // Invalid period values for MultiDeals
            MultiDeal multiDeal_2 = new MultiDeal(3, 130, lastWeek, lastWeek);
            MultiDeal multiDeal_3 = new MultiDeal(3, 130, nextWeek, nextWeek);

            Product product_1 = new Product("A", 50, multiDeal_1);
            Product product_2 = new Product("A", 50, multiDeal_2);
            Product product_3 = new Product("A", 50, multiDeal_3);
            Product product_4 = new Product("A", 50, new MultiDeal());

            // Act

            // Assert
            Assert.IsTrue(product_1.IsMultiDealValid(now));
            Assert.IsFalse(product_2.IsMultiDealValid(now));
            Assert.IsFalse(product_3.IsMultiDealValid(now));

            // Invalid current times for valid MultiDeal
            Assert.IsFalse(product_1.IsMultiDealValid(lastWeek.Subtract(interval)));
            Assert.IsFalse(product_1.IsMultiDealValid(nextWeek.Add(interval)));
        }
    }
}
