using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public abstract class Scheduler : ISerializable
    {
        public int Id { get; set; }
        public Dictionary<DateOnly, List<TimeSlot>> FreeTimeSlots;
        public Dictionary<DateOnly, List<int>> Appointments;

        public Scheduler()
        {
        }

        public Scheduler(int id, Dictionary<DateOnly, List<TimeSlot>> freeTimeSlots, Dictionary<DateOnly, List<int>> appointments)
        {
            Id = id;
            FreeTimeSlots = freeTimeSlots;
            Appointments = appointments;
        }
        public void AddFree(TimeSlot timeSlot)
        {
            FreeTimeSlots[timeSlot.GetDate()].Add(timeSlot);
        }

        public void RemoveFree(TimeSlot timeSlot)
        {
            FreeTimeSlots[timeSlot.GetDate()].Remove(timeSlot);
        }

        public List<TimeSlot> GetAllFree(DateOnly date)
        {
            return FreeTimeSlots[date];
        }

        public void ReserveFree(TimeSlot timeSlot)
        {
            foreach (TimeSlot free in GetAllFree(timeSlot.GetDate()))
            {
                if (!free.Contains(timeSlot)) { continue; }

                var after = free.Split(new TimeSlot(timeSlot));
                var before = free;
                AdjustFree(before, after);

                return;
            }
        }

        public TimeSlot GetFirstFree(TimeSlot span, int duration)
        {
            TimeSlot firstFree = null;

            var allFree = GetAllFree(span.GetDate());

            foreach (TimeSlot free in allFree)
            {
                if (!span.OverlapsWith(free)) { continue; }

                if (free.GetOverlapDuration(span) < duration) { continue; }

                firstFree = span.GetOverlap(free);
                firstFree.CutTo(duration);

                break;
            }
            return firstFree;
        }

        public TimeSlot FindNextFree(TimeSlot restOfTheDay, TimeSlot workHours, int duration)
        {
            var nextFree = GetFirstFree(restOfTheDay, duration);

            while (nextFree is null)
            {
                workHours.AddDays(1);
                nextFree = GetFirstFree(workHours, duration);
            }

            return nextFree;
        }

        public void FreeReserved(TimeSlot timeSlot)
        {
            FreeTimeSlots[timeSlot.GetDate()].Add(timeSlot);
        }

        private void AdjustFree(TimeSlot before, TimeSlot after)
        {
            if (!before.IsShorterThan(15) && !after.IsShorterThan(15)) { AddFree(after); }
            else if (before.IsShorterThan(15) && !after.IsShorterThan(15)) { RemoveFree(before); AddFree(after); }
            else if (before.IsShorterThan(15) && after.IsShorterThan(15)) { RemoveFree(before); }
        }
        public void Schedule(Appointment appointment)
        {
            ReserveFree(appointment.TimeSlot);
            Appointments[appointment.TimeSlot.GetDate()].Add(appointment.Id);
        }

        public void Unschedule(Appointment appointment)
        {
            appointment.IsCanceled = true;
            FreeTimeSlots[appointment.TimeSlot.GetDate()].Add(appointment.TimeSlot);
        }

        public void Remove(Appointment appointment)
        {
            Appointments[appointment.TimeSlot.GetDate()].Remove(appointment.Id);
        }

        public void Reschedule(Appointment appointment, TimeSlot newTimeSlot)
        {
            Remove(appointment);
            FreeReserved(appointment.TimeSlot);
            appointment.TimeSlot = newTimeSlot;
            Schedule(appointment);
        }

        public bool IsFree(TimeSlot timeSlot)
        {
            foreach (TimeSlot free in GetAllFree(timeSlot.GetDate()))
            {
                if (free.Contains(timeSlot)) { return true; }
            }
            return false;
        }

        public bool IsFreeForVacation(TimeSlot timeSlot)
        {
            foreach (DateOnly day in timeSlot.GetByDays())
            {
                if (Appointments[day].Count > 0) { return false; }
            }
            return true;
        }
    }
}
