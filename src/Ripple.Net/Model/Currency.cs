using Newtonsoft.Json;

namespace RippleDotNet.Model
{
    public class Currency
    {
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }
    }
}
