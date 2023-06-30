using System.Collections.Generic;
using Library.Model;

namespace Library.Service.TehnicalService.Interface
{
    public interface IAppointmentNotificationService
    {
        void Add(AppointmentNotification notification);
        AppointmentNotification Get(int id);
        Dictionary<int, AppointmentNotification> GetAll();
        void NotifyDoctor(int id);
        void NotifyPatient(int id);
        void Remove(int id);
        void ShowDelayedMessage(AppointmentNotification notification);
        void ShowNewMessage(AppointmentNotification notification);
    }
}