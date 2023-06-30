using Library.Core.Helpers.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookCopy : ISerializable
    {
        public int Id { get; set; }
        public int BookTitleId;
        public int LibraryBranchId;
        public string InventoryNumber;
        public string ISBN;
        public float Price;
        public DateTime ArrivalDate;

        public BookCopy()
        {
            
        }

        public BookCopy(int bookTitleId, int libraryBranchId, string inventoryNumber, string iSBN, float price, DateTime arrivalDate)
        {
            BookTitleId = bookTitleId;
            LibraryBranchId = libraryBranchId;
            InventoryNumber = inventoryNumber;
            ISBN = iSBN;
            Price = price;
            ArrivalDate = arrivalDate;
        }
    }
}
