using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class PaymentChannelClaimTransaction : BaseTransaction
    {
        public string Channel { get; set; }

        public string Balance { get; set; }

        public string Amount { get; set; }

        public PaymentChannelclaimFlags? Flags { get; set; }

        public string Signature { get; set; }

        public string PublicKey { get; set; }
    }
}
