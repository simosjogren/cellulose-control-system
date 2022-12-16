using SellukeittoSovellus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for SequenceDriverTest and is intended
    ///to contain all SequenceDriverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SequenceDriverTest
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
        ///A test for StopSequence
        ///</summary>
        [TestMethod()]
        public void StopSequenceTest()
        {
            double cooktime = 50;
            double cooktemp = 50;
            double cookpres = 50;
            double imprtime = 50;  
            ProcessClient initializedProcessClient = new ProcessClient();  
            SequenceDriver target = new SequenceDriver(cooktime, cooktemp, cookpres, imprtime, initializedProcessClient);  
            bool expected = true;  
            bool actual;
            actual = target.StopSequence();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LockProcess
        ///</summary>
        [TestMethod()]
        public void LockProcessTest()
        {
            double cooktime = 50;
            double cooktemp = 50;
            double cookpres = 50;
            double imprtime = 50;
            ProcessClient initializedProcessClient = new ProcessClient();
            SequenceDriver target = new SequenceDriver(cooktime, cooktemp, cookpres, imprtime, initializedProcessClient);
            bool expected = true;
            bool actual;
            actual = target.LockProcess();
            Assert.AreEqual(expected, actual);
        }
    }
}
