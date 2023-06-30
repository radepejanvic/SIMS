using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.Commands;
using Library.Model;
using Library.Repository;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;

namespace Library.Service.SurveyService
{
    public class DoctorSurveyService : IDoctorSurveyService
    {
        private IDoctorSurveyRepository _repo;

        public DoctorSurveyService(IDoctorSurveyRepository repo)
        {
            _repo = repo;
        }

        private void Add(DoctorSurvey doctorSurvey)
        {
            _repo.Add(doctorSurvey);
        }

        public void Add(int serviceQualityRating, int recommendationRating, int appointmentId, string comment)
        {
            var survey = _repo.GetByAppointment(appointmentId);
            if (survey == null)
            {
                Add(new DoctorSurvey(serviceQualityRating, recommendationRating, appointmentId, comment));
            }
            else
            {
                survey.ServiceQualityRating = serviceQualityRating;
                survey.RecommendationRating = recommendationRating;
                survey.Comment = comment;
                Update(survey);
            }
        }
        private void Update(DoctorSurvey survey)
        {
            _repo.Update(survey);
        }

        public DoctorSurvey? GetByAppointment(int appointmentId)
        {
            return _repo.GetByAppointment(appointmentId);
        }

        public Dictionary<int, DoctorSurvey> GetAll()
        {
            return _repo.GetAll();
        }

        public List<SurveryElement> GetAllbyId(int id, IAppointmentService _appointmentService)
        {
            var doctorsSurveys = GetAll().Values.Where(o => _appointmentService.Get(o.AppointmentId).DoctorId == id).ToList();

            PropertyInfo[] properties = typeof(DoctorSurvey).GetProperties();

            var surveryElements = properties.Select(o => CreateSurveryElement(o, doctorsSurveys)).ToList();

            surveryElements.Remove(surveryElements.FirstOrDefault(x => x.Name == "Id"));

            return surveryElements;

        }
        private SurveryElement CreateSurveryElement(PropertyInfo property, List<DoctorSurvey> doctorsSurveys)
        {
            return new SurveryElement
            {
                Name = property.Name,
                ValueOfOne = doctorsSurveys.Count(item => (int)property.GetValue(item) == 1),
                ValueOfTwo = doctorsSurveys.Count(item => (int)property.GetValue(item) == 2),
                ValueOfThree = doctorsSurveys.Count(item => (int)property.GetValue(item) == 3),
                ValueOfFour = doctorsSurveys.Count(item => (int)property.GetValue(item) == 4),
                ValueOfFive = doctorsSurveys.Count(item => (int)property.GetValue(item) == 5)
            };
        }

        public List<string> GetComments()
        {
            return GetAll().Values.Select(o => o.Comment).ToList();

        }
    }
}
