using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata.Models;
using CheckoutKata.Controllers;

namespace CheckoutKataTests
{
    /// <summary>
    /// Summary description for ShoppingTrolleyTests
    /// </summary>
    [TestClass]
    public class ShoppingTrolleyTests
    {
        readonly Product productA, productB, productC, productD;

        public ShoppingTrolleyTests()
        {
            productA = new Product("A", 50);
            productB = new Product("B", 30);
            productC = new Product("C", 20);
            productD = new Product("D", 15);
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
        public void Create_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act

            // Assert
            Assert.IsNotNull(shoppingTrolley);
        }

        [TestMethod]
        public void Add_product_to_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act
            shoppingTrolley.Add(productA);

            // Assert
            // Passes if no exception thrown
        }

        [TestMethod]
        public void Add_products_in_bulk_to_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act
            shoppingTrolley.AddBulk(productA, 12);

            // Assert
            // Passes if no exception thrown.
        }

        [TestMethod]
        public void Retrieve_product_from_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act
            shoppingTrolley.Add(productA);
            Product retrievedProduct = shoppingTrolley.Get(productA.Sku);

            // Assert
            Assert.IsNotNull(retrievedProduct);
            StringAssert.Equals(productA.Sku, retrievedProduct.Sku);
        }

        [TestMethod]
        public void Retrieve_all_products_from_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act & Assert
            // Test empty
            IList<Product> products = shoppingTrolley.GetAll();
            Assert.AreEqual(0, products.Count);

            products = null;

            // Test with one product type
            shoppingTrolley.AddBulk(productA, 12);
            products = shoppingTrolley.GetAll();
            Assert.AreEqual(12, products.Count);

            // Test with 4 types
            shoppingTrolley.AddBulk(productB, 8);
            shoppingTrolley.AddBulk(productC, 6);
            shoppingTrolley.AddBulk(productD, 4);
            products = shoppingTrolley.GetAll();
            Assert.AreEqual(30, products.Count);
        }

        [TestMethod]
        public void Check_for_product_in_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();

            // Act
            shoppingTrolley.Add(productB);

            // Assert
            Assert.IsTrue(shoppingTrolley.Contains(productB.Sku));
            Assert.IsFalse(shoppingTrolley.Contains(productA.Sku));
        }

        [TestMethod]
        public void Remove_product_from_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();
            shoppingTrolley.Add(productB);
            Assert.IsTrue(shoppingTrolley.Contains(productB.Sku));

            // Act
            shoppingTrolley.Remove(productB.Sku);

            // Assert
            Assert.IsFalse(shoppingTrolley.Contains(productB.Sku));
            shoppingTrolley.Add(productC);
            Assert.IsTrue(shoppingTrolley.Remove(productC.Sku));
            Assert.IsFalse(shoppingTrolley.Contains(productA.Sku));
        }

        [TestMethod]
        public void Remove_products_in_bulk_from_shopping_trolley()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();
            int unitsToAdd = 10;
            int unitsToRemove = 5;

            // Test bulk remove with some remaining in trolley
            shoppingTrolley.AddBulk(productA, unitsToAdd);
            Assert.AreEqual(unitsToAdd - unitsToRemove, shoppingTrolley.RemoveBulk(productA.Sku, unitsToRemove)); // Test Return value
            Assert.AreEqual(unitsToAdd - unitsToRemove, shoppingTrolley.Count(productA.Sku));
            Assert.IsTrue(shoppingTrolley.Contains(productA.Sku));

            // Test bulk remove all of the product in trolley
            shoppingTrolley.AddBulk(productB, unitsToAdd);
            Assert.AreEqual(unitsToAdd, shoppingTrolley.RemoveBulk(productB.Sku, unitsToAdd)); // Test Return value
            Assert.AreEqual(0, shoppingTrolley.Count(productB.Sku));
            Assert.IsFalse(shoppingTrolley.Contains(productB.Sku));

            // Test bulk remove more than in trolley
            shoppingTrolley.AddBulk(productC, unitsToAdd);
            Assert.AreEqual(unitsToAdd, shoppingTrolley.RemoveBulk(productC.Sku, unitsToAdd * 2)); // Test Return value
            Assert.AreEqual(0, shoppingTrolley.Count(productB.Sku));
            Assert.IsFalse(shoppingTrolley.Contains(productB.Sku));
        }

        [TestMethod]
        public void Count_products_in_shopping_trolley_test()
        {
            // Setup
            IProductRepositoryBulkActions shoppingTrolley = new ShoppingTrolleyController();
            int unitsToAdd = 10;
            shoppingTrolley.AddBulk(productA, unitsToAdd);

            // Act
            int count = shoppingTrolley.Count(productA.Sku);
            int notAddedCount = shoppingTrolley.Count(productB.Sku);

            // Assert
            Assert.AreEqual(unitsToAdd, count);
            Assert.AreEqual(0, notAddedCount);
        }
    }
}
