using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class AccountCurrenciesRequest : LedgerRequest
    {
        public AccountCurrenciesRequest(int requestId, string account) : base(requestId)
        {
            Command = "account_currencies";
            Account = account;
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("strict")]
        public bool? Strict { get; set; }
    }
}
