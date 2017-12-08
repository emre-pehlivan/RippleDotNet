using Newtonsoft.Json;

namespace RippleDotNet.Model.Server
{
    public class Fee
    {
        [JsonProperty("current_ledger_size")]
        public uint CurrentLedgerSize { get; set; }

        [JsonProperty("current_queue_size")]
        public uint CurrentQueueSize { get; set; }

        [JsonProperty("drops")]
        public Drops Drops { get; set; }

        [JsonProperty("expected_ledger_size")]
        public uint ExpectedLedgerSize { get; set; }

        [JsonProperty("ledger_current_index")]
        public uint LedgerCurrentIndex { get; set; }

        [JsonProperty("levels")]
        public Levels Levels { get; set; }

        [JsonProperty("max_queue_size")]
        public uint MaxQueueSize { get; set; }
    }

    public class Drops
    {
        [JsonProperty("base_fee")]
        public uint BaseFee { get; set; }

        [JsonProperty("median_fee")]
        public uint MedianFee { get; set; }

        [JsonProperty("minimum_fee")]
        public uint MinimumFee { get; set; }

        [JsonProperty("open_ledger_fee")]
        public uint OpenLedgerFee { get; set; }
    }

    public class Levels
    {
        [JsonProperty("median_level")]
        public uint MedianLevel { get; set; }

        [JsonProperty("minimum_level")]
        public uint MinimumLevel { get; set; }

        [JsonProperty("open_ledger_level")]
        public uint OpenLedgerLevel { get; set; }

        [JsonProperty("reference_level")]
        public uint ReferenceLevel { get; set; }
    }

}
