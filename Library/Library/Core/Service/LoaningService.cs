using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class LoaningService : ILoaningService
    {
        private readonly IMembershipCardRepository _membershipCardRepo;
        private readonly IMembershipRepository _membershipRepo;
        private readonly IBookCopyRepository _bookCopyRepo;
        private readonly ILoanRepository _loanRepo;


        public LoaningService(IMembershipCardRepository membershipCardRepo, ILoanRepository loanRepo, IBookCopyRepository bookCopyRepo, IMembershipRepository membershipRepo)
        {
            _membershipCardRepo = membershipCardRepo;
            _loanRepo = loanRepo;
            _bookCopyRepo = bookCopyRepo;
            _membershipRepo = membershipRepo;
        }

        public void LoanBook(int membershipCardId, int bookCopyId)
        {
            var membershipCard = _membershipCardRepo.Get(membershipCardId);
            var membership = _membershipRepo.Get(membershipCard.MembershipId);
            var bookCopy = _bookCopyRepo.Get(bookCopyId);
            _loanRepo.Add(new Loan(bookCopy.InventoryNumber, membershipCardId, DateTime.Today.AddDays(membership.LoanDuration), null));
        }

        public bool HasReachedTheLimit(int membershipCardId)
        {
            var membershipCard = _membershipCardRepo.Get(membershipCardId);
            var membership = _membershipRepo.Get(membershipCard.MembershipId);
            return _loanRepo.GetNumberOfActiveLoans(membershipCardId) == membership.LoanCount;
        }

        public void RetrieveBook(int loanId)
        {
            var loan = _loanRepo.Get(loanId);
            loan.RetrievalDate = DateTime.Now;
            _loanRepo.Update(loan);
        }

        public Dictionary<int, BookCopy> GetAllAvaliableBooks()
        {
            return _bookCopyRepo.GetAllAvaliableBooks(_loanRepo.GetAllLoanedBooks());
        }
        
        public List<Loan> GetAll()
        {
            return _loanRepo.GetAllLoans();
        }

        public void RemoveBookCopy(string inventoryNumber)
        {
            var bookCopy = _bookCopyRepo.Get(inventoryNumber);
            _bookCopyRepo.Remove(bookCopy.Id);
        }
    }
}
