using Library.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model
{
    public class BookCopy : ISerializable
    {
        public int Id { get; set; }
        public int BookTitleId;
        public int BranchId;
        public string ISBN;
        public string InventoryNumber;
        public float Price;
        public DateTime ArrivalDate;

        public BookCopy()
        {
            
        }

        public BookCopy(int bookTitleId, int branchId, string iSBN, string inventoryNumber, float price, DateTime arrivalDate)
        {
            BookTitleId = bookTitleId;
            BranchId = branchId;
            ISBN = iSBN;
            InventoryNumber = inventoryNumber;
            Price = price;
            ArrivalDate = arrivalDate;
        }
    }
}
