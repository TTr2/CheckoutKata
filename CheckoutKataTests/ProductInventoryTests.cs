using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata.Models;

namespace CheckoutKataTests
{
    /// <summary>
    /// Summary description for StoreInventoryTests
    /// </summary>
    [TestClass]
    public class ProductInventoryTests
    {
        readonly Product productA, productB, productC, productD;

        public ProductInventoryTests()
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
        public void Create_inventory_test()
        {
            //Setup
            IProductRepository inventory = new ProductInventoryDictionary();

            // Assert
            Assert.IsNotNull(inventory);
        }

        [TestMethod]
        public void Add_product_to_inventory_test()
        {
            // Setup
            IProductRepository inventory = new ProductInventoryDictionary();

            // Act
            inventory.AddProduct(productA);

            // Assert
            // Passes if no exception.
        }

        [TestMethod]
        public void Retrieve_product_from_inventory_test()
        {
            // Setup
            IProductRepository inventory = new ProductInventoryDictionary();

            // Act
            inventory.AddProduct(productA);
            Product retrievedProduct = inventory.GetProduct(productA.Sku);

            // Assert
            Assert.AreEqual(productA, retrievedProduct);
        }

        [TestMethod]
        public void Check_product_is_in_inventory_test()
        {
            // Setup
            IProductRepository inventory = new ProductInventoryDictionary();
            string sku = "A";

            // Act
            inventory.AddProduct(productA);

            // Assert
            Assert.IsTrue(inventory.ContainsProduct(sku));
        }

        [TestMethod]
        public void Remove_product_from_inventory_test()
        {
            // Setup
            IProductRepository inventory = new ProductInventoryDictionary();

            // Act
            inventory.AddProduct(productA);
            Assert.IsTrue(inventory.ContainsProduct(productA.Sku));
            inventory.RemoveProduct(productA.Sku);

            // Assert
            Assert.IsFalse(inventory.ContainsProduct(productA.Sku));
        }
    }
}
