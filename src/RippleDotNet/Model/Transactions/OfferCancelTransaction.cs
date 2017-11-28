using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class OfferCancelTransaction : BaseTransaction
    {
        public uint OfferSequence { get; set; }
    }
}
