using System.Collections.Generic;
using Newtonsoft.Json;
using RippleDotNet.Model.Transactions;
using RippleDotNet.Model.Transactions.TransactionTypes;

namespace RippleDotNet.Model.Accounts
{
    public class AccountTransactions
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("ledger_index_min")]
        public int LedgerIndexMin { get; set; }

        [JsonProperty("ledger_index_max")]
        public int LedgerIndexMax { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("marker")]
        public object Marker { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("transactions")]
        public List<TransactionSummary> Transactions { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }        
    }

    public class TransactionSummary
    {
        [JsonProperty("ledger_index")]
        public uint LedgerIndex { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("tx")]
        public BaseTransaction Transaction { get; set; }

        [JsonProperty("tx_blob")]
        public string TransactionBlob { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }
    }
}
