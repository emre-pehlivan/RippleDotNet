using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;
using RippleDotNet.Model.Transactions;
using RippleDotNet.Model.Transactions.TransactionTypes;
using RippleDotNet.Requests.Transactions;

namespace RippleDotNet.Tests
{
    [TestClass]
    public class TransactionTests
    {
        private static IRippleClient client;
        private static JsonSerializerSettings serializerSettings;

        private static string serverUrl = "wss://s.altnet.rippletest.net:51233";
        //private static string serverUrl = "wss://s2.ripple.com:443";

        public TestContext TestContext { get; set; }

        
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            client = new RippleClient(serverUrl);
            client.Connect();

            serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            serializerSettings.Converters.Add(new TransactionConverter());
        }


        [TestMethod]
        public async Task CanGetTransaction()
        {
            var transaction = await client.Transaction("9E8F790679BAD934F17C5BEFDE98D1B45D2F1D574C60D0FB3EB454BF134ADC54");
            Assert.IsNotNull(transaction);
        }

        [TestMethod]
        public void CanCreatePaymentTransaction()
        {
            PaymentTransaction paymentTransaction = new PaymentTransaction();
            paymentTransaction.Account = "rwEHFU98CjH59UX2VqAgeCzRFU9KVvV71V";
            paymentTransaction.Destination = "rEqtEHKbinqm18wQSQGstmqg9SFpUELasT";
            paymentTransaction.Amount = "100000";
           
            Console.WriteLine(paymentTransaction.ToString());
        }

        [TestMethod]
        public async Task CanSignAndSubmitPaymentTransaction()
        {
            PaymentTransaction paymentTransaction = new PaymentTransaction();
            paymentTransaction.Account = "rwEHFU98CjH59UX2VqAgeCzRFU9KVvV71V";
            paymentTransaction.Destination = "rEqtEHKbinqm18wQSQGstmqg9SFpUELasT";
            paymentTransaction.Amount = "100000";

            SubmitRequest request = new SubmitRequest();
            request.Transaction = paymentTransaction;
            request.Offline = false;
            request.Secret = "xxxxx";

            Submit result = await client.SubmitTransaction(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("tesSUCCESS", result.EngineResult);            
            Assert.IsNotNull(result.Transaction.Hash);                       
        }
    }
}
