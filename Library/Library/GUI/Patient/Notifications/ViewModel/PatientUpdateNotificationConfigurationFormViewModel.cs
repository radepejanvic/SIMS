using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Commands;
using Library.Commands.Notifications;
using Library.EventArgument;
using Library.Model;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Table;

namespace Library.ViewModel.Form
{
    public class PatientUpdateNotificationConfigurationFormViewModel : ViewModelBase
    {
		private int _time;
		public int Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
				OnPropertyChanged(nameof(Time));
			}
		}
		public Patient _patient;
		public CommandBase UpdateNotificationConfigurationCommand { get; }
		public CloseCommand CloseCommand { get; }
        public PatientUpdateNotificationConfigurationFormViewModel(Window window, Patient patient, ICustomNotificationConfigurationService customNotificationConfigurationService)
        {
			_patient = patient;
            UpdateNotificationConfigurationCommand = new UpdateNotificationConfigurationCommand(this, patient, customNotificationConfigurationService);
            UpdateNotificationConfigurationCommand.ExcecutionCompleted += UpdateNotificationConfigurationExecutionCompleted;
            CloseCommand = new CloseCommand(window);
			Time = customNotificationConfigurationService.GetDuration(patient.Id);
        }

        private void UpdateNotificationConfigurationExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
