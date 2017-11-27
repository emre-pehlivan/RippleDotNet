namespace RippleDotNet.Model.Transactions
{
    public class EnableAmendmentTransaction : RippleTransaction
    {
        public string Amendment { get; set; }

        public uint LedgerSequence { get; set; }
    }
}
