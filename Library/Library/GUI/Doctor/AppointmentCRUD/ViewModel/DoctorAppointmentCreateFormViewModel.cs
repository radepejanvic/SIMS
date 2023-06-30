using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Library.Commands;

using Library.Model;
using System.Text.RegularExpressions;
using System.Numerics;
using Library.Service;
using Library.Repository;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.ViewModel.Form
{
    public class DoctorAppointmentCreateFormViewModel: ViewModelBase
    {
        private readonly ObservableCollection<PatientViewModel> _patients;
        public ObservableCollection<PatientViewModel> Patients => _patients;
        private ObservableCollection<AppointmentViewModel> _appointments;
        private PatientViewModel _selectedPatient;
        public Doctor Doctor;
        public PatientViewModel SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public CRUDRepository<Patient> PatientDAO;
        private string _duration;
        public string Duration
        {
            get
            {
                return _duration;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        private bool _isOperationSelected;
        public bool IsOperationSelected
        {
            get { return _isOperationSelected; }
            set
            {
                if (_isOperationSelected != value)
                {
                    _isOperationSelected = value;
                    OnPropertyChanged(nameof(IsOperationSelected));
                }
            }
        }

        private bool _isAppointmentSelected;
        public bool IsAppointmentSelected
        {
            get { return _isAppointmentSelected; }
            set
            {
                if (_isAppointmentSelected != value)
                {
                    _isAppointmentSelected = value;
                    OnPropertyChanged(nameof(IsAppointmentSelected));
                }
            }
        }
        private bool _isTextBoxEnabled;
        public bool IsTextBoxEnabled
        {
            get { return _isTextBoxEnabled; }
            set
            {
                _isTextBoxEnabled = value;
                OnPropertyChanged(nameof(IsTextBoxEnabled));
            }
        }

        public string DateAndTime { get; set; }
        public ICommand EnableTextBoxCommand { get; private set; }
        public ICommand DisableTextBoxCommand { get; private set; }
        public ICommand CreateAppointmentCommand { get; }
        public ICommand CloseCommand { get; set; }
        private IDoctorScheduleService _doctorScheduleService;
        private IPatientService _patientService;
        private ISchedulingService _schedulingService;
        private IDoctorService _doctorService;
        public DoctorAppointmentCreateFormViewModel(Window window, Doctor doctor, ObservableCollection<AppointmentViewModel> appointments, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            Doctor = doctor;
            _appointments = appointments;

            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _patientService = patientService;
            _doctorService = doctorService;

            _patients = new ObservableCollection<PatientViewModel>();
            _patientService.GetAll().Select(d => new PatientViewModel(d.Value)).ToList().ForEach(vm => Patients.Add(vm));

            CloseCommand = new CloseCommand(window);
            EnableTextBoxCommand = new RelayCommand(EnableTextBox, CanExecute);
            DisableTextBoxCommand = new RelayCommand(DisableTextBox, CanExecute);
            CreateAppointmentCommand = new RelayCommand(CreateAppointment, CanCreateAppointment);
        }
        private bool CanCreateAppointment()
        {
            return (SelectedPatient != null) && !(String.IsNullOrEmpty(DateAndTime))
                && (ConvertStringToDateTime(this.DateAndTime).CompareTo(DateTime.Now) > 0);
        }
        private int GetDuration()
        {
            if (IsAppointmentSelected)
            {
                return 15;
            }
            return int.Parse(Duration);
        }
       
        public static DateTime ConvertStringToDateTime(string date)
        {
            if (date.Contains("/"))
            {
                return DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            }
            return DateTime.ParseExact(date, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture); 
        }
        public static TimeSlot CreateTimeSlot(DateTime date, int minutes)
        {
            return new TimeSlot(date, date.AddMinutes(minutes));
        }

        private void CreateAppointment()
        {
            TimeSlot timeSlot = CreateTimeSlot(ConvertStringToDateTime(this.DateAndTime), GetDuration());

            if (CanCreateAppointment()
                && (_schedulingService.IsAvaliable(Doctor, timeSlot))
                && (_schedulingService.IsAvaliable(SelectedPatient.Patient, timeSlot))
                && (_schedulingService.GetFirstAvaliableRoom(timeSlot) != 0))
            {
                Appointment newAppointment = new Appointment(Doctor.Id, SelectedPatient.Patient.Id, _schedulingService.GetFirstAvaliableRoom(timeSlot), timeSlot, IsOperationSelected);

                _schedulingService.Schedule(newAppointment);
                _appointments.Add(new AppointmentViewModel(newAppointment, _patientService, _doctorService));

                CloseCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Pacijent ili vi niste slobodni u tom trenutku.");
            }
        }
        public bool CanExecute()
        {
            return true;
        }
        private void EnableTextBox()
        {
            IsTextBoxEnabled = true;
        }

        private void DisableTextBox()
        {
            IsTextBoxEnabled = false;
        }
    }
}
