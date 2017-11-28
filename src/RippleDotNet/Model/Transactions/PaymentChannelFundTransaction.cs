using System;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions
{
    public class PaymentChannelFundTransaction : BaseTransaction
    {
        public string Channel { get; set; }

        public string Amount { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? Expiration { get; set; }
    }
}
