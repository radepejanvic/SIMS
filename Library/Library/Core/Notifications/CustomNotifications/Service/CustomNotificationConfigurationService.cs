using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.Service.TehnicalService
{
    public class CustomNotificationConfigurationService : ICustomNotificationConfigurationService
    {
        private readonly ICustomNotificationConfigurationRepository _crud;
        public CustomNotificationConfigurationService(ICustomNotificationConfigurationRepository crud)
        {
            _crud = crud;
        }

        public void Add(CustomNotificationConfiguration customNotificationConfiguration)
        {
            _crud.Add(customNotificationConfiguration);
        }

        public CustomNotificationConfiguration Get(int id)
        {
            return _crud.Get(id);
        }

        public Dictionary<int, CustomNotificationConfiguration> GetAll()
        {
            return _crud.GetAll();
        }

        public int GetDuration(int patientId)
        {
            return _crud.GetAll().Values.Where(configuration => configuration.PatientId == patientId)
                    .Select(configuration => configuration.Duration)
                    .FirstOrDefault();
        }

        public void Update(int patientId, int duration)
        {
            var configurationToUpdate = _crud.GetConfig(patientId);

            if (!configurationToUpdate.Equals(default(KeyValuePair<int, CustomNotificationConfiguration>)))
            {
                configurationToUpdate.Value.Duration = duration;
                _crud.Update(configurationToUpdate.Value);
            }
        }
    }
}
