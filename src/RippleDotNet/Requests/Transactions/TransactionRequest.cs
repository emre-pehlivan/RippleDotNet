using Newtonsoft.Json;

namespace RippleDotNet.Requests.Transactions
{
    public class TransactionRequest : RippleRequest
    {
        public TransactionRequest(string transaction)
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
