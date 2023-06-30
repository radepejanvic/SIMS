using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Loan : ISerializable
    {
        public int Id { get; set; }
        public int BookCopyId;
        public int MembershipCardId;
        public DateTime ExpirationDate;
        public DateTime? ReturnDate;

        public Loan()
        {
            
        }

        public Loan(int bookCopyId, int membershipCardId, DateTime expirationDate, DateTime? returnDate)
        {
            BookCopyId = bookCopyId;
            MembershipCardId = membershipCardId;
            ExpirationDate = expirationDate;
            ReturnDate = returnDate;
        }
    }
}
