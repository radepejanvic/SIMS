using Library.Core.Enum;
using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Payment : ISerializable
    {
        public int Id { get; set; }
        public int MembershipCardId;
        public float Amount;
        public DateTime PaymentDate;
        public PaymentReason Reason;

        public Payment()
        {
            
        }

        public Payment(int membershipCardId, float amount, DateTime paymentDate, PaymentReason reason)
        {
            MembershipCardId = membershipCardId;
            Amount = amount;
            PaymentDate = paymentDate;
            Reason = reason;
        }
    }
}
