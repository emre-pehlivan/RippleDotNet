using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Ledger
{
    public class OfferLedgerObject : BaseRippleLedgerObject
    {
        public OfferLedgerObject()
        {
            LedgerEntryType = LedgerEntryType.Offer;
        }

        public OfferFlags Flags { get; set; }

        public string Account { get; set; }

        public uint Sequence { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object TakerPays { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object TakerGets { get; set; }

        public string BookDirectory { get; set; }

        public string BookNode { get; set; }

        public string OwnerNode { get; set; }

        [JsonProperty("PreviousTxnID")]
        public string PreviousTransactionId { get; set; }

        [JsonProperty("PreviousTxnLgrSeq")]
        public uint PreviousTransactionLedgerSequence { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? Expiration { get; set; }
    }
}
