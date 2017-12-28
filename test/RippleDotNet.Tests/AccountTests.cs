using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RippleDotNet.Model;
using RippleDotNet.Model.Account;
using RippleDotNet.Requests.Account;


namespace RippleDotNet.Tests
{
    [TestClass]
    public class AccountTests
    {
        private static IRippleClient client;
        
        //this is an altnet account
        private static string account = "rwEHFU98CjH59UX2VqAgeCzRFU9KVvV71V";
        
        //these are mainnet accounts
        //private static string account = "rPGKpTsgSaQiwLpEekVj1t5sgYJiqf2HDC";
        //private static string account = "rho3u4kXc5q3chQFKfn9S1ZqUCya1xT3t4";

        private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        //private static string serverUrl = "wss://s1.ripple.com:443";
        //private static string serverUrl = "wss://s2.ripple.com:443";


        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();            
        }

        [TestMethod]
        public async Task CanPerformPing()
        {
            await client.Ping();            
        }

        [TestMethod]
        public async Task CanGetAccountInfo()
        {
            AccountInfo accountInfo = await client.AccountInfo(account);
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

        [TestMethod]
        public async Task CanGetAccountTransactionsAsBinary()
        {
            AccountTransactionsRequest transactionsRequest = new AccountTransactionsRequest(account);
            transactionsRequest.Binary = true;
            var accountTransactions = await client.AccountTransactions(transactionsRequest);
            Assert.IsNotNull(accountTransactions);
        }

        [TestMethod]
        public void CanCreateNoRippleCheckRequest()
        {
            NoRippleCheckRequest request = new NoRippleCheckRequest(account);
            request.Role = RoleType.User;

            string json = JsonConvert.SerializeObject(request);
            JObject jObject = JObject.Parse(json);
            JToken role = jObject["role"];
            Assert.AreEqual("user", role.Value<string>());
        }

        [TestMethod]
        public async Task CanPerformNoRippleCheck()
        {
            NoRippleCheck noRippleCheck = await client.NoRippleCheck(account);
            Assert.IsNotNull(noRippleCheck);
        }

        [TestMethod]
        public async Task CanPerformNoRippleCheckWithRequest()
        {
            NoRippleCheckRequest request = new NoRippleCheckRequest(account);
            request.Role = RoleType.Gateway;
            NoRippleCheck noRippleCheck = await client.NoRippleCheck(request);            
            Assert.IsNotNull(noRippleCheck);
        }

        [TestMethod]
        public async Task CanGetGatewayBalances()
        {
            var balances = await client.GatewayBalances(account);
            Assert.IsNotNull(balances);
        }
    }
}
