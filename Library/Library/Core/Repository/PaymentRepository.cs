using Library.Core.Model;
using Library.Core.Repository.Interface;
using Library.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace Library.Core.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ICRUDRepository<Payment> _repo;

        public PaymentRepository(ICRUDRepository<Payment> repo)
        {
            _repo = repo;
        }

        public void Add(Payment payment)
        {
            _repo.Add(payment);
        }

        public void Update(Payment payment)
        {
            _repo.Update(payment);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Payment Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Payment> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Payment> GetAllByDate()
        {
            return _repo.GetAll().Values
                .Where(payment => payment.PaymentDate.Date == DateTime.Today)
                .ToList();
        }


    }
}
