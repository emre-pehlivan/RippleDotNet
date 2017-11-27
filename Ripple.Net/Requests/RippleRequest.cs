using Newtonsoft.Json;

namespace RippleDotNet.Requests
{
    public class RippleRequest
    {
        public RippleRequest(){ }

        public RippleRequest(int id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
