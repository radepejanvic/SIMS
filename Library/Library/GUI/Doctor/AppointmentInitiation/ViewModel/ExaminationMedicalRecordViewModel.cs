using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
using Library.Commands;
using Library.Model;
using Library.Model.Enum;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService.Interface;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.ViewModel
{
    public class ExaminationMedicalRecordViewModel: ViewModelBase
    {
        public PatientViewModel SelectedPatient { get; set; }
        public ObservableCollection<Alergy> AvaliableAlergies { get; set; }
        public ObservableCollection<Disease> AvaliableDiseases { get; set; }

        private Alergy? _selectedAlergy;
        public Alergy? SelectedAlergy
        {
            get
            {
                return _selectedAlergy;
            }
            set
            {
                _selectedAlergy = value;
                OnPropertyChanged(nameof(SelectedAlergy));
            }
        }

        private Disease? _selectedDisease;
        public Disease? SelectedDisease
        {
            get
            {
                return _selectedDisease;
            }
            set
            {
                _selectedDisease = value;
                OnPropertyChanged(nameof(SelectedDisease));
            }
        }

        private double _height;
        public double Height
        {
            get
            {
                return _height;

            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private double _weight;
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private bool _isAnamnesisEntered;
        public bool IsAnamnesisEntered
        {
            get
            {
                return _isAnamnesisEntered;
            }
            set
            {
                _isAnamnesisEntered = value;
                OnPropertyChanged(nameof(IsAnamnesisEntered));
            }
        }

        private ObservableCollection<Alergy> _alergies;
        public ObservableCollection<Alergy> Alergies => _alergies;

        private ObservableCollection<Disease> _diseases;
        public ObservableCollection<Disease> Diseases => _diseases;
        public AppointmentViewModel SelectedAppointment { get; set; }

        private IAnamnesisService _anamnesisService;
        public ICommand AddAlergy { get; }
        public ICommand AddDisease { get; }

        public ICommand SubmitMedicalRecord { get; }
        public ICommand OpenAnamnesis { get; }
        public ICommand OpenDoctorRefferal { get; }
        public ICommand OpenHospitalRefferal { get; }
        public ICommand OpenPersciption { get; }

        public ExaminationMedicalRecordViewModel(PatientViewModel selectedPatient, AppointmentViewModel appointment, 
            IPatientService patientService, IAnamnesisService anamnesisService, IDoctorService doctorService, 
            IDoctorRefferalService doctorRefferalService, IDrugService drugService, IDrugPerscribingService drugPerscribingService, 
            IHospitalRefferalService hospitalRefferalService)
        {
            _anamnesisService = anamnesisService;

            SelectedPatient = selectedPatient;
            SelectedAppointment = appointment;
            IsAnamnesisEntered = false;

            _height = selectedPatient?.MedicalRecord?.Height ?? 0;
            _weight = selectedPatient?.MedicalRecord?.Weight ?? 0;

            _diseases = new ObservableCollection<Disease>(selectedPatient?.MedicalRecord?.Diseases ?? new List<Disease>());
            _alergies = new ObservableCollection<Alergy>(selectedPatient?.MedicalRecord?.Alergies ?? new List<Alergy>());

            AvaliableAlergies = GetAvaliableAlergies();
            AvaliableDiseases = GetAvaliableDisease();

            AddAlergy = new AddAlergyCommand(this);
            AddDisease = new AddDiseaseCommand(this);

            SubmitMedicalRecord = new SubmitMedicalRecordCommand(this, patientService);
            OpenAnamnesis = new OpenAnamnesisCommand(this, anamnesisService, appointment.Appointment);
            OpenDoctorRefferal = new OpenDoctorRefferalCommand(doctorService, appointment.Appointment, doctorRefferalService);
            OpenHospitalRefferal = new OpenHospitalRefferalCommand(appointment.Appointment, drugService, drugPerscribingService, 
                hospitalRefferalService);
            OpenPersciption = new OpenPersciptionCommand(true, drugService, drugPerscribingService, appointment.Appointment);
        }


        private ObservableCollection<Alergy> GetAvaliableAlergies()
        {
            var allAlergies = Enum.GetValues(typeof(Alergy)).Cast<Alergy>().ToList();
            foreach (Alergy alergy in _alergies)
            {
                allAlergies.Remove(alergy);
            }
            return new ObservableCollection<Alergy>(allAlergies);

        }

        private ObservableCollection<Disease> GetAvaliableDisease()
        {
            var allDiseases = Enum.GetValues(typeof(Disease)).Cast<Disease>().ToList();
            foreach (Disease disease in _diseases)
            {
                allDiseases.Remove(disease);
            }
            return new ObservableCollection<Disease>(allDiseases);

        }
    }
}
