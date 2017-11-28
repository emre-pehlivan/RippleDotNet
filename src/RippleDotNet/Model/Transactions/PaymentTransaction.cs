using System.Collections.Generic;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions
{
    public class PaymentTransaction : BaseTransaction
    {
        public PaymentTransaction()
        {
            TransactionType = TransactionType.Payment;
        }

        [JsonConverter(typeof(CurrencyConverter))]
        public object Amount { get; set; }

        public string Destination { get; set; }

        public uint? DestinationTag { get; set; }

        public string InvoiceId { get; set; }

        public List<List<Path>> Paths { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object SendMax { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object DeliverMin { get; set; }
    }
}
