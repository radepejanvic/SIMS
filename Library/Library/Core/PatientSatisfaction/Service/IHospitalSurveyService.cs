using System.Collections.Generic;
using Library.Model;

namespace Library.Service.SurveyService
{
    public interface IHospitalSurveyService
    {
        void Add(int serviceQualityRating, int hygieneRating, int generalRating, int recommendationRating, string comment, int patientId);
        Dictionary<int, HospitalSurvey> GetAll();
        Dictionary<string, float> GetAvgSurveyElemnts();
        HospitalSurvey GetById(int id);
        HospitalSurvey? GetByPatientId(int patientId);
        List<string> GetComments();
        List<SurveryElement> GetSurveryElements();
        void Update(HospitalSurvey survey);
    }
}