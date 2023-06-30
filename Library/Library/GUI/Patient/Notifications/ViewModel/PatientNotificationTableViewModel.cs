using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Notifications;
using Library.EventArgument;
using Library.Model;
using Library.Service.TehnicalService;
using Library.Service.TehnicalService.Interface;
using Library.View.Form;
using Library.View.Form.Notifications;
using Library.ViewModel.Form;

namespace Library.ViewModel.Table
{
    public class PatientNotificationTableViewModel : ViewModelBase
    {
        private ObservableCollection<CustomNotification> _notifications;
        public ObservableCollection<CustomNotification> Notifications
        {
            get
            {
                return _notifications;
            }
            set
            {
                _notifications = value;
                OnPropertyChanged(nameof(Notifications));
            }
        }
        public ICommand OpenUpdateNotificationConfigurationViewCommand { get; }
        public ICommand OpenAddNotificationCommand { get; }
        public CommandBase UpdateStatusCommand { get; }
        public ICommand CloseCommand { get; }
        private CustomNotification _selectedNotification;
        public CustomNotification SelectedNotification
        {
            get
            {
                return _selectedNotification;
            }
            set
            {
                _selectedNotification = value;
                OnPropertyChanged(nameof(SelectedNotification));
            }
        }
        private Patient _patient;
        private ICustomNotificationService _customNotificationService;
        private ICustomNotificationConfigurationService _customNotificationConfigurationService;
        public PatientNotificationTableViewModel(Window window, Patient patient, ICustomNotificationService customNotificationService, ICustomNotificationConfigurationService customNotificationConfigurationService)
        {
            _patient = patient;
            _customNotificationService = customNotificationService;
            _customNotificationConfigurationService = customNotificationConfigurationService;
            LoadNotifications();
            OpenUpdateNotificationConfigurationViewCommand = new RelayCommand(OpenUpdateNotificationConfigurationView);
            OpenAddNotificationCommand = new RelayCommand(OpenAddNotification);
            UpdateStatusCommand = new UpdateNotificationStatusCommand(this, customNotificationService);
            UpdateStatusCommand.ExcecutionCompleted += UpdateNotificationStatusExecutionCompleted;
            CloseCommand = new CloseCommand(window);
        }
        public void LoadNotifications()
        {
            Notifications = new ObservableCollection<CustomNotification>(_customNotificationService.GetAllByPatient(_patient.Id).Values
                                    .Where(notification => notification.Date > DateTime.Now));
            CollectionViewSource.GetDefaultView(Notifications).Refresh();
        }
        private void OpenUpdateNotificationConfigurationView()
        {
            var updateNotificationConfigView = new PatientUpdateNotificationConfigurationFormView();
            updateNotificationConfigView.DataContext = new PatientUpdateNotificationConfigurationFormViewModel(updateNotificationConfigView, _patient, _customNotificationConfigurationService);
            updateNotificationConfigView.ShowDialog();
        }
        private void OpenAddNotification()
        {
            var addNotificationview = new PatientAddNotificationFormView();
            addNotificationview.DataContext = new PatientAddNotificationFormViewModel(addNotificationview, _patient, this, _customNotificationService);
            addNotificationview.ShowDialog();
        }
        private void UpdateNotificationStatusExecutionCompleted(object? sender, ExecutionCompletedEventArgs e)
        {
            if (e.IsSuccessfull)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadNotifications();
            }
        }
    }
}
