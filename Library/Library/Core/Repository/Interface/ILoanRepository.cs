using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface ILoanRepository
    {
        void Add(Loan loan);
        Loan Get(int id);
        Dictionary<int, Loan> GetAll();
        List<string> GetAllLoanedBooks();
        int GetNumberOfActiveLoans(int membershipCardId);
        void Remove(int id);
        void Update(Loan loan);
        List<Loan> GetAllLoans();
    }
}