using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutKataTests
{
    [TestClass]
    public class CheckoutTests
    {
        public CheckoutTests()
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

        [TestMethod]
        public void Create_checkout()
        {
        }

        [TestMethod]
        public void Scan_item_at_checkout()
        {
        }

        [TestMethod]
        public void Scan_items_in_bulk_at_checkout()
        {
        }

        [TestMethod]
        public void Enter_item_manually_at_checkout()
        {
        }

        [TestMethod]
        public void Remove_item_at_checkout()
        {
        }

        [TestMethod]
        public void Remove_items_in_bulk_at_checkout()
        {
        }

        [TestMethod]
        public void Get_total_price_at_checkout()
        {
        }

        [TestMethod]
        public void Get_total_offer_savings_at_checkout()
        {
        }
    }
}
