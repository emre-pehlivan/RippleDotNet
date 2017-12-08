namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class OfferCancelTransaction : BaseTransaction
    {

        public OfferCancelTransaction()
        {
            TransactionType = TransactionType.OfferCancel;
        }

        public uint OfferSequence { get; set; }
    }
}
