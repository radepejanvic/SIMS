using Library.Core.Model;
using System;
using System.Collections.Generic;

namespace Library.Core.Service.Interface
{
    public interface IPaymentService
    {
        float GetPrice(int MembershipCardId, DateTime date);
        float GetPrice(string inventoryNumber);
        void Add(Payment payment);
        List<Payment> GetAllByDate();
        int GetAllByDateCount();
        float GetAllByDateAmount();
        int GetAllDamagedByDateCount();
        float GetAllDamagedByDateAmount();
        int GetAllLossByDateCount();
        float GetAllLossByDateAmount();
        int GetAllDelayedByDateCount();
        float GetAllDelayedByDateAmount();
    }
}