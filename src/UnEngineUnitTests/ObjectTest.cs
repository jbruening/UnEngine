using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnEngine;
using UnityEngine;
using System.Linq;

namespace UnEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ObjectTest and is intended
    ///to contain all ObjectTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObjectTest
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
        
        // Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
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


        /// <summary>
        ///A test for op_Implicit
        ///</summary>
        [TestMethod()]
        public void op_ImplicitTest()
        {
            var exists = new Object();
            
            bool actual = exists;
            Assert.AreEqual(true, actual);

            exists = null;
            actual = exists;

            Assert.AreEqual(false, actual);
        }

        [TestMethod ()]
        public void FindObjectsOfType_GameObjects_Test ()
        {
            var obj1 = new GameObject ("alpha");
            var obj2 = new GameObject ("beta");

            var found = Object.FindObjectsOfType (typeof (GameObject));
            Assert.AreEqual (2, found.Length);
            Assert.AreEqual (1, found.Count (x => x.name == "alpha"));
            Assert.AreEqual (1, found.Count (x => x.name == "beta"));
        }

        [TestMethod ()]
        public void FindObjectsOfType_Components_Test ()
        {
            var obj1 = new GameObject ("alpha");
            var cam1 = obj1.AddComponent<Camera>();

            var obj2 = new GameObject ("beta");
            var cam2 = obj2.AddComponent<Camera> ();

            var obj3 = new GameObject ("gamma");

            var found = Object.FindObjectsOfType (typeof (Camera));
            Assert.AreEqual (2, found.Length);
            Assert.AreEqual (1, found.Count (x => x.name == "alpha"));
            Assert.AreEqual (1, found.Count (x => x.name == "beta"));
            Assert.AreEqual (0, found.Count (x => x.name == "gamma"));
            var array = (Camera[])found;
            Assert.AreEqual (2, array.Length);
        }


        class TestMonoBehaviour : MonoBehaviour
        {
            public int alpha = 4;

            public void Update ()
            {
                alpha += 1;
            }
        }

        [TestMethod ()]
        public void InstantiateTest ()
        {
            var go = new GameObject ("some test name");
            var mb = (TestMonoBehaviour) go.AddComponent<TestMonoBehaviour> ();
            mb.alpha = 1;

            var instance = (GameObject) Object.Instantiate (go);
            mb.alpha = 9;

            Assert.AreEqual ("some test name", instance.name);
            Assert.IsNotNull (instance.GetComponent<TestMonoBehaviour> ());
            Assert.AreEqual (1, instance.GetComponent<TestMonoBehaviour> ().alpha);

            UnEngine.InternalEngine.EngineState.Instance.Update (0);
            Assert.AreEqual (2, instance.GetComponent<TestMonoBehaviour> ().alpha);
            Assert.AreEqual (10, mb.alpha);
        }

        [TestMethod ()]
        public void InstantiateHierarchyTest ()
        {
            var go = new GameObject ("alpha");
            var mb = (TestMonoBehaviour)go.AddComponent<TestMonoBehaviour> ();
            mb.alpha = 1;

            var go2 = new GameObject ("beta");
            var mb2 = (TestMonoBehaviour)go2.AddComponent<TestMonoBehaviour> ();
            mb2.alpha = 1;

            go2.transform.parent = go.transform.parent;

            var instance = (GameObject) Object.Instantiate (go);

            Assert.IsNotNull (instance);
            Assert.AreEqual (1, instance.transform.childCount);


        }
    }

}