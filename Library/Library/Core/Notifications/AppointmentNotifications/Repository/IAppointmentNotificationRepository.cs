using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IAppointmentNotificationRepository
    {
        void Add(AppointmentNotification notification);
        AppointmentNotification Get(int id);
        Dictionary<int, AppointmentNotification> GetAll();
        List<AppointmentNotification> GetAll(int patientId);
        void Remove(int id);
    }
}