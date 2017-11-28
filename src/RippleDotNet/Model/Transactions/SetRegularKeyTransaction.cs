
namespace RippleDotNet.Model.Transactions
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
