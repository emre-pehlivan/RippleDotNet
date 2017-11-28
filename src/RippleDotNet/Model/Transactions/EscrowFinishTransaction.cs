using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class EscrowFinishTransaction : BaseTransaction
    {
        public EscrowFinishTransaction()
        {
            TransactionType = TransactionType.EscrowFinish;
        }

        public string Owner { get; set; }

        public uint OfferSequence { get; set; }

        public string Condition { get; set; }

        public string Fulfillment { get; set; }
    }
}
