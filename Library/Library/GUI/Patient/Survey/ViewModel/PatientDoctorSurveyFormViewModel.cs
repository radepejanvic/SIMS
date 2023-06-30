using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Survey;
using Library.EventArgument;
using Library.Model;
using Library.Service.SurveyService;

namespace Library.ViewModel.Form.Survey
{
    public class PatientDoctorSurveyFormViewModel : ViewModelBase
    {
		private int _serviceQualityRating = 1;
		public int ServiceQualityRating
        {
			get
			{
				return _serviceQualityRating;
			}
			set
			{
				_serviceQualityRating = value;
				OnPropertyChanged(nameof(ServiceQualityRating));
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
		private IDoctorSurveyService _doctorSurveyService;

        public PatientDoctorSurveyFormViewModel(Window window, AppointmentViewModel appointment, IDoctorSurveyService doctorSurveyService) 
        {
			_doctorSurveyService = doctorSurveyService;
			LoadWindow(appointment);
            AddSurveyCommand = new AddDoctorSurveyCommand(this, appointment.Appointment, doctorSurveyService);
            AddSurveyCommand.ExcecutionCompleted += AddSurveyCompleted;
            CloseCommand = new CloseCommand(window);
        }

		private void LoadWindow(AppointmentViewModel appointment)
		{
			var doctorSurvey = _doctorSurveyService.GetByAppointment(appointment.Appointment.Id);
			if (doctorSurvey is not null)
			{
				ServiceQualityRating = doctorSurvey.ServiceQualityRating;
				RecommendationRating = doctorSurvey.RecommendationRating;
				GeneralComment = doctorSurvey.Comment;
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
