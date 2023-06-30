using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;

using Library.Model.Enum;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.View.Table;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class FindAppointmentCommand : CommandBase
    {
        private ViewModel.Form.PatientMedicalRecordTableViewModel _patientAdvancedAppointmentSchedulingViewModel;
        private IDoctorScheduleService _doctorScheduleService;
        private ISchedulingService _schedulingService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private TimeOnly _from;
        private TimeOnly _to;
        public FindAppointmentCommand(ViewModel.Form.PatientMedicalRecordTableViewModel patientAdvancedAppointmentSchedulingViewModel, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IPatientService patientService, IDoctorService doctorService) 
        {
            _doctorService = doctorService;
            _schedulingService = schedulingService;
            _patientService = patientService;
            _doctorScheduleService = doctorScheduleService;
            _patientAdvancedAppointmentSchedulingViewModel = patientAdvancedAppointmentSchedulingViewModel;
            _patientAdvancedAppointmentSchedulingViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override bool CanExecute(object? parameter)
        {
            //MessageBox.Show((_patientAdvancedAppointmentSchedulingViewModel.SelectedDoctor is not null).ToString());
            return ((_patientAdvancedAppointmentSchedulingViewModel.SelectedDoctor is not null) 
                && !(string.IsNullOrEmpty(_patientAdvancedAppointmentSchedulingViewModel.From)) 
                && !(string.IsNullOrEmpty(_patientAdvancedAppointmentSchedulingViewModel.To)) 
                && ((_patientAdvancedAppointmentSchedulingViewModel.IsDoctorSelected)) || (_patientAdvancedAppointmentSchedulingViewModel.IsTimeSelected))
                && !(_patientAdvancedAppointmentSchedulingViewModel.Date == null);
        }   
        public override void Execute(object? parameter)
        {
            if(IsTimeOk() && IsDateOk()) 
            {
                List<TimeSlot> closestTimeSlots;
                var selectedDoctor = _patientAdvancedAppointmentSchedulingViewModel.SelectedDoctor;
                var doctorId = selectedDoctor.Doctor.Id;
                var latestTime = _patientAdvancedAppointmentSchedulingViewModel.Date;
                var span = CreateSpan(Convert(_patientAdvancedAppointmentSchedulingViewModel.From), Convert(_patientAdvancedAppointmentSchedulingViewModel.To));
                var doctorSchedule = _doctorScheduleService.Get(doctorId);

                if (_patientAdvancedAppointmentSchedulingViewModel.IsDoctorSelected)
                {
                    closestTimeSlots = doctorSchedule.GetClosestTimeSlots(span, latestTime);
                    ScheduleAppointmentInOutOfSpan(closestTimeSlots, selectedDoctor, doctorSchedule);
                }
                else
                {
                    closestTimeSlots = _schedulingService.GetClosestTimeSlot(selectedDoctor.Doctor, span, latestTime);
                    ScheduleAppointmentInOutOfSpan(closestTimeSlots, selectedDoctor, doctorSchedule);
                }
            }
            else
            {
                MessageBox.Show("Pocetno vreme ne moze biti jednako ili vece od krajnjeg. Datum mora biti u buducnosti.");
            }
        }
        public void ScheduleAppointment(TimeSlot timeSlot, Doctor doctor, DoctorSchedule doctorSchedule)
        {
            MessageBoxResult result = MessageBox.Show("Ovo je prvi slobodan termin : " + timeSlot.From + ". Da li zelite da zakazete?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var patient = _patientAdvancedAppointmentSchedulingViewModel.Patient;
                Appointment newAppointment = new Appointment(doctor.Id, patient.Id, 0, timeSlot, false);
                _schedulingService.Schedule(newAppointment);

                MessageBox.Show("Uspesno ste zakazali pregled.");
            }

        }
        public void ScheduleAppointmentInOutOfSpan(List<TimeSlot> closestTimeSlots, DoctorViewModel selectedDoctor, DoctorSchedule doctorSchedule)
        {
            if (closestTimeSlots.Count == 1)
            {
                ScheduleAppointment(closestTimeSlots[0], selectedDoctor.Doctor, doctorSchedule);
            }
            else
            {
                var scheduleAppointments = new PatientChoseRecommendedView();
                scheduleAppointments.DataContext = new PatientChoseRecommendedViewModel(_patientAdvancedAppointmentSchedulingViewModel.Patient, scheduleAppointments, closestTimeSlots, selectedDoctor.Doctor, _doctorScheduleService, _patientService, _doctorService);
                scheduleAppointments.ShowDialog();
            }
        }
        
        public TimeSlot CreateSpan(TimeOnly from, TimeOnly to)
        {
            TimeSlot span = new TimeSlot();
            DateTime now = DateTime.Now;
            if (to.Hour < now.Hour || from.Hour < now.Hour)
            {
                now = now.AddDays(1);
            }
            span.From = new DateTime(now.Year, now.Month, now.Day, from.Hour, from.Minute, from.Second);
            span.To = new DateTime(now.Year, now.Month, now.Day, to.Hour, to.Minute, to.Second);

            return span;
        }
        public bool IsTimeOk()
        {
            var from = Convert(_patientAdvancedAppointmentSchedulingViewModel.From);
            var to = Convert(_patientAdvancedAppointmentSchedulingViewModel.To);
            if (from >= to)
            {
                return false;
            }
            return true;
        }
        public bool IsDateOk()
        {
            return _patientAdvancedAppointmentSchedulingViewModel.Date.Date > DateTime.Now.Date;
        }
        public TimeOnly Convert(string time)
        {
            return  TimeOnly.Parse(time);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientAdvancedAppointmentSchedulingViewModel.SelectedDoctor))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
