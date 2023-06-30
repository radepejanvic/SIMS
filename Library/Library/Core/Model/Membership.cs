using Library.Core.Enum;
using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Membership : ISerializable
    {
        public int Id { get; set; }
        public MembershipType MembershipType;
        public float Price;
        public int LoanCount;
        public int LoanDuration;
        public float FinePerDay;

        public Membership()
        {
            
        }

        public Membership(MembershipType membershipType, float price, int loanCount, int loanDuration, float finePerDay)
        {
            MembershipType = membershipType;
            Price = price;
            LoanCount = loanCount;
            LoanDuration = loanDuration;
            FinePerDay = finePerDay;
        }
    }
}
