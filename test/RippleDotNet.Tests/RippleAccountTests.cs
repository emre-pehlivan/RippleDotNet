using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RippleDotNet.Tests
{
    [TestClass]
    public class RippleAccountTests
    {
        private static IRippleClient client;

        //private static string account = "rJgijaBqNozwJnDxoiMbvLQWvndYTyQidu";
        private static string account = "rPGKpTsgSaQiwLpEekVj1t5sgYJiqf2HDC";

        //private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        private static string serverUrl = "wss://s1.ripple.com:443";


        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();            
        }

        [TestMethod]
        public async Task CanGetAccountInfo()
        {
            Model.Accounts.AccountInfo accountInfo = await client.AccountInfo(account);
            Assert.IsNotNull(accountInfo);
        }

        [TestMethod]
        public async Task CanGetAccountChannels()
        {
            var accountChannels = await client.AccountChannels(account);
            Assert.IsNotNull(accountChannels);
        }

        [TestMethod]
        public async Task CanGetAccountCurrencies()
        {
            var currencies = await client.AccountCurrencies(account);
            Assert.IsNotNull(currencies);
        }

        [TestMethod]
        public async Task CanGetAccountLines()
        {
            var accountLines = await client.AccountLines(account);
            Assert.IsNotNull(accountLines);
        }

        [TestMethod]
        public async Task CanGetAccountOffers()
        {
            var accountOffers = await client.AccountOffers(account);
            Assert.IsNotNull(accountOffers);
        }

        [TestMethod]
        public async Task CanGetAccountObjects()
        {
            var accountObjects = await client.AccountObjects(account);
            Assert.IsNotNull(accountObjects);
        }

        [TestMethod]
        public async Task CanGetAccountTransactions()
        {
            var accountTransactions = await client.AccountTransactions(account);
            Assert.IsNotNull(accountTransactions);
        }
    }
}
