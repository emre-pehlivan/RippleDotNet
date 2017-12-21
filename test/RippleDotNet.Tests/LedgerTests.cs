using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RippleDotNet.Model;
using RippleDotNet.Requests.Ledger;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class LedgerTests
    {
        private static IRippleClient client;
        private static string serverUrl = "wss://s1.ripple.com:443";
        //private static string serverUrl = "wss://s.altnet.rippletest.net:51233";

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();
        }

        [TestMethod]
        public async Task CanGetLedger()
        {
            //binary format
            var request = new LedgerRequest {LedgerIndex = new LedgerIndex(LedgerIndexType.Validated), Transactions = true, Expand = true, Binary = true};
            //var request = new LedgerRequest {LedgerIndex = "current", Queue = true};

            var ledger = await client.Ledger(request);
            
            Assert.IsNotNull(ledger);
        }
    }
}
