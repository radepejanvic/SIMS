using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;

using Library.Repository;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.ViewModel.Form
{
    public class PatientMedicalRecordTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DoctorViewModel> _doctors;
        public ObservableCollection<DoctorViewModel> Doctors => _doctors;
        private DoctorViewModel _selectedDoctor;
        public DoctorViewModel SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }
        private string _from;
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }
        private string _to;
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }
        private bool _isTimeSelected;
        public bool IsTimeSelected
        {
            get
            {
                return _isTimeSelected;
            }
            set
            {
                _isTimeSelected = value;
                OnPropertyChanged(nameof(IsTimeSelected));
            }
        }
        private bool _isDoctorSelected;
        public bool IsDoctorSelected
        {
            get
            {
                return _isDoctorSelected;
            }
            set
            {
                _isDoctorSelected = value;
                OnPropertyChanged(nameof(IsDoctorSelected));
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public ICommand FindAppointmentCommand { get; }
        public ICommand CloseCommand { get; set; }
        private IDoctorService _doctorService;
        private Patient _patient;
        public Patient Patient { get { return _patient; } }
        public Window window;
        public PatientMedicalRecordTableViewModel(Patient patient, Window window, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IPatientService patientService, IDoctorService doctorService)
        {
            window = window;
            _patient = patient;
            Date = DateTime.Now;

            _doctors = new ObservableCollection<DoctorViewModel>();
            _doctorService = doctorService;
            LoadDoctors();

            FindAppointmentCommand = new FindAppointmentCommand(this, doctorScheduleService, schedulingService, patientService, doctorService);
            CloseCommand = new CloseCommand(window);
        }

        private void LoadDoctors()
        {
            _doctorService.GetAll().Select(d => new DoctorViewModel(d.Value)).ToList().ForEach(vm => _doctors.Add(vm));
        }


    }
}
