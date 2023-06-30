using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Repository;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.ViewModel.Form
{
    public class DoctorRefferalFormViewModel: ViewModelBase
    {
        public ObservableCollection<DoctorViewModel> Doctors { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }

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

        private Specialization _selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get { return _selectedSpecialization; }
            set
            {
                _selectedSpecialization = value;
                OnPropertyChanged(nameof(SelectedSpecialization));
            }
        }

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

        private bool _isSpecificDoctorSelected;
        public bool IsSpecificDoctorSelected
        {
            get { return _isSpecificDoctorSelected; }
            set
            {
                if (_isSpecificDoctorSelected != value)
                {
                    _isSpecificDoctorSelected = value;
                    OnPropertyChanged(nameof(IsSpecificDoctorSelected));
                }
            }
        }

        private bool _isSpecificSpecializationSelected;
        public bool IsSpecificSpecializationSelected
        {
            get { return _isSpecificSpecializationSelected; }
            set
            {
                if (_isSpecificSpecializationSelected != value)
                {
                    _isSpecificSpecializationSelected = value;
                    OnPropertyChanged(nameof(IsSpecificSpecializationSelected));
                }
            }
        }

        public ICommand CreateDoctorRefferal { get; }

        private IDoctorService _doctorService;

        public DoctorRefferalFormViewModel(IDoctorService doctorService, Appointment appointment, IDoctorRefferalService doctorRefferalService)
        {
            _doctorService = doctorService;

            GetDoctors();
            GetSpecializations();

            CreateDoctorRefferal = new CreateDoctorRefferalCommand(this, appointment, doctorRefferalService);
        }

        private void GetSpecializations()
        {
            var allSpecializations = Enum.GetValues(typeof(Specialization)).Cast<Specialization>().ToList();
            Specializations = new ObservableCollection<Specialization>(allSpecializations);
        }

        private void GetDoctors()
        {
            Doctors = new ObservableCollection<DoctorViewModel>();

            foreach (var doctor in _doctorService.GetAll().Values)
            {
                Doctors.Add(new DoctorViewModel(doctor));
            }
        }
    }
}
