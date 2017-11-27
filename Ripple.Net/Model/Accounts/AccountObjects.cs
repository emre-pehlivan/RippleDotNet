using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RippleDotNet.Model.Ledger;

namespace RippleDotNet.Model.Accounts
{
    public class AccountObjects
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("account_objects")]
        [JsonConverter(typeof(RippleLedgerObject))]
        public List<RippleLedgerObject> AccountObjectList { get; set; }

        [JsonProperty("ledger_hash")]
        public string LedgerHash { get; set; }

        [JsonProperty("ledger_hash")]
        public uint? LedgerIndex { get; set; }

        [JsonProperty("ledger_current_index")]
        public uint? LedgerCurrentIndex { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("marker")]
        public object Marker { get; set; }
    }
}
