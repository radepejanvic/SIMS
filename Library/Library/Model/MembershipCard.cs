using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class MembershipCard : ISerializable
    {
        public int Id { get; set; }
        public int MembershipId;
        public int PersonId;
        public DateTime PaymentDate;
        public DateTime ExpirationDate;

        public MembershipCard()
        {
            
        }

        public MembershipCard(int membershipId, int personId, DateTime paymentDate, DateTime expirationDate)
        {
            MembershipId = membershipId;
            PersonId = personId;
            PaymentDate = paymentDate;
            ExpirationDate = expirationDate;
        }
    }
}
