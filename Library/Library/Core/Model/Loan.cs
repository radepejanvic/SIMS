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
        public string InventoryNumber;
        public int MembershipCardId;
        public DateTime ExpirationDate;
        public DateTime? RetrievalDate;

        public Loan()
        {
            
        }

        public Loan(string inventoryNumber, int membershipCardId, DateTime expirationDate, DateTime? retrievalDate)
        {
            InventoryNumber = inventoryNumber;
            MembershipCardId = membershipCardId;
            ExpirationDate = expirationDate;
            RetrievalDate = retrievalDate;
        }
    }
}
