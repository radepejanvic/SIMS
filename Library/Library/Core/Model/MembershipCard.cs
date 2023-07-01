using Library.Core.Model.MembershipCardState;
using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class MembershipCard : ISerializable
    {
        public int Id { get; set; }
        public int PersonId;
        public int MembershipId;
        public DateTime PaymentDate;
        public DateTime ExpirationDate;
        public State State;

        public MembershipCard()
        {
            
        }

        public MembershipCard(int personId, int membershipId, DateTime paymentDate, DateTime expirationDate)
        {
            PersonId = personId;
            MembershipId = membershipId;
            PaymentDate = paymentDate;
            ExpirationDate = expirationDate;
            State = new Active(this);
        }
    }
}
