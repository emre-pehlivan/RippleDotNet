using Newtonsoft.Json;

namespace RippleDotNet.Responses
{
    public class RippleResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }
    }    
}
