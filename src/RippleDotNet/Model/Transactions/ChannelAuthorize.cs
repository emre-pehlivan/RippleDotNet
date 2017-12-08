using Newtonsoft.Json;

namespace RippleDotNet.Model.Transactions
{
    public class ChannelAuthorize
    {
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
