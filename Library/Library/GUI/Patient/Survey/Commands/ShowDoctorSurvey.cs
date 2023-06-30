using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.ViewModel.Structure;
using Library.ViewModel.Table;

namespace Library.Commands.Survey
{
    public class ShowDoctorSurvey : CommandBase
    {
        private DoctorSurveyTableViewModel _doctorSurveyTableViewModel;
        private IDoctorService _doctorService;
        private IAppointmentService _appointmentService;

        public ShowDoctorSurvey(DoctorSurveyTableViewModel doctorSurveyTableViewModel, IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorSurveyTableViewModel = doctorSurveyTableViewModel;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _doctorSurveyTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _doctorSurveyTableViewModel.SelectedDoctorSurvey is not null;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                var survey = _doctorSurveyTableViewModel.SelectedDoctorSurvey;
                var doctor = _doctorService.Get(_appointmentService.Get(survey.AppointmentId).DoctorId);
                OnExecutionCompleted(true, "Komentar je " + survey.Comment + "\n" +
                                        "ServiceQualityRating je " + survey.ServiceQualityRating + "\n" +
                                        "RecommendationRating je " + survey.RecommendationRating + "\n" +
                                        "Doctor je " + doctor.FirstName+" "+ doctor.LastName);

            }
            catch
            {
                OnExecutionCompleted(false, "GRESKA");
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_doctorSurveyTableViewModel.SelectedDoctorSurvey))
            {
               OnCanExecutedChanged();
            };     
        }

   
    }
}
