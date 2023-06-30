using Library.Core.Helpers.Serializer;
using Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Library.Model
{
    public class Membership : ISerializable
    {
        public int Id { get; set; }
        public MembershipType MembershipType;
        public float Price;
        public int LoansNumber;
        public int LoanLength;
        public float FinePerDay;

        public Membership()
        {
            
        }

        public Membership(MembershipType membershipType, float price, int loansNumber, int loanLength, float finePerDay)
        {
            MembershipType = membershipType;
            Price = price;
            LoansNumber = loansNumber;
            LoanLength = loanLength;
            FinePerDay = finePerDay;
        }
    }
}
