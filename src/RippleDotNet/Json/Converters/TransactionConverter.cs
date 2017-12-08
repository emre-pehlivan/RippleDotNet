using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RippleDotNet.Model.Transactions.TransactionTypes;

namespace RippleDotNet.Json.Converters
{
    public class TransactionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public BaseTransaction Create(Type objectType, JObject jObject)
        {
            string transactionType = jObject.Property("TransactionType").Value.ToString();
            switch (transactionType)
            {
                case "AccountSet":
                    return new AccountSetTransaction();
                case "EscrowCancel":
                    return new EscrowCancelTransaction();
                case "EscrowCreate":
                    return new EscrowCreateTransaction();
                case "EscrowFinish":
                    return new EscrowFinishTransaction();
                case "OfferCancel":
                    return new OfferCancelTransaction();
                case "OfferCreate":
                    return new OfferCreateTransaction();
                case "Payment":
                    return new PaymentTransaction();
                case "PaymentChannelClaim":
                    return new PaymentChannelClaimTransaction();
                case "PaymentChannelCreate":
                    return new PaymentChannelCreateTransaction();
                case "PaymentChannelFund":
                    return new PaymentChannelFundTransaction();
                case "SetRegularKey":
                    return new SetRegularKeyTransaction();
                case "SignerListSet":
                    return new SignerListSetTransaction();
                case "TrustSet":
                    return new TrustSetTransaction();

                case "EnableAmendment":
                    return new EnableAmendmentTransaction();
                case "SetFee":
                    return new SetFeeTransaction();
            }
            throw new Exception("Can't create transaction type" + transactionType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;            
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite => false;
    }
}
