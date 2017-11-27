using Newtonsoft.Json;

namespace RippleDotNet.Model
{
    public class Path : Currency
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("type_hex")]
        public string TypeHex { get; set; }
    }
}
