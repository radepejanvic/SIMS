using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    internal class DelayAndCreateAppointmentCommand : CommandBase
    {
        private readonly DelayableAppointmentTableViewModel _delayableAppointmentTableViewModel;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private IDoctorScheduleService _doctorScheduleService;
        private ISchedulingService _schedulingService;
        private IAppointmentNotificationService _notificationService;

        public DelayAndCreateAppointmentCommand(DelayableAppointmentTableViewModel delayableAppointmentTableViewModel, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
            _delayableAppointmentTableViewModel = delayableAppointmentTableViewModel;
            _patientService = patientService;
            _doctorService = doctorService;
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _notificationService = notificationService;
            _delayableAppointmentTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _delayableAppointmentTableViewModel.SelectedAppointment is not null;
        }

        public override void Execute(object? parameter)
        {
            var timeSlots = GetTimeSlots(GetDoctorSchedule());
            try
            {
                _schedulingService.Reschedule(GetDelayedAppointment(timeSlots.Item2));
                var patient = GetUrgentPatient();
                var doctor = GetDoctor();
                _schedulingService.Schedule(new Appointment(doctor.Id, patient.Id, 0,timeSlots.Item1, IsUrgentOperation()));
                _notificationService.Add(new AppointmentNotification(doctor.Id, GetDelayedPatient().Id, timeSlots.Item1, timeSlots.Item2));
                _notificationService.Add(new AppointmentNotification(doctor.Id, patient.Id, timeSlots.Item1, null));

                MessageBox.Show("Uspešno ste odlozili postojeći i zakazali urgentni pregled", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Greška prilikom odlaganja postojećeg i zakazivanja urgentnog pregleda.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_delayableAppointmentTableViewModel.SelectedAppointment))
            {
                OnCanExecutedChanged();
            };
        }

        private Tuple<TimeSlot, TimeSlot> GetTimeSlots(DoctorSchedule doctorSchedule)
        {
            var selectedTimeSlot = _delayableAppointmentTableViewModel.SelectedAppointment.TimeSlot;
            selectedTimeSlot.CutTo(_delayableAppointmentTableViewModel.UrgentAppointmentForm.GetDuration());

            var today = DateTime.Today;
            var delayedTimeSlot = doctorSchedule.FindNextFree(new TimeSlot(today.AddHours(20)), new TimeSlot(today.AddHours(8), today.AddHours(20)), _delayableAppointmentTableViewModel.SelectedAppointment.GetDuration());

            return new Tuple<TimeSlot, TimeSlot>(selectedTimeSlot, delayedTimeSlot);
        }

        private Patient GetUrgentPatient()
        {
            return _patientService.Get(_delayableAppointmentTableViewModel.UrgentAppointmentForm.SelectedPatient.Id);
        }

        private Patient GetDelayedPatient()
        {
            return _patientService.Get(_delayableAppointmentTableViewModel.SelectedAppointment.PatientId);
        }

        private Appointment GetDelayedAppointment(TimeSlot delayedTimeSlot)
        {
            var appointment = _delayableAppointmentTableViewModel.SelectedAppointment.Appointment;
            appointment.TimeSlot = delayedTimeSlot;
            return appointment;
        }

        private Doctor GetDoctor()
        {
            return _doctorService.Get(_delayableAppointmentTableViewModel.SelectedAppointment.DoctorId);
        }

        private DoctorSchedule GetDoctorSchedule()
        {
            return _doctorScheduleService.Get(_delayableAppointmentTableViewModel.SelectedAppointment.DoctorId);
        }

        private bool IsUrgentOperation()
        {
            return _delayableAppointmentTableViewModel.UrgentAppointmentForm.IsOperation;
        }
    }
}
