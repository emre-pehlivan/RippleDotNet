using System.Collections.Generic;
using Newtonsoft.Json;
using RippleDotNet.Model.Transactions;
using RippleDotNet.Model.Transactions.TransactionTypes;

namespace RippleDotNet.Model.Accounts
{
    public class NoRippleCheck
    {
        [JsonProperty("ledger_current_index")]
        public uint LedgerCurrentIndex { get; set; }

        [JsonProperty("problems")]
        public List<string> Problems { get; set; }

        [JsonProperty("transactions")]
        public List<BaseTransaction> Transactions { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }
    }
}
