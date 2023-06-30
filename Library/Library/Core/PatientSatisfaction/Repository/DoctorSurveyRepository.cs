using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DoctorSurveyRepository : IDoctorSurveyRepository
    {
        private ICRUDRepository<DoctorSurvey> _repo;

        public DoctorSurveyRepository(ICRUDRepository<DoctorSurvey> repo)
        {
            _repo = repo;
        }

        public void Add(DoctorSurvey survey)
        {
            _repo.Add(survey);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }
        public void Update(DoctorSurvey survey)
        {
            _repo.Update(survey);
        }

        public DoctorSurvey Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, DoctorSurvey> GetAll()
        {
            return _repo.GetAll();
        }

        public DoctorSurvey? GetByAppointment(int appointmentId)
        {
            return _repo.GetAll().Values
                .FirstOrDefault(survey => survey.AppointmentId == appointmentId);
        }
    }
}
