using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.View.Form;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenUrgentAppointmentCommand : CommandBase
    {
        private readonly PatientTableViewModel _patientTableViewModel;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private IDoctorScheduleService _doctorScheduleService;
        private ISchedulingService _schedulingService;
        private IAppointmentNotificationService _notificationService;


        public OpenUrgentAppointmentCommand(PatientTableViewModel patientTableViewModel, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _notificationService = notificationService;
            _patientTableViewModel = patientTableViewModel;
            _patientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _patientTableViewModel.SelectedPatient is not null;
        }
        public override void Execute(object? parameter)
        {
            // Should add argument selectedPatient to the constructor
            var popup = new UrgentAppointmentFormView(_patientTableViewModel.SelectedPatient, _patientService, _doctorService, _doctorScheduleService, _schedulingService, _notificationService);
            popup.ShowDialog();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientTableViewModel.SelectedPatient))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
