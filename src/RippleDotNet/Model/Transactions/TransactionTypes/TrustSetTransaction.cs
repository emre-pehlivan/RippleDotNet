using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class TrustSetTransaction : BaseTransaction
    {
        public TrustSetTransaction()
        {
            TransactionType = TransactionType.TrustSet;
        }

        [JsonConverter(typeof(CurrencyConverter))]
        public object LimitAmount {get; set; }

        public uint? QualityIn { get; set; }

        public uint? QualityOut { get; set; }
    }
}
