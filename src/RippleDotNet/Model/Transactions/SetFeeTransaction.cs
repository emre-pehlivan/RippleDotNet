
namespace RippleDotNet.Model.Transactions
{
    public class SetFeeTransaction : BaseTransaction
    {
        public string BaseFee { get; set; }

        public uint ReferenceFeeUnits { get; set; }

        public uint ReserveBase { get; set; }

        public uint ReserveIncrement { get; set; }

        public uint LedgerSequence { get; set; }
    }
}
