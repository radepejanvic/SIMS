using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class CustomNotificationConfigurationRepository : ICustomNotificationConfigurationRepository
    {
        private readonly ICRUDRepository<CustomNotificationConfiguration> _repo;
        public CustomNotificationConfigurationRepository(ICRUDRepository<CustomNotificationConfiguration> repo)
        {
            _repo = repo;
        }

        public void Add(CustomNotificationConfiguration customNotificationConfiguration)
        {
            _repo.Add(customNotificationConfiguration);
        }

        public CustomNotificationConfiguration Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, CustomNotificationConfiguration> GetAll()
        {
            return _repo.GetAll();
        }
        public void Update(CustomNotificationConfiguration customNotificationConfiguration)
        {
            _repo.Update(customNotificationConfiguration);
        }

        public int GetDuration(int patientId)
        {
            return _repo.GetAll().Values.Where(configuration => configuration.PatientId == patientId)
                    .Select(configuration => configuration.Duration)
                    .FirstOrDefault();
        }

        public KeyValuePair<int, CustomNotificationConfiguration> GetConfig(int patientId)
        {
            return GetAll().FirstOrDefault(configuration => configuration.Value.PatientId == patientId);
        }
    }
}
