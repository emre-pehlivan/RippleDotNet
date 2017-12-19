using System.Collections.Generic;
using RippleDotNet.Model.Ledger;
using RippleDotNet.Model.Ledger.Objects;

namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class SignerListSetTransaction : BaseTransaction
    {

        public SignerListSetTransaction()
        {
            TransactionType = TransactionType.SignerListSet;
        }

        public uint SignerQuorum { get; set; }

        public List<SignerEntry> SignerEntries { get; set; }
    }
}
