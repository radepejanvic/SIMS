using Library.Core.Helpers.Serializer;
using Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Payment : ISerializable
    {
        public int Id { get; set; }
        public int MembershipCardId;
        public float Price;
        public DateTime PaymentDate;
        public PaymentReason PaymentReason;

        public Payment()
        {
            
        }

        public Payment(int membershipCardId, float price, DateTime paymentDate, PaymentReason paymentReason)
        {
            MembershipCardId = membershipCardId;
            Price = price;
            PaymentDate = paymentDate;
            PaymentReason = paymentReason;
        }
    }
}
