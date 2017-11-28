using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Ledger
{
    public class AmendmentsLedgerObject : BaseRippleLedgerObject
    {
        public List<Majority> Majorities { get; set; }

        public List<string> Amendments { get; set; }

        public uint Flags { get; set; }
    }

    public class Majority
    {
        public string Amendment { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? CloseTime { get; set; }
    }
}
