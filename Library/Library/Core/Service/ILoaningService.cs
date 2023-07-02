using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service
{
    public interface ILoaningService
    {
        Dictionary<int, BookCopy> GetAllAvaliableBooks();
        bool HasReachedTheLimit(int membershipCardId);
        void LoanBook(int membershipCardId, int bookCopyId);
        void RetrieveBook();
    }
}