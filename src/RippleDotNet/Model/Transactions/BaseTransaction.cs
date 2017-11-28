using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RippleDotNet.Json.Converters;
using RippleDotNet.Model.Ledger;

namespace RippleDotNet.Model.Transactions
{
    [JsonConverter(typeof(TransactionConverter))]
    public class BaseTransaction
    {
        public string Account { get; set; }

        public string AccountTxnID { get; set; }

        public string Fee { get; set; }

        [JsonIgnore]
        public double RippleFee
        {
            get
            {
                if (string.IsNullOrEmpty(Fee)) return 0;

                double val = Convert.ToDouble(Fee);
                return val / 1000000;
            }
        }

        public uint? LastLedgerSequence { get; set; }

        public List<Memo> Memos { get; set; }

        public uint Sequence { get; set; }


        public string SigningPubKey { get; set; }

        public List<Signer> Signers { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType TransactionType { get; set; }
        public string TxnSignature { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("inLedger")]
        public int InLedger { get; set; }

        [JsonProperty("ledger_index")]
        public int LedgerIndex { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("validated")]
        public bool Validated { get; set; }
    }

    public class Memo
    {
        [JsonProperty("Memo")]
        public Memo2 Memo2 { get; set; }
    }

    public class Memo2
    {
        public string MemoData { get; set; }

        public string MemoFormat { get; set; }

        public string MemoType { get; set; }
    }

    public class Signer
    {
        public string Account { get; set; }
        public string TxnSignature { get; set; }

        public string SigningPubKey { get; set; }
    }

    public class Meta
    {
        public List<AffectedNode> AffectedNodes { get; set; }

        public int TransactionIndex { get; set; }

        public string TransactionResult { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public object DeliveredAmount { get; set; }
    }

    public class FinalFields
    {
        public string Account { get; set; }
        public object Balance { get; set; }
        public int Flags { get; set; }
        public int OwnerCount { get; set; }
        public int Sequence { get; set; }
        public Currency HighLimit { get; set; }
        public string HighNode { get; set; }
        public Currency LowLimit { get; set; }
        public string LowNode { get; set; }
    }

    public class PreviousFields
    {
        [JsonConverter(typeof(CurrencyConverter))]
        public object Balance { get; set; }
        public int Sequence { get; set; }
    }
    

    public class AffectedNode
    {
        [JsonConverter(typeof(LedgerObjectConverter))]
        public BaseRippleLedgerObject CreatedNode { get; set; }

        [JsonConverter(typeof(LedgerObjectConverter))]
        public BaseRippleLedgerObject ModifiedNode { get; set; }
    }
}
