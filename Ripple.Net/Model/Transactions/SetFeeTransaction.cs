using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class SetFeeTransaction : RippleTransaction
    {
        public string BaseFee { get; set; }

        public uint ReferenceFeeUnits { get; set; }

        public uint ReserveBase { get; set; }

        public uint ReserveIncrement { get; set; }

        public uint LedgerSequence { get; set; }
    }
}
