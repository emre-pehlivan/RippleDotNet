using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RippleDotNet.Model.Ledger
{
    public class RippleLedgerObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LedgerEntryType LedgerEntryType { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }
    }
}
