using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.Service.ScheduleService
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private IDoctorScheduleRepository _crud;

        public DoctorScheduleService(IDoctorScheduleRepository crud)
        {
            _crud = crud;
        }

        public void Add(DoctorSchedule doctorSchedule)
        {
            _crud.Add(doctorSchedule);
        }

        public void Update(DoctorSchedule doctorSchedule)
        {
            _crud.Update(doctorSchedule);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public DoctorSchedule Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, DoctorSchedule> GetAll()
        {
            return _crud.GetAll();
        }

        public Dictionary<int, DoctorSchedule> GetAll(Dictionary<int, Doctor> doctors)
        {
            return _crud.GetAll(doctors);
        }

        public List<TimeSlot> GetClosestTimeSlot(Doctor doctor, TimeSlot span, DateTime latestTime)
        {
            throw new NotImplementedException();
        }
    }
}
