using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class AccountCurrenciesRequest : LedgerRequest
    {
        public AccountCurrenciesRequest(string account)
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
