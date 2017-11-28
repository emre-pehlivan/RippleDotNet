using System;
using System.Collections.Generic;
using System.Text;

namespace RippleDotNet.Model.Transactions
{
    public class SetRegularKeyTransaction : BaseTransaction
    {
        public string RegularKey { get; set; }
    }
}
