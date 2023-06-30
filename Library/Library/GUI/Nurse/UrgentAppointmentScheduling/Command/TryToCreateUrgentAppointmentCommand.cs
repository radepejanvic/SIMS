using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;

using Library.Model.Enum;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.View.Table;
using Library.ViewModel;
using Library.ViewModel.Form;

namespace Library.Commands
{
    public class TryToCreateUrgentAppointmentCommand : CommandBase
    {
        private UrgentAppointmentFormViewModel _urgentAppointmentFormViewModel;
        private IPatientService _patientService;
        private ISchedulingService _schedulingService;
        private IAppointmentNotificationService _notificationService;
        private IDoctorService _doctorService;
        private IDoctorScheduleService _doctorScheduleService;
        public TryToCreateUrgentAppointmentCommand(UrgentAppointmentFormViewModel urgentAppointmentFormViewModel, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
            _urgentAppointmentFormViewModel = urgentAppointmentFormViewModel;
            _patientService = patientService;
            _schedulingService = schedulingService;
            _doctorService = doctorService;
            _doctorScheduleService = doctorScheduleService;
            _notificationService = notificationService;
            _urgentAppointmentFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_urgentAppointmentFormViewModel.IsOperation && _urgentAppointmentFormViewModel.Duration >= 15 && _urgentAppointmentFormViewModel.SelectedSpecialization is not null) 
                || (_urgentAppointmentFormViewModel.SelectedSpecialization is not null);
        }

        public override void Execute(object? parameter)
        {
            var span = new TimeSlot(2);
            var freePair = _schedulingService.GetFirstFreeTimeSlotAndDoctor((Specialization)_urgentAppointmentFormViewModel.SelectedSpecialization, span , _urgentAppointmentFormViewModel.GetDuration());
            var patient = _patientService.Get(_urgentAppointmentFormViewModel.SelectedPatient.Id);

            // TODO: Move this condition to CanExecute function somehow.
            if (freePair is not null && _schedulingService.IsAvaliable(patient, freePair.Item1))
            {
                try
                {
                    _schedulingService.Schedule(new Appointment(freePair.Item2.Id, patient.Id, 0, freePair.Item1, _urgentAppointmentFormViewModel.IsOperation));
                    MessageBox.Show("Uspešno ste zakazali urgentni pregled", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška prilikom zakazivanja urgentnog pregleda.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                var popup = new DelayableAppointmentTableView(_urgentAppointmentFormViewModel, _patientService, _doctorService, _doctorScheduleService, _schedulingService, _notificationService);
                popup.ShowDialog();
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_urgentAppointmentFormViewModel.IsOperation)) ||
                (e.PropertyName == nameof(_urgentAppointmentFormViewModel.Duration)) ||
                (e.PropertyName == nameof(_urgentAppointmentFormViewModel.SelectedSpecialization)))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
