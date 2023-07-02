using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ICRUDRepository<Loan> _repo;

        public LoanRepository(ICRUDRepository<Loan> repo)
        {
            _repo = repo;
        }

        public void Add(Loan loan)
        {
            _repo.Add(loan);
        }

        public void Update(Loan loan)
        {
            _repo.Update(loan);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Loan Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Loan> GetAll()
        {
            return _repo.GetAll();
        }

        //public Dictionary<int, Loan> GetAll(int bookCopyId)
        //{
        //    return _repo.GetAll().Values
        //        .Where(loan => loan.BookCopyId == bookCopyId)
        //        .ToDictionary(loan => loan.Id, loan => loan);
        //}

        public List<string> GetAllLoanedBooks()
        {
            return _repo.GetAll().Values
                .Where(loan => loan.RetrievalDate is null)
                .Select(loan => loan.InventoryNumber)
                .ToList();
        }

        public int GetNumberOfActiveLoans(int membershipCardId)
        {
            return _repo.GetAll().Values
                .Where(loan => loan.MembershipCardId == membershipCardId && loan.RetrievalDate is null)
                .ToList().Count;
        }


    }
}
