using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.SurveyService;
using Library.ViewModel.Form;
using Library.ViewModel;
using Library.ViewModel.Structure;
using System.ComponentModel;
using Library.ViewModel.Form.Survey;
using Library.Service.PersonService.Interface;

namespace Library.Commands.Survey
{
    public class ShowSurveyCommand : CommandBase
    {
        private IHospitalSurveyService _surveyService;
        private HospitalSurveyViewModel _hospitalSurveyViewModel;
        private IPatientService _patientService;

        public ShowSurveyCommand(IHospitalSurveyService surveyService, HospitalSurveyViewModel hospitalSurveyViewModel, IPatientService patientService)
        {
            _surveyService = surveyService;
            _hospitalSurveyViewModel = hospitalSurveyViewModel;
            _patientService = patientService;
            _hospitalSurveyViewModel.PropertyChanged += OnViewModelPropertyChanged;
 

        }
        public override bool CanExecute(object? parameter)
        {
            return _hospitalSurveyViewModel.Selected is not null;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                var survey = _hospitalSurveyViewModel.Selected;
                OnExecutionCompleted(true, "Komentar je " + survey.Comment + "\n" +
                                        "ServiceQualityRating je " + survey.ServiceQualityRating + "\n"+
                                        "HygieneRating je " + survey.HygieneRating + "\n"+
                                        "GeneralRating je " + survey.GeneralRating + "\n"+
                                        "RecommendationRating je " + survey.RecommendationRating + "\n"+
                                        "Pacient je " + _patientService.Get(survey.PatientId).FirstName);

            }
            catch
            {
                OnExecutionCompleted(false, "GRESKA");
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_hospitalSurveyViewModel.Selected))
            {
                OnCanExecutedChanged();
            };
        }

    }
}
