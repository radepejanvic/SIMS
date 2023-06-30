using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.ViewModel;
using Library.Model;
using System.Windows.Input;
using Library.Commands;
using Library.Service.TehnicalService.Interface;
using Library.Commands.Notifications;
using Library.EventArgument;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.ViewModel.Form
{
    public class PatientAddNotificationFormViewModel : ViewModelBase
    {
        private string _time;
        public string Time
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
        private DateTime _from;
        public DateTime From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }
        private DateTime _to;
        public DateTime To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private Patient _patient;
        public Patient Patient => _patient;
        public CommandBase AddNotificationCommand { get; }
        public ICommand CloseCommand { get; }
        private PatientNotificationTableViewModel _patientNotificationTableViewModel;
        public PatientAddNotificationFormViewModel(Window window, Patient patient, PatientNotificationTableViewModel patientNotificationTableViewModel, ICustomNotificationService customNotificationService) 
        {
            From = DateTime.Now;
            To = DateTime.Now;

            _patient = patient;
            _patientNotificationTableViewModel = patientNotificationTableViewModel;
            AddNotificationCommand = new AddNotificationCommand(this, customNotificationService);
            CloseCommand = new CloseCommand(window);
            AddNotificationCommand.ExcecutionCompleted += AddNotificationExecutionCompleted;
        }

        private void AddNotificationExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull) { 
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                _patientNotificationTableViewModel.LoadNotifications();
                CloseCommand.Execute(this);
            }
        }
    }
}
