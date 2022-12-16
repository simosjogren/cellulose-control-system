using SellukeittoSovellus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tuni.MppOpcUaClientLib;

namespace Test
{
    
    
    /// <summary>
    ///This is a test class for ProcessClientTest and is intended
    ///to contain all ProcessClientTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProcessClientTest
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
        ///A test for ConnectOPCUA
        ///</summary>
        [TestMethod()]
        public void ConnectOPCUATest()
        {
            ProcessClient target = new ProcessClient();  
            bool expected = true;  
            bool actual;
            actual = target.ConnectOPCUA();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for addSubscriptions
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SellukeittoSovellus.exe")]
        public void addSubscriptionsTest()
        {
            ProcessClient_Accessor target = new ProcessClient_Accessor();  
            bool expected = true;  
            bool actual;
            actual = target.addSubscriptions();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ProcessItemsChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SellukeittoSovellus.exe")]
        public void ProcessItemsChangedTest()
        {
            ProcessClient_Accessor target = new ProcessClient_Accessor();  
            object source = null;
            ProcessItemChangedEventArgs args = null;  
            target.ProcessItemsChanged(source, args);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for ConnectionStatus
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SellukeittoSovellus.exe")]
        public void ConnectionStatusTest()
        {
            ProcessClient_Accessor target = new ProcessClient_Accessor();  
            object source = null;  
            ConnectionStatusEventArgs args = null;
            target.mConnectionState = true;
            target.ConnectionStatus(source, args);
            Assert.IsTrue(target.mConnectionState);
        }
    }
}
