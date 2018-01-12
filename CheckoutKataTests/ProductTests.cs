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
        public void Create_product()
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
        public void Retrieve_product_price_test()
        {
            // Setup
            int price = 50;

            // Act
            Product product = new Product("A", price);

            // Assert
            Assert.IsTrue(product.Price.Equals(price));
        }

        [TestMethod]
        public void Update_product_price_test()
        {
            // Setup
            int price = 50;
            int newPrice = 60;
            Product product = new Product("A", price);

            // Act
            product.Price = newPrice;

            // Assert
            Assert.IsFalse(product.Price.Equals(price));
            Assert.IsTrue(product.Price.Equals(newPrice));
        }

        [TestMethod]
        public void Retrieve_product_offer_test()
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
        public void Replace_product_offer_test()
        {
            // Setup
            MultiDeal multiDeal_1 = new MultiDeal();
            MultiDeal multiDeal_2 = new MultiDeal();
            Product product = new Product("A", 10, multiDeal_1);

            // Act
            product.MultiDeal = multiDeal_2;

            // Assert
            Assert.AreNotSame(product.MultiDeal, multiDeal_1);
            Assert.AreSame(product.MultiDeal, multiDeal_2);
        }

        [TestMethod]
        public void Check_product_offer_is_valid_test()
        {
            //
            // TODO: Add test logic here
            //
            throw new NotImplementedException();
        }
    }
}
