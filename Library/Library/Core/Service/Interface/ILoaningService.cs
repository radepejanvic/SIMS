using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface ILoaningService
    {
        Dictionary<int, BookCopy> GetAllAvaliableBooks();
        List<Loan> GetAll();
        bool HasReachedTheLimit(int membershipCardId);
        void LoanBook(int membershipCardId, int bookCopyId);
        void RetrieveBook(int loanId);
        void RemoveBookCopy(string inventoryNumber);
    }
}