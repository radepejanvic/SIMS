using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface ICustomNotificationConfigurationRepository
    {
        void Add(CustomNotificationConfiguration customNotificationConfiguration);
        CustomNotificationConfiguration Get(int id);
        Dictionary<int, CustomNotificationConfiguration> GetAll();
        KeyValuePair<int, CustomNotificationConfiguration> GetConfig(int patientId);
        int GetDuration(int patientId);
        void Update(CustomNotificationConfiguration customNotificationConfiguration);
    }
}