
namespace RippleDotNet.Model
{
    public enum TransactionType
    {
        Payment,
        OfferCreate,
        OfferCancel,
        TrustSet,
        AccountSet,
        SetRegularKey,
        SignerListSet,
        EscrowCreate,
        EscrowFinish,
        EscrowCancel,
        PaymentChannelCreate,
        PaymentChannelFund,
        PaymentChannelClaim
    }
}
