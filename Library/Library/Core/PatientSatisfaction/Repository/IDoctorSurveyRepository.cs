using System.Collections.Generic;
using Library.Model;

namespace Library.Repository
{
    public interface IDoctorSurveyRepository
    {
        void Add(DoctorSurvey survey);
        DoctorSurvey Get(int id);
        Dictionary<int, DoctorSurvey> GetAll();
        DoctorSurvey? GetByAppointment(int appointmentId);
        void Remove(int id);
        void Update(DoctorSurvey survey);
    }
}