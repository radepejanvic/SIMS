using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.Repository
{
    public class CustomNotificationRepository : ICustomNotificationRepository
    {
        private readonly ICRUDRepository<CustomNotification> _crud;
        public CustomNotificationRepository(ICRUDRepository<CustomNotification> crud)
        {
            _crud = crud;
        }

        public void Add(CustomNotification notification)
        {
            _crud.Add(notification);
        }

        public CustomNotification Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, CustomNotification> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, CustomNotification> GetAllByPatient(int patientId)
        {
            return _crud.GetAll().Values.Where(notification => notification.PatientId == patientId)
                    .ToDictionary(notification => notification.Id, notification => notification);
        }
        public void Update(CustomNotification customNotification)
        {
            _crud.Update(customNotification);
        }
    }
}
