using System.Collections.Generic;

namespace RippleDotNet.Model.Ledger
{
    public class LedgerHashesLedgerObject : BaseRippleLedgerObject
    {
        public uint FirstLedgerSequence { get; set; }

        public uint LastLedgerSequence { get; set; }

        public List<string> Hashes { get; set; }

        public uint Flags { get; set; }
    }
}
