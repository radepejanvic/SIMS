using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class AppointmentNotificationRepository : IAppointmentNotificationRepository
    {
        private readonly ICRUDRepository<AppointmentNotification> _repo;

        public AppointmentNotificationRepository(ICRUDRepository<AppointmentNotification> repo)
        {
            _repo = repo;
        }

        public void Add(AppointmentNotification notification)
        {
            _repo.Add(notification);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public AppointmentNotification Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, AppointmentNotification> GetAll()
        {
            return _repo.GetAll();
        }

        public List<AppointmentNotification> GetAll(int patientId)
        {
            return GetAll().Values.Where(o => o.PatientId == patientId).ToList();
        }
    }
}
