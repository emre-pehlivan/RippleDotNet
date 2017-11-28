
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

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
        PaymentChannelClaim,
        EnableAmendment,
        SetFee
    }

    public enum LedgerEntryType
    {
        AccountRoot,
        Amendments,
        DirectoryNode,
        Escrow,
        FeeSettings,
        LedgerHashes,
        Offer,
        PayChannel,
        RippleState,
        SignerList
    }

    [Flags]
    public enum RippleStateFlags
    {
        lsfLowReserve = 65536,
        lsfHighReserve = 131072,
        lsfLowAuth = 262144,
        lsfHighAuth = 524288,
        lsfLowNoRipple = 1048576,
        lsfHighNoRipple = 2097152,
        lsfLowFreeze = 4194304,
        lsfHighFreeze = 8388608
    }

    [Flags]
    public enum AccountRootFlags
    {
        lsfPasswordSpent = 65536,
        lsfRequireDestTag = 131072,
        lsfRequireAuth = 262144,
        lsfDisallowXRP = 524288,
        lsfDisableMaster = 1048576,
        lsfNoFreeze = 2097152,
        lsfGlobalFreeze = 4194304,
        lsfDefaultRipple = 8388608
    }

    [Flags]
    public enum OfferFlags
    {
        lsfPassive = 65536,
        lsfSell = 131072
    }

    [Flags]
    public enum PaymentChannelClaimFlags
    {
        tfRenew = 65536,
        tfClose = 131072
    }

    public enum RoleType
    {
        [EnumMember(Value = "gateway")]
        Gateway,
        [EnumMember(Value = "user")]
        User
    }
}
