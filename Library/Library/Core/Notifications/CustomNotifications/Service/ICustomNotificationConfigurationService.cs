using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Service.TehnicalService.Interface
{
    public interface ICustomNotificationConfigurationService 
    {
        void Add(CustomNotificationConfiguration customNotificationConfiguration);
        Dictionary<int,  CustomNotificationConfiguration> GetAll();
        CustomNotificationConfiguration Get (int id);
        int GetDuration(int patientId);
        void Update(int patientId, int duration);
    }
}
