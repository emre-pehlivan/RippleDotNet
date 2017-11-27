using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class AccountLinesRequest : LedgerRequest
    {
        public AccountLinesRequest(int requestId, string account) : base(requestId)
        {
            Account = account;
            Command = "account_lines";
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("peer")]
        public string Peer { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("marker")]
        public object Marker { get; set; }
    }
}
