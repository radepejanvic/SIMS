using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Service.ScheduleService.Interface
{
    public interface IDoctorScheduleService
    {
        void Add(DoctorSchedule doctorSchedule);
        DoctorSchedule Get(int id);
        Dictionary<int, DoctorSchedule> GetAll();
        Dictionary<int, DoctorSchedule> GetAll(Dictionary<int, Doctor> doctors);
        public List<TimeSlot> GetClosestTimeSlot(Doctor doctor, TimeSlot span, DateTime latestTime);
        void Remove(int id);
        void Update(DoctorSchedule doctorSchedule);
    }
}