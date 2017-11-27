using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RippleDotNet.Model.Accounts
{
    public class AccountInfo
    {
        [JsonProperty("account_data")]
        public AccountData AccountData { get; set; }

        [JsonProperty("ledger_current_index")]
        public int LedgerCurrentIndex { get; set; }

        [JsonProperty("queue_data")]
        public QueueData QueueData { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }
    }

    public class AccountData
    {
        public string Account { get; set; }

        public string Balance { get; set; }

        [JsonIgnore]
        public double RippleBalance
        {
            get
            {
                double val = Convert.ToDouble(Balance);
                return val / 1000000;
            }
        }

        public int Flags { get; set; }

        public string LedgerEntryType { get; set; }

        public int OwnerCount { get; set; }

        public string PreviousTxnID { get; set; }

        public int PreviousTxnLgrSeq { get; set; }

        public int Sequence { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("auth_change")]
        public bool AuthChange { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("fee_level")]
        public string FeeLevel { get; set; }

        [JsonProperty("max_spend_drops")]
        public string MaxSpendDrops { get; set; }

        [JsonProperty("seq")]
        public int Seq { get; set; }

        public int? LastLedgerSequence { get; set; }
    }

    public class QueueData
    {
        [JsonProperty("auth_change_queued")]
        public bool AuthChangeQueued { get; set; }

        [JsonProperty("highest_sequence")]
        public int HighestSequence { get; set; }

        [JsonProperty("lowest_sequence")]
        public int LowestSequence { get; set; }

        [JsonProperty("max_spend_drops_total")]
        public string MaxSpendDropsTotal { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("txn_count")]
        public int TxnCount { get; set; }
    }
}
