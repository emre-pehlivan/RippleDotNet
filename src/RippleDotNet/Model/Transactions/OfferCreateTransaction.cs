using System;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions
{
    public class OfferCreateTransaction : BaseTransaction
    {

        public OfferCreateTransaction()
        {
            TransactionType = TransactionType.OfferCreate;
        }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? Expiration { get; set; }

        public uint? OfferSequence { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object TakerGets { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object TakerPays { get; set; }
    }
}
