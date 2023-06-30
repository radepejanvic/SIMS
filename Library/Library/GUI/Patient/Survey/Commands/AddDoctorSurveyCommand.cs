using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.SurveyService;
using Library.ViewModel.Form.Survey;

namespace Library.Commands.Survey
{
    public class AddDoctorSurveyCommand : CommandBase
    {
        private PatientDoctorSurveyFormViewModel _patientDoctorSurveyFormViewModel;
        private IDoctorSurveyService _doctorSurveyService;
        private Appointment _appointment;
        public AddDoctorSurveyCommand(PatientDoctorSurveyFormViewModel patientDoctorSurveyFormViewModel, Appointment appointment, IDoctorSurveyService doctorSurveyService)
        {
            _patientDoctorSurveyFormViewModel = patientDoctorSurveyFormViewModel;
            _appointment = appointment;
            _doctorSurveyService = doctorSurveyService;
            _patientDoctorSurveyFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_patientDoctorSurveyFormViewModel.GeneralComment);
        }

        public override void Execute(object? parameter)
        {
            _doctorSurveyService.Add(_patientDoctorSurveyFormViewModel.ServiceQualityRating, _patientDoctorSurveyFormViewModel.RecommendationRating, _appointment.Id, _patientDoctorSurveyFormViewModel.GeneralComment);
            OnExecutionCompleted(true, "Anketa je uspesno sacuvana.");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientDoctorSurveyFormViewModel.GeneralComment))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
