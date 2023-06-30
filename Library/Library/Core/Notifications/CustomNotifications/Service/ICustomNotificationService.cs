using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Library.Model;

namespace Library.Service.TehnicalService.Interface
{
    public interface ICustomNotificationService 
    {
        CustomNotification Get (int id);
        Dictionary<int, CustomNotification> GetAll();
        Dictionary<int, CustomNotification> GetAllByPatient(int patientId);
        void Add(int patientId, DateOnly from, DateOnly to, TimeOnly time, string message);
        void Add(int patientId, DateOnly from, DateOnly to, int repetitionsPerDay, string message);
        List<CustomNotification> CheckNotification(int patientId);
        void UpdateStatus(int id);
        void ShowMessage(int patientId);
        void TimerElapsed(object sender, ElapsedEventArgs e, int patientId);
        
    }
}
