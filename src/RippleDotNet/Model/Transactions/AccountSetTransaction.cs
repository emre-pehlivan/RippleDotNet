using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class AccountSetTransaction : BaseTransaction
    {
        public uint? ClearFlag { get; set; }

        public string Domain { get; set; }

        public string EmailHash { get; set; }

        public string MessageKey { get; set; }

        public uint? SetFlag { get; set; }

        public uint? TransferRate { get; set; }

        public uint? TickSize { get; set; }
    }
}
