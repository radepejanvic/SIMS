using Library.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Service
{
    public class LoaningService
    {
        private readonly IMembershipCardRepository _membershipCardRepo;
        private readonly ILoanRepository _loanRepo;
        public LoaningService(IMembershipCardRepository membershipCardRepo, ILoanRepository loanRepo) 
        {
            _membershipCardRepo = membershipCardRepo;
            _loanRepo = loanRepo;

        }
    }
}
