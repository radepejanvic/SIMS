using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IDoctorScheduleRepository
    {
        void Add(DoctorSchedule doctorSchedule);
        DoctorSchedule Get(int id);
        Dictionary<int, DoctorSchedule> GetAll();
        Dictionary<int, DoctorSchedule> GetAll(Dictionary<int, Doctor> doctors);
        void Remove(int id);
        void Update(DoctorSchedule doctorSchedule);
    }
}