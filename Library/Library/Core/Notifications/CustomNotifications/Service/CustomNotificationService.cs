using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.Service.TehnicalService
{
    public class CustomNotificationService : ICustomNotificationService
    {
        private readonly ICustomNotificationRepository _crud;
        private ICustomNotificationConfigurationService _customNotificationConfigurationService;
        public CustomNotificationService(ICustomNotificationRepository crud, ICustomNotificationConfigurationService customNotificationConfigurationService) 
        {
            _customNotificationConfigurationService = customNotificationConfigurationService;
            _crud = crud;
        }

        private void Add(CustomNotification notification)
        {
            _crud.Add(notification);
        }
        public void Add(int patientId, DateOnly from, DateOnly to, TimeOnly time, string message)
        {
            while (from <= to)
            {
                var dateTime = new DateTime(from.Year, from.Month, from.Day, time.Hour, time.Minute, 0);
                var notification = new CustomNotification(patientId, dateTime, message);
                Add(notification);
                from = from.AddDays(1);
            }
        }
        public void Add(int patientId, DateOnly from, DateOnly to,  int repetitionsPerDay, string message)
        {
           foreach(var time in GetNotificationTime(from, to, repetitionsPerDay))
           {
                var notification = new CustomNotification(patientId, time, message);
                Add(notification);
           }
        }
        private List<DateTime> GetNotificationTime(DateOnly from, DateOnly to, int repetitionsPerDay)
        {
            var times = new List<DateTime>();

            while (from <= to)
            {
                AddTimesForDate(from, repetitionsPerDay, times);
                from = from.AddDays(1);
            }

            return times;
        }

        private void AddTimesForDate(DateOnly date, int repetitionsPerDay, List<DateTime> times)
        {
            int interval = 24 / repetitionsPerDay;
            for (int i = 0; i < repetitionsPerDay; i++)
            {
                var time = new DateTime(date.Year, date.Month, date.Day, i * interval, 0, 0);
                times.Add(time);
            }
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
            return _crud.GetAllByPatient(patientId);
        }
        private void Update(CustomNotification customNotification)
        {
            _crud.Update(customNotification);
        }
        public void UpdateStatus(int id)
        {
            var notification = _crud.Get(id);
            notification.IsDisabled = !notification.IsDisabled;
            Update(notification);
        }

        public List<CustomNotification> CheckNotification(int patientId)
        {
            var notifications = new List<CustomNotification>();
            var duration = _customNotificationConfigurationService.GetDuration(patientId);
            foreach(var notification in GetAllByPatient(patientId).Values)
            {
                if (!notification.IsDisabled && IsTimeForNotification(notification.Date, duration)) 
                { 
                    notifications.Add(notification);
                    notification.IsDisabled = true;
                    Update(notification);
                }   
            }
            return notifications;
        }

        private bool IsTimeForNotification(DateTime dateTime, int duration)
        {
            var now = DateTime.Now;
            if (now.Date == dateTime.Date && IsTimeInInterval(now, dateTime, duration))
            {
                return true;
            }
            return false;
        }

        private bool IsTimeInInterval(DateTime timeToCheck, DateTime time, int duration)
        {
            var timeSlot = new TimeSlot(time.AddMinutes(-duration), time.AddMinutes(duration));
            var timeSlotToCheck = new TimeSlot(timeToCheck, timeToCheck);

            if (timeSlot.Contains(timeSlotToCheck)) return true;
            return false;
        }

        public void ShowMessage(int patientId)
        {
            foreach (var notification in CheckNotification(patientId))
            {
                MessageBox.Show(notification.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void TimerElapsed(object sender, ElapsedEventArgs e, int patientId)
        {
            ShowMessage(patientId);
        }
    }
}
