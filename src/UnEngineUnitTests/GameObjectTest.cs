using UnEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnityEngine;

namespace UnEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for GameObjectTest and is intended
    ///to contain all GameObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameObjectTest
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


        /// <summary>
        ///A test for GameObject Constructor
        ///</summary>
        [TestMethod()]
        public void GameObjectConstructorTest()
        {
            GameObject target = new GameObject();

            var actual = target.transform;
            Assert.IsNotNull(actual);
        }

        [TestMethod ()]
        public void ChildCountTest ()
        {
            var parent = new GameObject ("parent");
            var child = new GameObject ("child");
            var child2 = new GameObject ("child2");

            Assert.AreEqual (0, parent.transform.childCount);

            child.transform.parent = parent.transform;
            child2.transform.parent = parent.transform;

            Assert.AreEqual (2, parent.transform.childCount);
        }

        [TestMethod ()]
        public void GetChildTest ()
        {
            var parent = new GameObject ("parent");
            var child = new GameObject ("child");
            var child2 = new GameObject ("child2");

            child.transform.parent = parent.transform;
            child2.transform.parent = parent.transform;

            Assert.AreEqual ("child", parent.transform.GetChild (0).name);
            Assert.AreEqual ("child2", parent.transform.GetChild (1).name);
        }
    }
}
