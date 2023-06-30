using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class Loan : ISerializable
    {
        public int Id { get; set; }
        public int BookCopyId;
        public int MembershipCardId;
        public DateTime ExpirationDate;
        public DateTime? RetrievalDate;

        public Loan()
        {
            
        }

        public Loan(int bookCopyId, int membershipCardId, DateTime expirationDate, DateTime? retrievalDate)
        {
            BookCopyId = bookCopyId;
            MembershipCardId = membershipCardId;
            ExpirationDate = expirationDate;
            RetrievalDate = retrievalDate;
        }
    }
}
