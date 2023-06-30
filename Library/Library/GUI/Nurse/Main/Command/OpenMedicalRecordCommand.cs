using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View;
using Library.View.Form;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenMedicalRecordCommand : CommandBase
    {
        private readonly PatientTableViewModel _patientTableViewModel;
        private readonly DoctorPatientsTableViewModel _doctorPatientsTableViewModel;
        private IPatientService _patientService;
        private ISchedulingService _schedulingService;
        private IAppointmentService _appointmentService;
        public PatientViewModel SelectedPatient;
        public Doctor Doctor;

        public OpenMedicalRecordCommand(PatientTableViewModel patientTableViewModel,IPatientService patientService, ISchedulingService schedulingService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _schedulingService = schedulingService;
            _appointmentService = appointmentService;
            _patientTableViewModel = patientTableViewModel;
            SelectedPatient = patientTableViewModel.SelectedPatient;
            _patientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public OpenMedicalRecordCommand(DoctorPatientsTableViewModel doctorPatientsTableViewModel, Doctor doctor, ISchedulingService schedulingService, IAppointmentService appointmentService, IPatientService patientService)
        {
            Doctor = doctor;
            _patientService = patientService; 
            _schedulingService = schedulingService;
            _appointmentService = appointmentService;
            _doctorPatientsTableViewModel = doctorPatientsTableViewModel;
            SelectedPatient = doctorPatientsTableViewModel.SelectedPatient;
            _doctorPatientsTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (GetSelectedPatient() is not null) && CheckPatient();
        }
        public override void Execute(object? parameter)
        {
            var popup = new MedicalRecordFormView(GetSelectedPatient(), _patientService);
            popup.ShowDialog();
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SelectedPatient = GetSelectedPatient();
            if (e.PropertyName == nameof(SelectedPatient))
            {
                OnCanExecutedChanged();
            }
        }

        private PatientViewModel GetSelectedPatient()
        {
            return (_doctorPatientsTableViewModel is null) ? _patientTableViewModel.SelectedPatient : _doctorPatientsTableViewModel.SelectedPatient;
        }

        public bool CheckPatient()
        {
            return (_doctorPatientsTableViewModel is null) ? true : FindDoctorsPatient();
        }

        public bool FindDoctorsPatient()
        {
            if (_appointmentService.GetAllPatientIds(Doctor.Id).Any(id => id == SelectedPatient.Patient.Id)) { return true; }

            MessageBox.Show("Ne mozete izmeniti zdravstveni karton pacijenta koga niste do sad pregledali.");
            return false;
        }
    }
}
