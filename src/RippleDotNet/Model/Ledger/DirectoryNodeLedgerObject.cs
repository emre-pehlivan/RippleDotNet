using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Ledger
{
    public class DirectoryNodeLedgerObject : BaseRippleLedgerObject
    {
        public uint Flags { get; set; }

        public string RootIndex { get; set; }

        public List<string> Indexes { get; set; }

        public ulong IndexNext { get; set; }

        public ulong IndexPrevious { get; set; }

        public string Owner { get; set; }

        public string TakerPaysCurrency { get; set; }

        public string TakerPaysIssuer { get; set; }

        public string TakerGetsCurrency { get; set; }

        public string TakerGetsIssuer { get; set; }
    }
}
