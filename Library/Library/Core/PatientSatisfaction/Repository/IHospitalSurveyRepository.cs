using System.Collections.Generic;
using Library.Model;

namespace Library.Repository
{
    public interface IHospitalSurveyRepository
    {
        void Add(HospitalSurvey survey);
        HospitalSurvey Get(int id);
        Dictionary<int, HospitalSurvey> GetAll();
        HospitalSurvey? GetByPatient(int patientId);
        void Remove(int id);
        void Update(HospitalSurvey survey);
    }
}