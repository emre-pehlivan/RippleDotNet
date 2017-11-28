using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class TransactionTests
    {
        private static IRippleClient client;

        //private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        private static string serverUrl = "wss://s2.ripple.com:443";

        public TestContext TestContext { get; set; }

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();
        }


        [TestMethod]
        public async Task CanGetTransaction()
        {
            var transaction = await client.Transaction("E08D6E9754025BA2534A78707605E0601F03ACE063687A0CA1BDDACFCD1698C7");
            Assert.IsNotNull(transaction);
        }
    }
}
