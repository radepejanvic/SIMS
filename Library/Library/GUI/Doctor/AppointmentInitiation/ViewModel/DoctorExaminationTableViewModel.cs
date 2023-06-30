using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using Library.Commands;

using Library.Model;
using Library.Service;
using Library.View;
using System.ComponentModel;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.AppointmentService;
using System.Numerics;
using Library.Service.PersonService;
using Library.Service.RefferalService.Interface;
using Library.Service.FarmaceuticalService.Interface;

namespace Library.ViewModel.Table
{
    public class DoctorExaminationTableViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<AppointmentViewModel> _appointments;
        public ObservableCollection<AppointmentViewModel> Appointments => _appointments;
        private AppointmentViewModel _selectedAppointment;

        public AppointmentViewModel SelectedAppointment
        {
            get { return _selectedAppointment; }
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }

        private Doctor Doctor { get; set; }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private ISchedulingService _schedulingService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private IAnamnesisService _anamnesisService;
        private IAppointmentInitiationService _appointmentInitiationService;

        public ICommand InitiateAppointment { get; }

        // TODO: Rename the class.
        public DoctorExaminationTableViewModel(Doctor doctor, ISchedulingService schedulingService, 
            IPatientService patientService, IAppointmentService appointmentService, IDoctorService doctorService, 
            IAnamnesisService anamnesisService, IAppointmentInitiationService appointmentInitiationService, 
            IDoctorRefferalService doctorRefferalService, IDrugService drugService, IDrugPerscribingService drugPerscribingService,
            IHospitalRefferalService hospitalRefferalService)
        {
            Doctor = doctor;

            _schedulingService = schedulingService;
            _patientService = patientService;
            _doctorService = doctorService;
            _anamnesisService = anamnesisService;
            _appointmentInitiationService = appointmentInitiationService;

            LoadAppointments();

            InitiateAppointment = new InitiateAppointmentCommand(this, _patientService, _anamnesisService, 
                doctorService, doctorRefferalService, drugService, drugPerscribingService, hospitalRefferalService);
        }

        private void LoadAppointments()
        {
            _appointments = new ObservableCollection<AppointmentViewModel>();

            foreach (var appointment in _appointmentInitiationService.GetAllByTime(Doctor.Id))
            {
                _appointments.Add(new AppointmentViewModel(appointment, _patientService, _doctorService));
            }
        }

        public PatientViewModel GetPatient()
        {
            return new PatientViewModel(SelectedAppointment.Patient);
        }

    }
}
