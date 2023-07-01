using Library.Core.Model;
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
    }
}
