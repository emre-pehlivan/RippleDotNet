using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class EscrowCancelTransaction : BaseTransaction
    {
        public string Owner { get; set; }

        public uint OfferSequence { get; set; }
    }
}
