using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class TrustSetTransaction : BaseTransaction
    {
        public TrustSetTransaction()
        {
            TransactionType = TransactionType.TrustSet;
            Flags = TrustSetFlags.tfFullyCanonicalSig | TrustSetFlags.tfSetNoRipple;
        }

        public new TrustSetFlags? Flags { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public Currency LimitAmount {get; set; }

        public uint? QualityIn { get; set; }

        public uint? QualityOut { get; set; }
    }
}
