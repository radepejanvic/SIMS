using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface ILoaningService
    {
        Dictionary<int, BookCopy> GetAllAvaliableBooks();
        string GetBookTitle(int bookId);
        bool HasReachedTheLimit(int membershipCardId);
        void LoanBook(int membershipCardId, int bookCopyId);
        void RetrieveBook();
    }
}