using Autofac.Core.Activators.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Repository;

namespace Library.Service.SurveyService
{
    public class HospitalSurveyService : IHospitalSurveyService
    {
        private IHospitalSurveyRepository _repo;

        public HospitalSurveyService(IHospitalSurveyRepository repo)
        {
            _repo = repo;
        }

        private void Add(HospitalSurvey survey)
        {
            _repo.Add(survey);
        }

        public void Add(int serviceQualityRating, int hygieneRating, int generalRating, int recommendationRating, string comment, int patientId)
        {
            var survey = _repo.GetByPatient(patientId);
            if (survey == null)
            {
                Add(new HospitalSurvey(serviceQualityRating, hygieneRating, generalRating, recommendationRating, comment, patientId));
            }
            else
            {
                survey.ServiceQualityRating = serviceQualityRating;
                survey.HygieneRating = hygieneRating;
                survey.GeneralRating = generalRating;
                survey.RecommendationRating = recommendationRating;
                survey.Comment = comment;
                Update(survey);
            }
        }

        public void Update(HospitalSurvey survey)
        {
            _repo.Update(survey);
        }

        public HospitalSurvey? GetByPatientId(int patientId)
        {
            return _repo.GetByPatient(patientId);
        }

        public Dictionary<int, HospitalSurvey> GetAll()
        {
            return _repo.GetAll();
        }
        public HospitalSurvey GetById(int id)
        {
            return GetAll()[id];
        }

        public List<SurveryElement> GetSurveryElements()
        {
            var hospitalSurveys = GetAll().Values.ToList();

            PropertyInfo[] properties = typeof(HospitalSurvey).GetProperties();

            var surveryElements = properties.Select(o=>CreateSurveryElement(o,hospitalSurveys)).ToList();

            surveryElements.Remove(surveryElements.FirstOrDefault(x => x.Name == "Id"));

            return surveryElements;

        }
        private SurveryElement CreateSurveryElement(PropertyInfo property,List<HospitalSurvey> hospitalSurveys)
        {
            return new SurveryElement
            {
                Name = property.Name,
                ValueOfOne = hospitalSurveys.Count(item => (int)property.GetValue(item) == 1),
                ValueOfTwo = hospitalSurveys.Count(item => (int)property.GetValue(item) == 2),
                ValueOfThree = hospitalSurveys.Count(item => (int)property.GetValue(item) == 3),
                ValueOfFour = hospitalSurveys.Count(item => (int)property.GetValue(item) == 4),
                ValueOfFive = hospitalSurveys.Count(item => (int)property.GetValue(item) == 5)
            };
        }

        public Dictionary<string, float> GetAvgSurveyElemnts()
        {
            var surveryDictionary = new Dictionary<string, float>();
            var surveryElements = GetSurveryElements();
            foreach (var item in surveryElements)
            {
                surveryDictionary.Add(item.Name, item.GetAvg());
            }
            return surveryDictionary;
        }
        public List<string> GetComments()
        {
            return GetAll().Values.Select(o => o.Comment).ToList();
        }
    }
}
