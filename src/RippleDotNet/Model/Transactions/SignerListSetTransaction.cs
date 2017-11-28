using System;
using System.Collections.Generic;
using System.Text;
using RippleDotNet.Model.Ledger;

namespace RippleDotNet.Model.Transactions
{
    public class SignerListSetTransaction : BaseTransaction
    {
        public uint SignerQuorum { get; set; }

        public List<SignerEntry> SignerEntries { get; set; }
    }
}
