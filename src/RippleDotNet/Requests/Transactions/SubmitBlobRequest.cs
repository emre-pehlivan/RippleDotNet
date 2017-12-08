using Newtonsoft.Json;

namespace RippleDotNet.Requests.Transactions
{
    public class SubmitBlobRequest : RippleRequest
    {
        public SubmitBlobRequest()
        {
            Command = "submit";
        }

        [JsonProperty("tx_blob")]
        public string TransactionBlob { get; set; }

        [JsonProperty("fail_hard")]
        public bool FailHard { get; set; }
    }
}
