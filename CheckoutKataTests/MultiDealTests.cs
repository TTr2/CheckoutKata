using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata.Models;

namespace CheckoutKataTests
{
    /// <summary>
    /// Summary description for MultiDealTests
    /// </summary>
    [TestClass]
    public class MultiDealTests
    {
        TimeSpan interval;
        DateTime lastWeek;
        DateTime nextWeek;

        public MultiDealTests()
        {
            DateTime now = DateTime.Now;
            interval = new TimeSpan(2, 0, 0, 0);
            lastWeek = now.Subtract(interval);
            nextWeek = now.Add(interval);
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
        public void MultiDeal_check_units_validation()
        {
            // Setup
            TimeSpan interval = new TimeSpan(2, 0, 0, 0);
            DateTime lastWeek = DateTime.Now.Subtract(interval);
            DateTime nextWeek = DateTime.Now.Add(interval);

            // Act
            // Assert
            try
            {
                MultiDeal multiDeal = new MultiDeal(0, 10, lastWeek, nextWeek);
                Assert.Fail("Fail: units can't be less than one, '0' given.");
            }
            catch
            {
                // Test passes.
            }

            try
            {
                MultiDeal multiDeal = new MultiDeal(-1, 10, lastWeek, nextWeek);
                Assert.Fail("Fail: units can't be less than one, '-1' given.");
            }
            catch
            {
                // Test passes.
            }
        }

        [TestMethod]
        public void MultiDeal_check_price_validation()
        {
            // Setup
            // Act
            // Assert
            try
            {
                MultiDeal multiDeal = new MultiDeal(10, 0, lastWeek, nextWeek);
                Assert.Fail("Fail: price can't be less than one, '0' given.");
            }
            catch
            {
                // Test passes.
            }

            try
            {
                MultiDeal multiDeal = new MultiDeal(10, -1, lastWeek, nextWeek);
                Assert.Fail("Fail: price can't be less than one, '-1' given.");
            }
            catch
            {
                // Test passes.
            }
        }

        [TestMethod]
        public void MultiDeal_check_from_date_validation()
        {
            // Setup
            DateTime lastWeekPlusADay = lastWeek.AddDays(1);
            // Act
            // Assert
            try
            {
                MultiDeal multiDeal = new MultiDeal(10, 10, lastWeek, lastWeek);
                Assert.Fail($"Fail: from date must be less than before date, {lastWeek.ToString()} is the same as {lastWeek.ToString()}.");
            }
            catch
            {
                // Test passes.
            }

            try
            {
                MultiDeal multiDeal = new MultiDeal(10, 10, lastWeekPlusADay, lastWeek);
                Assert.Fail($"Fail: from date must be less than before date, {lastWeekPlusADay} is greater than {lastWeek.ToString()}.");
            }
            catch
            {
                // Test passes.
            }
        }

        [TestMethod]
        public void MultiDeal_check_before_date_validation()
        {
            // Setup
            DateTime nextWeekMinus2Days = lastWeek.Subtract(interval);
            // Act
            // Assert
            try
            {
                MultiDeal multiDeal = new MultiDeal(10, 10, nextWeek, nextWeek);
                Assert.Fail($"Fail: before date must be greater than from date, {nextWeek.ToString()} is the same as {nextWeek.ToString()}.");
            }
            catch
            {
                // Test passes.
            }

            try
            {
                MultiDeal multiDeal = new MultiDeal(10, 10, nextWeek, nextWeekMinus2Days);
                Assert.Fail($"Fail: before date must be greater than from date, {nextWeekMinus2Days} is less than {nextWeek.ToString()}.");
            }
            catch
            {
                // Test passes.
            }
        }
    }
}
