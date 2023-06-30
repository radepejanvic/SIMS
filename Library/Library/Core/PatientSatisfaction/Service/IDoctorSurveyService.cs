using System.Collections.Generic;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;

namespace Library.Service.SurveyService
{
    public interface IDoctorSurveyService
    {
        void Add(int serviceQualityRating, int recommendationRating, int appointmentId, string comment);
        Dictionary<int, DoctorSurvey> GetAll();
        List<SurveryElement> GetAllbyId(int id, IAppointmentService _appointmentService);
        DoctorSurvey? GetByAppointment(int appointmentId);
        List<string>? GetComments();
    }
}