using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.SurveyService;
using Library.ViewModel.Form;
using Library.ViewModel.Form.Survey;

namespace Library.Commands.Survey
{
    public class AddHospitalSurveyCommand : CommandBase
    {
        private PatientHospitalSurveyFormViewModel _patientHospitalSurveyFormViewModel;
        private IHospitalSurveyService _hospitalSurveyService;
        private Patient _patient;
        public AddHospitalSurveyCommand(PatientHospitalSurveyFormViewModel patientHospitalSurveyFormViewModel,Patient patient, IHospitalSurveyService hospitalSurveyService)
        {
            _patient = patient;
            _patientHospitalSurveyFormViewModel = patientHospitalSurveyFormViewModel;
            _hospitalSurveyService = hospitalSurveyService;
            _patientHospitalSurveyFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_patientHospitalSurveyFormViewModel.GeneralComment);
        }

        public override void Execute(object? parameter)
        {
            _hospitalSurveyService.Add(_patientHospitalSurveyFormViewModel.ServiceQualityRating, _patientHospitalSurveyFormViewModel.HygieneRating, _patientHospitalSurveyFormViewModel.GeneralRating, _patientHospitalSurveyFormViewModel.RecommendationRating, _patientHospitalSurveyFormViewModel.GeneralComment, _patient.Id);
            OnExecutionCompleted(true, "Anketa je uspesno sacuvana.");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientHospitalSurveyFormViewModel.GeneralComment))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
