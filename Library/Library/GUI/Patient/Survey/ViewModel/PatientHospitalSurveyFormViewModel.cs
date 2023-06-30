using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Notifications;
using Library.Commands.Survey;
using Library.EventArgument;
using Library.Model;
using Library.Service.SurveyService;
using Library.ViewModel.Table;

namespace Library.ViewModel.Form.Survey
{
    public class PatientHospitalSurveyFormViewModel : ViewModelBase
    {
        private int _serviceQualityRating = 1;
        public int ServiceQualityRating
        {
            get { return _serviceQualityRating; }
            set
            {
                _serviceQualityRating = value;
                OnPropertyChanged(nameof(ServiceQualityRating)); 
            }
        }
        private int _hygieneRating = 1;
        public int HygieneRating
        {
            get
            {
                return _hygieneRating;
            }
            set
            {
                _hygieneRating = value;
                OnPropertyChanged(nameof(HygieneRating));
            }
        }
        private int _generalRating = 1;
        public int GeneralRating
        {
            get
            {
                return _generalRating;
            }
            set
            {
                _generalRating = value;
                OnPropertyChanged(nameof(GeneralRating));
            }
        }
        private int _recommendationRating = 1;
        public int RecommendationRating
        {
            get
            {
                return _recommendationRating;
            }
            set
            {
                _recommendationRating = value;
                OnPropertyChanged(nameof(RecommendationRating));
            }
        }
        private string _generalComment;
        public string GeneralComment
        {
            get
            {
                return _generalComment;
            }
            set
            {
                _generalComment = value;
                OnPropertyChanged(nameof(GeneralComment));
            }
        }
        public CommandBase AddSurveyCommand { get; }
        public ICommand CloseCommand { get; }
        public Patient _patient;
        public IHospitalSurveyService _hospitalSurveyService;
        public PatientHospitalSurveyFormViewModel(Window window, Patient patient, IHospitalSurveyService hospitalSurveyService)
        {
            _patient = patient;
            _hospitalSurveyService = hospitalSurveyService;
            LoadWindow();
            AddSurveyCommand = new AddHospitalSurveyCommand(this, _patient, hospitalSurveyService);
            AddSurveyCommand.ExcecutionCompleted += AddSurveyCompleted;
            CloseCommand = new CloseCommand(window);
        }

        private void LoadWindow()
        {
            var hospitalSurvey = _hospitalSurveyService.GetByPatientId(_patient.Id);
            if (hospitalSurvey is not null) 
            {
                ServiceQualityRating = hospitalSurvey.ServiceQualityRating;
                HygieneRating = hospitalSurvey.HygieneRating;
                GeneralRating = hospitalSurvey.GeneralRating;
                RecommendationRating = hospitalSurvey.RecommendationRating;
                GeneralComment = hospitalSurvey.Comment;
            }
        }

        public void AddSurveyCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseCommand.Execute(this);
            }
        }
    }
}
