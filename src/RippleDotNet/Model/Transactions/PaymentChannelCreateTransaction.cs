using System;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions
{
    public class PaymentChannelCreateTransaction : BaseTransaction
    {
        public PaymentChannelCreateTransaction()
        {
            TransactionType = TransactionType.PaymentChannelCreate;
        }

        public string Amount { get; set; }

        public string Destination { get; set; }

        public uint SettleDelay { get; set; }

        public string PublicKey { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? CancelAfter { get; set; }

        public uint? DestinationTag { get; set; }

        public uint? SourceTag { get; set; }
    }
}
