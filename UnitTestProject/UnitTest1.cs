using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{

    [TestClass]
    public class UnitTest1
    {
        TestContext testContext;

        public TestContext TestContext { get; set; }

        private static TestContext _testContext;

        [ClassInitialize]
        public static void SetupTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [TestInitialize]
        public void SetupTest()
        {
            Console.WriteLine(
                "TextContext.TestName='{0}'  static _testContext.TestName='{1}'  {2}",
                TestContext.TestName,
                _testContext.TestName, Convert.ToString(_testContext.Properties["__Tfs_TestRunId__"]) + "Rohit " + DateTime.Now.ToString());
        }

        [TestMethod]
        public void TestMethod_addTwoNo()
        {

            //Sample sp = new Sample();
            int result = 11;//sp.AddTwoNo(6, 5);
            string[] lines = { "Run id:" + Convert.ToString(_testContext.Properties["__Tfs_TestRunId__"]) + " in add two " + DateTime.Now.ToString() };           
            System.IO.File.AppendAllLines(@"C:\AgentOnAzure2\agentWork\WriteLines.txt", lines);

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void TestMethod_DivideTwoNo()
        {
           //for (Int64 i = 0; i < 10000000; i++)
            //{

            //}

            throw(new Exception("in TestMethod_DivideTwoNo"));
            string runid =Convert.ToString(_testContext.Properties["currentrunid"]);
            Console.WriteLine(" TestMethod_DivideTwoNo run id by runsetting is : " + runid);
            //Sample sp = new Sample();
            string[] lines = {  "Run id:" + runid + " in Divide " + DateTime.Now.ToString() };        
            System.IO.File.AppendAllLines(@"C:\AgentOnAzure2\agentWork\WriteLines.txt", lines);
            int result = 11;//sp.AddTwoNo(6, 5);
            Assert.AreEqual(11, result);
        }
    }
}
