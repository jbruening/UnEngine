using UnityEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for Vector3Test and is intended
    ///to contain all Vector3Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Vector3Test
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void oneTest()
        {
            Vector3 actual = Vector3.one;

            actual *= 3f;

            Vector3 expected = new Vector3(3f, 3f, 3f);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void oneDoesntChangeTest()
        {
            Vector3 throwAway = Vector3.one;
            throwAway *= 3f;

            Vector3 expected = new Vector3(1f, 1f, 1f);
            Assert.AreEqual(expected, Vector3.one);
            Assert.AreNotEqual(expected, throwAway);
        }
    }
}
