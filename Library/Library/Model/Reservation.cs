using Library.Core.Helpers.Serializer;
using Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Reservation : ISerializable
    {
        public int Id { get; set; }
        public int MembershipCardId;
        public int BookTitleId;
        public ReservationStatus Status;
        public DateTime ExpirationDate;

        public Reservation()
        {
            
        }

        public Reservation(int membershipCardId, int bookTitleId, ReservationStatus status, DateTime expirationDate)
        {
            MembershipCardId = membershipCardId;
            BookTitleId = bookTitleId;
            Status = status;
            ExpirationDate = expirationDate;
        }
    }
}
