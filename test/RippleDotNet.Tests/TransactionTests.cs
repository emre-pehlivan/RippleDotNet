using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class TransactionTests
    {
        private static IRippleClient client;

        //private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        private static string serverUrl = "wss://s1.ripple.com:443";

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
            var transaction = await client.Transaction("264F55DA2E3339CEDA4B23CD3755C93DE6712C0E4FE69868411AFE4D37BC92CF");
            Assert.IsNotNull(transaction);
        }
    }
}
