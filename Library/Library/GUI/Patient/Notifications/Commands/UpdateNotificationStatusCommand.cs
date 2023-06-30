using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.TehnicalService;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands.Notifications
{
    public class UpdateNotificationStatusCommand : CommandBase
    {
        private PatientNotificationTableViewModel _patientNotificationTableViewModel;
        private ICustomNotificationService _customNotificationService;
        public UpdateNotificationStatusCommand(PatientNotificationTableViewModel patientNotificationTableViewModel, ICustomNotificationService customNotificationService) 
        {
            _customNotificationService = customNotificationService;
            _patientNotificationTableViewModel = patientNotificationTableViewModel;
            _patientNotificationTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return _patientNotificationTableViewModel.SelectedNotification is not null;
        }
        public override void Execute(object? parameter)
        {
            _customNotificationService.UpdateStatus(_patientNotificationTableViewModel.SelectedNotification.Id);
            OnExecutionCompleted(true, "Promena statusa je uspesno izvrsena");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientNotificationTableViewModel.SelectedNotification))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
