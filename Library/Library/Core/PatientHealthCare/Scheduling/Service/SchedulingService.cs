using System;
using System.Collections.Generic;

using System.Data;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Model.Enum;
using Library.Model.Refferal;
using Library.Repository;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.Service.ScheduleService
{
    public class SchedulingService : ISchedulingService
    {
        private IDoctorService _doctorService;
        private IDoctorScheduleService _doctorScheduleService;
        private IAppointmentService _appointmentService;
        private IRoomScheduleService _roomScheduleService;
        private IRoomService _roomService;
        public SchedulingService(IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, IAppointmentService appointmentService, IRoomScheduleService roomScheduleService, IRoomService roomService)
        {
            _doctorService = doctorService;
            _doctorScheduleService = doctorScheduleService;
            _appointmentService = appointmentService;
            _roomScheduleService = roomScheduleService;
            _roomService = roomService;
        }

        public void Schedule(Appointment appointment)
        {
            var doctorSchedule = _doctorScheduleService.Get(appointment.DoctorId);
            var roomSchedule = _roomScheduleService.Get(appointment.RoomId);
            _appointmentService.Add(appointment);
            doctorSchedule.Schedule(appointment);
            _doctorScheduleService.Update(doctorSchedule);
            roomSchedule.Schedule(appointment);
            _roomScheduleService.Update(roomSchedule);
        }

        public void Reschedule(Appointment appointment)
        {
            var doctorSchedule = _doctorScheduleService.Get(appointment.DoctorId);
            var roomSchedule = _roomScheduleService.Get(appointment.RoomId);
            var oldAppointment = _appointmentService.Get(appointment.Id);
            _appointmentService.Update(appointment);
            doctorSchedule.Reschedule(oldAppointment, appointment.TimeSlot);
            _doctorScheduleService.Update(doctorSchedule);
            roomSchedule.Reschedule(oldAppointment, appointment.TimeSlot);
            _roomScheduleService.Update(roomSchedule);
        }

        public void Unschedule(Appointment appointment)
        {
            var doctorSchedule = _doctorScheduleService.Get(appointment.DoctorId);
            var roomSchedule = _roomScheduleService.Get(appointment.RoomId);
            _appointmentService.Update(appointment);
            doctorSchedule.Unschedule(appointment);
            _doctorScheduleService.Update(doctorSchedule);
            roomSchedule.Unschedule(appointment);
            _roomScheduleService.Update(roomSchedule);
        }

        public List<KeyValuePair<int, Appointment>> GetDelayableAppointments(int doctorId, TimeSlot initialSpan, TimeSlot toDelaySpan, int duration, int numberOfDelayable)
        {
            var appointments = _appointmentService.GetAllByDoctor(doctorId, initialSpan.GetDate());
            var doctorSchedule = _doctorScheduleService.Get(doctorId);

            var delayable = appointments.Values
                .Where(appointment => initialSpan.Contains(appointment.TimeSlot) && !appointment.TimeSlot.IsShorterThan(duration))
                .Select(appointment => new KeyValuePair<int, Appointment>(doctorSchedule.CalculateDelayedAppointmentStartTimeDiff(appointment, toDelaySpan), appointment))
                .OrderBy(pair => pair.Key)
                .Take(numberOfDelayable)
                .ToList();

            return delayable;
        }

        public bool IsAvaliable(TimeSlot timeSlot)
        {
            return timeSlot.IsAfter(DateTime.Now);
        }

        public bool IsAvaliable(int doctorId, TimeSlot timeSlot)
        {
            return _doctorScheduleService.Get(doctorId).IsFree(timeSlot);
        }

        public bool IsAvaliableForVacation(int doctorId, TimeSlot timeSlot)
        {
            return _doctorScheduleService.Get(doctorId).IsFreeForVacation(timeSlot);
        }

        public bool IsAvaliableRoom(int roomId, TimeSlot timeSlot)
        {
            return _roomScheduleService.Get(roomId).IsFree(timeSlot); 
        }

        // TODO: Change to IsAvaliable from line 86.
        public bool IsAvaliable(Doctor doctor, TimeSlot timeSlot)
        {
            foreach (var appointment in _appointmentService.GetAllByDoctor(doctor.Id).Values)
            {
                if (appointment.IsCanceled) { continue; }
                if (timeSlot.OverlapsWith(appointment.TimeSlot)) { return false; }
            }
            return true;
        }

        // TODO: Maybe move these functions to appointmentService. Or instantiate appointmentService here and use its functionalities. But first ask Big Boss Rade. 

        public bool IsAvaliable(Patient patient, TimeSlot timeSlot)
        {
            foreach (var appointment in _appointmentService.GetAllByPatient(patient.Id).Values)
            {
                if (appointment.IsCanceled) { continue; }
                if (timeSlot.OverlapsWith(appointment.TimeSlot)) { return false; }
            }
            return true;
        }

        public bool IsAvailableForUpdate(Doctor doctor, TimeSlot timeSlot, Appointment appointmentToChange)
        {
            foreach (var appointment in _appointmentService.GetAllByDoctor(doctor.Id).Values)
            {
                if (appointment.Id == appointmentToChange.Id || appointment.IsCanceled)
                {
                    continue;
                }
                if (timeSlot.OverlapsWith(appointment.TimeSlot))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsAvailableForUpdate(Patient patient, TimeSlot timeSlot, Appointment appointmentToChange)
        {
            foreach (var appointment in _appointmentService.GetAllByPatient(patient.Id).Values)
            {
                if (appointment.Id == appointmentToChange.Id || appointment.IsCanceled)
                {
                    continue;
                }
                if (timeSlot.OverlapsWith(appointment.TimeSlot))
                {
                    return false;
                }
            }
            return true;
        }

        public List<TimeSlot> GetClosestTimeSlot(Doctor doctor, TimeSlot span, DateTime latestTime)
        {
            List<TimeSlot> closestTimeSlot = _doctorScheduleService.Get(doctor.Id).GetClosestTimeSlots(span, latestTime);
            if (closestTimeSlot.Count == 1 && span.Contains(closestTimeSlot[0]))
            {
                return closestTimeSlot;
            }
            foreach (DoctorSchedule doctorSchedule in _doctorScheduleService.GetAll().Values)
            {
                closestTimeSlot = doctorSchedule.GetClosestTimeSlots(span, latestTime);
                if (closestTimeSlot.Count == 1 && span.Contains(closestTimeSlot[0])) { break; }
            }
            return closestTimeSlot;
        }

        public Tuple<TimeSlot, Doctor> GetFirstFreeTimeSlotAndDoctor(Specialization specialization, TimeSlot span, int duration)
        {
            TimeSlot? firstFree = null;
            Doctor? freeDoctor = null;
            foreach (Doctor doctor in _doctorService.GetAll().Values)
            {
                if (doctor.Specialization != specialization) { continue; };

                firstFree = _doctorScheduleService.Get(doctor.Id).GetFirstFree(span, duration);

                if (firstFree != null) { freeDoctor = doctor; break; }
            }

            if (firstFree == null || freeDoctor == null) { return null; }

            return new Tuple<TimeSlot, Doctor>(firstFree, freeDoctor);
        }

        // Change the way the arguments are passed  -> use the DTO for the arguments.
        public List<KeyValuePair<int, Appointment>> GetDelayableAppointments(Specialization specialization, TimeSlot initialSpan, TimeSlot toDelaySpan, int duration, int numberOfDelayable)
        {
            var delayable = GetAllDoctorSchedules(specialization).Values
                .SelectMany(ds => GetDelayableAppointments(ds.Id, initialSpan, toDelaySpan, duration, numberOfDelayable))
                .OrderBy(kv => kv.Key)
                .Take(numberOfDelayable)
                .ToList();
            return delayable;
        }

        // Simplified but still may not meant be to be here.
        public Dictionary<int, DoctorSchedule> GetAllDoctorSchedules(Specialization specialization)
        {
            return _doctorScheduleService.GetAll(_doctorService.GetAll(specialization));
        }

        public int GetFirstAvaliableDoctor(Specialization specialization, TimeSlot timeSlot)
        {
            var availableDoctors = _doctorService.GetAll(specialization)
                .Where(doctor => IsAvaliable(doctor.Key, timeSlot))
                .Select(doctor => doctor.Key);

            return availableDoctors.FirstOrDefault();
        }

        public int GetFirstAvaliableRoom(TimeSlot timeSlot)
        {
            var firstAvaliable = GetFirstAvaliableRoom(RoomType.OPERATION_ROOM, timeSlot);
            if (firstAvaliable != 0)
            {
                return firstAvaliable;
            }
            return GetFirstAvaliableRoom(RoomType.EXAMINATION_ROOM, timeSlot);
        }

        public int GetFirstAvaliableRoom(RoomType roomType, TimeSlot timeSlot)
        {
            var avaliableRooms = _roomService.GetAll(roomType)
                .Where(room => IsAvaliableRoom(room.Key, timeSlot))
                .Select(room => room.Key);

            return avaliableRooms.FirstOrDefault();
        }
    }
}
