using Library.Core.Model;
using System;

namespace Library.Core.Service.Interface
{
    public interface IPaymentService
    {
        float GetPrice(int MembershipCardId, DateTime date);
        float GetPrice(string inventoryNumber);
        void Add(Payment payment);
    }
}