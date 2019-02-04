using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{

    [TestClass]
    public class UnitTest1
    {
        TestContext testContext;

        string _tfsURL = "https://dev.azure.com/Rohitentc/TestConsoleApp/_apis/test/runs?buildUri=";
        ConnectTFS.ConnectTFS conTFS = new ConnectTFS.ConnectTFS();

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
            _tfsURL += _testContext.Properties["builduri"];
            string[] strArray = new string[2];
           string runIdResponse = conTFS.GetBuildDependentRunId(_tfsURL).ToString();
            strArray[0] = runIdResponse;
            strArray[1] = _tfsURL;
            System.IO.File.AppendAllLines(@"C:\AgentOnAzure2\agentWork\WriteLines.txt", strArray);

        }

        [TestMethod]
        public void TestMethod_addTwoNo()
        {

            
            int result = 11;
            string[] lines = { "Run id:" + Convert.ToString(_testContext.Properties["currentrunid"])+" And BuildURI is: "  +_testContext.Properties["builduri"] + " in add two "+  DateTime.Now.ToString() };           
            System.IO.File.AppendAllLines(@"C:\AgentOnAzure2\agentWork\WriteLines.txt", lines);

            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void TestMethod_DivideTwoNo()
        {
        
        }
    }

}
