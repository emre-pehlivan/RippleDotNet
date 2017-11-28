
namespace RippleDotNet.Model.Transactions
{
    public class EscrowCancelTransaction : BaseTransaction
    {
        public EscrowCancelTransaction()
        {
            TransactionType = TransactionType.EscrowCancel;
        }

        public string Owner { get; set; }

        public uint OfferSequence { get; set; }
    }
}
