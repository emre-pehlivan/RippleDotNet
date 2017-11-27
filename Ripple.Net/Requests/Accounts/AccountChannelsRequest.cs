using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class AccountChannelsRequest : LedgerRequest
    {
        public AccountChannelsRequest(int requestId, string account) : base(requestId)
        {
            Account = account;
            Command = "account_channels";
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("destination_account")]
        public string DestinationAccount { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("marker")]
        public object Marker { get; set; }
    }
}
