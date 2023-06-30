using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Form;

namespace Library.Commands.Notifications
{
    public class UpdateNotificationConfigurationCommand : CommandBase
    {
        PatientUpdateNotificationConfigurationFormViewModel _patientUpdateNotificationConfigurationFormViewModel;
        private Patient _patient;
        public ICustomNotificationConfigurationService _customNotificationConfigurationService;
        public UpdateNotificationConfigurationCommand(PatientUpdateNotificationConfigurationFormViewModel patientUpdateNotificationConfigurationFormViewModel, Patient patient, ICustomNotificationConfigurationService customNotificationConfigurationService) 
        {
            _patientUpdateNotificationConfigurationFormViewModel = patientUpdateNotificationConfigurationFormViewModel;
            _patient = patient;
            _customNotificationConfigurationService = customNotificationConfigurationService;
            _patientUpdateNotificationConfigurationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return (_patientUpdateNotificationConfigurationFormViewModel.Time > 0) ;
        }
        public override void Execute(object? parameter)
        {
            _customNotificationConfigurationService.Update(_patient.Id, _patientUpdateNotificationConfigurationFormViewModel.Time);
            OnExecutionCompleted(true, "Uspesno ste izmenili vasu konfiguraciju");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientUpdateNotificationConfigurationFormViewModel.Time))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
