
namespace RippleDotNet.Model.Transactions
{
    public class PaymentChannelClaimTransaction : BaseTransaction
    {
        public PaymentChannelClaimTransaction()
        {
            TransactionType = TransactionType.PaymentChannelClaim;
        }

        public string Channel { get; set; }

        public string Balance { get; set; }

        public string Amount { get; set; }

        public PaymentChannelClaimFlags? Flags { get; set; }

        public string Signature { get; set; }

        public string PublicKey { get; set; }
    }
}
