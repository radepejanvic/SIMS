using System;
using System.Collections.Generic;
using Library.Model;
using Library.Model.Enum;

namespace Library.Service.ScheduleService.Interface
{
    public interface ISchedulingService
    {
        List<KeyValuePair<int, Appointment>> GetDelayableAppointments(Specialization specialization, TimeSlot initialSpan, TimeSlot toDelaySpan, int duration, int numberOfDelayable);
        Tuple<TimeSlot, Doctor> GetFirstFreeTimeSlotAndDoctor(Specialization specialization, TimeSlot span, int duration);
        List<TimeSlot> GetClosestTimeSlot(Doctor doctor, TimeSlot span, DateTime latestTime);
        bool IsAvailableForUpdate(Doctor doctor, TimeSlot timeSlot, Appointment appointmentToChange);
        bool IsAvailableForUpdate(Patient patient, TimeSlot timeSlot, Appointment appointmentToChange);
        void Schedule(Appointment appointment);
        void Reschedule(Appointment appointment);
        void Unschedule(Appointment appointment);
        List<KeyValuePair<int, Appointment>> GetDelayableAppointments(int doctorId, TimeSlot initialSpan, TimeSlot toDelaySpan, int duration, int numberOfDelayable);
        bool IsAvaliable(Doctor doctor, TimeSlot timeSlot);
        bool IsAvaliable(Patient patient, TimeSlot timeSlot);
        bool IsAvaliable(int doctorId, TimeSlot timeSlot);
        bool IsAvaliableForVacation(int doctorId, TimeSlot timeSlot);
        int GetFirstAvaliableDoctor(Specialization specialization, TimeSlot timeSlot);
        int GetFirstAvaliableRoom(RoomType roomType, TimeSlot timeSlot);
        bool IsAvaliable(TimeSlot timeSlot);
        bool IsAvaliableRoom(int roomId, TimeSlot timeSlot);
        int GetFirstAvaliableRoom(TimeSlot timeSlot);
    }
}