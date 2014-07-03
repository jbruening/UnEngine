using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnEngine;

namespace UnEngineUnitTests
{

    [TestClass ()]
    public class ResourcesTest
    {
        private TestContext testContextInstance;

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

        [System.Serializable]
        public class TestClass : Object
        {
            public int Alpha;

            [SerializeField]
            private int beta;
            public int Beta { get { return beta; } }

            public TestClass ()
            {
                Alpha = 0;
                beta = 0;
            }

            public TestClass (int a, int b)
            {
                Alpha = a;
                beta = b;
            }

        }


        [TestMethod ()]
        public void serializePublicFieldsTest ()
        {
            var testData = new TestClass (23, 42);
            Resources.Store ("test.asset", testData);
            var deserialized = (TestClass) Resources.Load ("test.asset", typeof(TestClass));

            Assert.IsNotNull (deserialized);
            Assert.AreEqual (testData.Alpha, deserialized.Alpha);
        }


        [TestMethod ()]
        public void serializePrivateFieldsTest ()
        {
            var testData = new TestClass (23, 42);
            Resources.Store ("test.asset", testData);
            var deserialized = (TestClass)Resources.Load ("test.asset", typeof (TestClass));

            Assert.IsNotNull (deserialized);
            Assert.AreEqual (testData.Beta, deserialized.Beta);
        }


        [TestMethod ()]
        public void nullIfFileNotFoundTest ()
        {
            if (File.Exists ("invalidFile")) {
                File.Delete ("invalidFile");
            }

            var asset = Resources.Load ("invalidFile", typeof (TestClass));
            Assert.IsNull (asset);
        }
    }
}
