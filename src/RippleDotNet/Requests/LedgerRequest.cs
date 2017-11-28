using System;
using Newtonsoft.Json;

namespace RippleDotNet.Requests
{
    public class LedgerRequest : RippleRequest
    {
        public LedgerRequest() { }

        public LedgerRequest(Guid requestId) : base(requestId){ }

        [JsonProperty("ledger_hash")]
        public string LedgerHash { get; set; }

        [JsonProperty("ledger_index")]
        public object LedgerIndex { get; set; }
    }
}
