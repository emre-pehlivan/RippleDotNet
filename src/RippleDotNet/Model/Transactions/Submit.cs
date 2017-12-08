using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;
using RippleDotNet.Model.Transactions.TransactionTypes;

namespace RippleDotNet.Model.Transactions
{
    public class Submit
    {
        [JsonProperty("engine_result")]
        public string EngineResult { get; set; }

        [JsonProperty("engine_result_code")]
        public int EngineResultCode { get; set; }

        [JsonProperty("engine_result_message")]
        public string EngineResultMessage { get; set; }

        [JsonProperty("tx_blob")]
        public string TransactionBlob { get; set; }

        [JsonProperty("tx_json")]
        public dynamic TransactionJson { get; set; }

        [JsonIgnore]
        public BaseTransaction Transaction => JsonConvert.DeserializeObject<BaseTransaction>(TransactionJson.ToString());
    }
}
