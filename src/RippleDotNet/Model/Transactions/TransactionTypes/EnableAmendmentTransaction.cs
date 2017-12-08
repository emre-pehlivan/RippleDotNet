namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class EnableAmendmentTransaction : BaseTransaction
    {

        public EnableAmendmentTransaction()
        {
            TransactionType = TransactionType.EnableAmendment;
        }

        public string Amendment { get; set; }

        public uint LedgerSequence { get; set; }
    }
}
