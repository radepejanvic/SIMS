using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface ICustomNotificationRepository
    {
        CustomNotification Get(int id);
        Dictionary<int, CustomNotification> GetAll();
        Dictionary<int, CustomNotification> GetAllByPatient(int patientId);
        void Add(CustomNotification notification);
        void Update(CustomNotification customNotification);
    }
}