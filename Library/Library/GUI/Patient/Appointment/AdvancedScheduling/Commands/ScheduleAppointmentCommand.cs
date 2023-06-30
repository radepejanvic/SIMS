using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Model;
using Library.Service;
using Library.ViewModel.Form;
using Library.ViewModel.Table;
using System.Windows;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.Commands
{
    public class ScheduleAppointmentCommand : CommandBase
    {
        private PatientChoseRecommendedViewModel _patientChoseRecommendedVM;
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;

        public ScheduleAppointmentCommand(PatientChoseRecommendedViewModel patientChoseRecommendedVM, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            _patientChoseRecommendedVM = patientChoseRecommendedVM;
            _doctorService = doctorService;
            _patientService = patientService;
            _patientChoseRecommendedVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _patientChoseRecommendedVM.SelectedAppointment is not null ;
        }

        public override void Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                MessageBoxResult result = MessageBox.Show("Da li zelite da zakazete?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var doctor = _doctorService.Get(_patientChoseRecommendedVM.SelectedAppointment.DoctorId);
                    var patient = _patientService.Get(_patientChoseRecommendedVM.SelectedAppointment.PatientId);
                    var timeSlot = _patientChoseRecommendedVM.SelectedAppointment.Appointment.TimeSlot;
                    var doctorSchedule = _doctorScheduleService.Get(doctor.Id);
                    //var nextId = doctorSchedule.GetNextAppointmentId();
                    Appointment newAppointment = new Appointment(doctor.Id, patient.Id, 0, timeSlot, false);

                    //TODO: adding appointment to doctorScheduleService ? Should we?
                    //var doctorScheduleService = new DoctorScheduleService(doctorSchedule);
                    //doctorScheduleService.AddAppointment(newAppointment);
                    MessageBox.Show("Uspesno ste zakazali pregled.");
                    _patientChoseRecommendedVM.CloseCommand.Execute(_patientChoseRecommendedVM.window);
                }
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientChoseRecommendedVM.SelectedAppointment))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
