using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class GatewayBalances : LedgerRequest
    {
        public GatewayBalances(int requestId, string account) : base(requestId)
        {
            Account = account;
            Command = "gateway_balances";
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("strict")]
        public bool? Strict { get; set; }

        [JsonProperty("hotwallet")]
        public object HotWallet { get; set; }
    }
}
