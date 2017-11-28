using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions
{
    public class TrustSetTransaction : BaseTransaction
    {
        [JsonConverter(typeof(CurrencyConverter))]
        public object LimitAmount {get; set; }

        public uint? QualityIn { get; set; }

        public uint? QualityOut { get; set; }
    }
}
