
namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    public class SetRegularKeyTransaction : BaseTransaction
    {

        public SetRegularKeyTransaction()
        {
            TransactionType = TransactionType.SetRegularKey;
        }


        public string RegularKey { get; set; }
    }
}
