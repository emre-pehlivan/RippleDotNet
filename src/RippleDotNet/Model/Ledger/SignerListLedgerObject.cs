using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RippleDotNet.Model.Ledger
{
    public class SignerListLedgerObject : BaseRippleLedgerObject
    {
        public uint Flags { get; set; }

        public string OwnerNode { get; set; }

        public uint SignerQuorum { get; set; }

        public List<SignerEntry> SignerEntries { get; set; }

        public uint SignerListId { get; set; }

        [JsonProperty("PreviousTxnID")]
        public string PreviousTransactionId { get; set; }

        [JsonProperty("PreviousTxnLgrSeq")]
        public uint PreviousTransactionLedgerSequence { get; set; }
    }

    public class SignerEntry
    {
        public string Account { get; set; }

        public ushort SignerWeight { get; set; }
    }
}
