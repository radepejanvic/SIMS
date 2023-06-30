using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class HospitalSurveyRepository : IHospitalSurveyRepository
    {
        private ICRUDRepository<HospitalSurvey> _repo;

        public HospitalSurveyRepository(ICRUDRepository<HospitalSurvey> repo)
        {
            _repo = repo;
        }

        public void Add(HospitalSurvey survey)
        {
            _repo.Add(survey);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }
        public void Update(HospitalSurvey survey)
        {
            _repo.Update(survey);
        }

        public HospitalSurvey Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, HospitalSurvey> GetAll()
        {
            return _repo.GetAll();
        }

        public HospitalSurvey? GetByPatient(int patientId)
        {
            return _repo.GetAll().Values
                .FirstOrDefault(survey => survey.PatientId == patientId);
        }


    }
}
