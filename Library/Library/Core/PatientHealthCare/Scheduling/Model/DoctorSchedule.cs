using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class DoctorSchedule : Scheduler
    {
        public DoctorSchedule()
        {
        }

        public DoctorSchedule(int id, Dictionary<DateOnly, List<TimeSlot>> freeTimeSlots, Dictionary<DateOnly, List<int>> appointments) : base(id, freeTimeSlots, appointments)
        {
        }

        public int CalculateDelayedAppointmentStartTimeDiff(Appointment appointment, TimeSlot span)
        {
            var delayed = GetFirstFree(span, appointment.TimeSlot.GetDuration());
            return appointment.TimeSlot.GetStartTimeDiff(delayed);
        }

        public List<TimeSlot> GetClosestTimeSlots(TimeSlot span, DateTime latestTime)
        {
            var closestTimeSlots = new List<TimeSlot>();

            closestTimeSlots = GetClosestInSpan(span, latestTime);
            if (closestTimeSlots.Count == 0)
            {
                span.SetHours(8, 20);

                closestTimeSlots = GetClosestInSpan(span, latestTime);
                if (closestTimeSlots.Count == 0) { return closestTimeSlots; }
            }
            closestTimeSlots = GetClosestOutOfSpan(span, latestTime);

            return closestTimeSlots;
        }

        public List<TimeSlot> GetClosestInSpan(TimeSlot span, DateTime latestTime)
        {
            List<TimeSlot> closestTimeSlots = new List<TimeSlot>();
            DateTime startDate = DateTime.Now.Date;
            while (startDate != latestTime.AddDays(1).Date)
            {
                var firstFree = GetFirstFree(span, 15);
                if (firstFree is not null)
                {
                    closestTimeSlots.Add(firstFree);
                    break;
                }
                span.AddDays(1);
                startDate = startDate.AddDays(1);
            }
            return closestTimeSlots;
        }

        public List<TimeSlot> GetClosestOutOfSpan(TimeSlot span, DateTime latestTime)
        {
            List<TimeSlot> closestTimeSlots = new List<TimeSlot>();
            while (closestTimeSlots.Count != 3)
            {
                var firstFree = GetFirstFree(span, 15);
                if (firstFree is not null)
                {
                    closestTimeSlots.Add(firstFree);
                    break;
                }
                span.AddDays(1);
            }
            return closestTimeSlots;
        }
        public List<int> GetAllAppointmentsFor(TimeSlot span)
        {
            var day = DateOnly.FromDateTime(span.From);
            var appointments = new List<int>();
            while (day <= DateOnly.FromDateTime(span.To))
            {
                appointments.AddRange(Appointments[day]);
                day = day.AddDays(1);
            }

            return appointments;
        }
    }
}
