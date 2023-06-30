using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands.Notifications
{
    public class AddNotificationCommand : CommandBase
    {
        private PatientAddNotificationFormViewModel _patientAddNotificationFormViewModel;
        private ICustomNotificationService _customNotificationService;
        public AddNotificationCommand(PatientAddNotificationFormViewModel patientAddNotificationFormViewModel,ICustomNotificationService customNotificationService) 
        {
            _patientAddNotificationFormViewModel = patientAddNotificationFormViewModel;
            _customNotificationService = customNotificationService;
            _patientAddNotificationFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return ((_patientAddNotificationFormViewModel.Message is not null) &&
                    (_patientAddNotificationFormViewModel.Time is not null) &&
                    !(_patientAddNotificationFormViewModel.From == null) &&
                    !(_patientAddNotificationFormViewModel.To == null) &&
                    IsTimeOk());
        }
        public bool IsTimeOk()
        {
            var timeOnly = Convert(_patientAddNotificationFormViewModel.Time);
            var checkTime = _patientAddNotificationFormViewModel.From.Add(timeOnly.ToTimeSpan());
            if (checkTime > DateTime.Now && _patientAddNotificationFormViewModel.From <= _patientAddNotificationFormViewModel.To) return true;
            return false;
        }
        public TimeOnly Convert(string time)
        {
            return TimeOnly.Parse(time);
        }
        public override void Execute(object? parameter)
        {
            DateOnly from = new DateOnly(_patientAddNotificationFormViewModel.From.Year, _patientAddNotificationFormViewModel.From.Month, _patientAddNotificationFormViewModel.From.Day);
            DateOnly to = new DateOnly(_patientAddNotificationFormViewModel.To.Year, _patientAddNotificationFormViewModel.To.Month, _patientAddNotificationFormViewModel.To.Day);
            var time = Convert(_patientAddNotificationFormViewModel.Time);
            _customNotificationService.Add(_patientAddNotificationFormViewModel.Patient.Id, from, to, time, _patientAddNotificationFormViewModel.Message);
            OnExecutionCompleted(true, "Notifikacija uspesno dodata.");
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientAddNotificationFormViewModel.Message) 
                || e.PropertyName == nameof(_patientAddNotificationFormViewModel.Time)
                || e.PropertyName == nameof(_patientAddNotificationFormViewModel.From)
                || e.PropertyName == nameof(_patientAddNotificationFormViewModel.To))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
