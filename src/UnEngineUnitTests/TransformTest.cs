using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;
using UnEngine;

namespace UnEngineUnitTests
{
    [TestClass]
    public class TransformTest
    {
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

        // Use TestInitialize to run code before running each test
        [TestInitialize ()]
        public void MyTestInitialize ()
        {
            UnEngine.InternalEngine.EngineState.Reset ();
        }

        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

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

        [TestMethod ()]
        public void TransplantChildTest ()
        {
            var parent1 = new GameObject ("parent1");
            var parent2 = new GameObject ("parent2");
            var child = new GameObject ("child");

            child.transform.parent = parent1.transform;
            child.transform.parent = parent2.transform;

            Assert.AreEqual (0, parent1.transform.childCount);
            Assert.AreEqual (1, parent2.transform.childCount);
        }
    }
}
