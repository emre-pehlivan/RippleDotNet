using Newtonsoft.Json;
using RippleDotNet.Json.Converters;
using RippleDotNet.Model.Transactions.TransactionTypes;

namespace RippleDotNet.Model.Ledger
{
    [JsonConverter(typeof(HashOrTransactionConverter))]
    public class HashOrTransaction
    {
        public string TransactionHash { get; set; }

        public BaseTransaction Transaction { get; set; }
    }
}
