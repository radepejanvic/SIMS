using Library.Core.Model;
using System.Collections.Generic;

namespace Library.Core.Repository.Interface
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        Payment Get(int id);
        Dictionary<int, Payment> GetAll();
        void Remove(int id);
        void Update(Payment payment);
        List<Payment> GetAllByDate();
    }
}