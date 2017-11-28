using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RippleDotNet.Requests.Transactions
{
    public class TransactionRequest : RippleRequest
    {
        public TransactionRequest(int requestId, string transaction) : base(requestId)
        {
            Command = "tx";
            Transaction = transaction;
        }

        [JsonProperty("transaction")]
        public string Transaction { get; set; }

        [JsonProperty("binary")]
        public bool? Binary { get; set; }
    }
}
