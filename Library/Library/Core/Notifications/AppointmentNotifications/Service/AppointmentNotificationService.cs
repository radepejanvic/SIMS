using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.TehnicalService.Interface;
using Library.View.Table;

namespace Library.Service.TehnicalService
{
    public class AppointmentNotificationService : IAppointmentNotificationService
    {
        private readonly IAppointmentNotificationRepository _crud;

        public AppointmentNotificationService(IAppointmentNotificationRepository crud)
        {
            _crud = crud;
        }

        public void Add(AppointmentNotification notification)
        {
            _crud.Add(notification);
        }

        public void Remove(int id)
        {
            _crud.Remove(id);
        }

        public AppointmentNotification Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, AppointmentNotification> GetAll()
        {
            return _crud.GetAll();
        }

        // TODO: Refactor functions down below
        public void NotifyDoctor(int id)
        {
            var notifications = _crud.GetAll(id);
            if (notifications.Any())
            {
                foreach (AppointmentNotification notification in notifications)
                {
                    if (notification.Delayed is null) { ShowNewMessage(notification); continue; }
                    ShowDelayedMessage(notification);
                    Remove(notification.Id);
                }
            }
        }

        public void NotifyPatient(int id)
        {
            var notifications = _crud.GetAll(id);
            if (notifications.Any())
            {
                foreach (AppointmentNotification notification in notifications)
                {
                    if (notification.Delayed is null) { ShowNewMessage(notification); continue; }
                    ShowDelayedMessage(notification);
                    Remove(notification.Id);
                }
            }
        }
        // TODO: Move these two functions to the ViewModel;
        public void ShowDelayedMessage(AppointmentNotification notification)
        {
            MessageBox.Show($"Odložen vam je pregled sa {notification.Initial.From} na {notification.Delayed.From}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowNewMessage(AppointmentNotification notification)
        {
            MessageBox.Show($"Zakazan vam je pregled za {notification.Initial.From}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
