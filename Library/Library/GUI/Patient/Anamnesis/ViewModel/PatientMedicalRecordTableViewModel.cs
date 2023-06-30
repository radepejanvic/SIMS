using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;

using Library.Service;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.View;
using Library.View.Table;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Table
{
    public class PatientMedicalRecordTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PatientAnamnesisViewModel> _appointments;
        public ObservableCollection<PatientAnamnesisViewModel> Appointments => _appointments;
        private PatientAnamnesisViewModel _selectedAppointment;
        public PatientAnamnesisViewModel SelectedAppointment
        {
            get { return _selectedAppointment; }
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged(nameof(SelectedAppointment));
            }
        }
        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value.ToLower();
                OnPropertyChanged(nameof(Search));
            }
        }
        public ICommand OpenMedicalRecordCommand { get; }
        public ICommand OpenAnamensisCommand { get ; }
        public ICommand CloseCommand { get; }
        private IAppointmentService _appointmentService;
        private IPatientService _patientService;
        private IDoctorService _doctorService;
        private IAnamnesisService _anamnesisService;
        private Patient _patient;

        public PatientMedicalRecordTableViewModel(Window window, Patient patient,  IDoctorService doctorService, IAppointmentService appointmentService, IAnamnesisService anamnesisService)
        {
            _patient = patient;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _anamnesisService = anamnesisService;
            OpenMedicalRecordCommand = new RelayCommand(OpenMedicalRecord, CanOpen);
            OpenAnamensisCommand = new RelayCommand(OpenAnamnesis, CanOpenAnamnesis);
            CloseCommand = new CloseCommand(window);
            _appointments = new ObservableCollection<PatientAnamnesisViewModel>(_appointmentService.GetAllByPatient(_patient.Id).Values.Select(o => new PatientAnamnesisViewModel(_anamnesisService.GetByAppointment(o.Id), doctorService, appointmentService)));
            PropertyChanged += OnPropertyChanged;
        }


        public bool CanOpen()
        {
            return true;
        }

        public void OpenMedicalRecord()
        {
            var medicalRecordView = new MedicalRecordDoctorView(new PatientViewModel(_patient), _patientService);
            medicalRecordView.DataContext = new MedicalRecordFormViewModel(new PatientViewModel(_patient), _patientService);
            medicalRecordView.ShowDialog();
        }
        public bool CanOpenAnamnesis()
        {
            return SelectedAppointment is not null;
        }
        public void OpenAnamnesis()
        {
            //Need to consult dusan
            //var anamnesisView = new ShowAnamnesisView();
            //anamnesisView.DataContext = new ShowAnamnesisViewModel(new AnamnesisViewModel(SelectedAppointment.Anamnesis), _anamnesisService, null);
            //anamnesisView.ShowDialog();
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Search))
            {
                if(!string.IsNullOrEmpty(Search))
                {
                    var filteredAppointments = _appointments.Where(appointment => appointment.DoctorName.ToLower().Contains(Search.ToLower()) 
                    || appointment.Specialization.ToLower().Contains(Search.ToLower())
                    || appointment.AnamnesisDescription.ToLower().Contains(Search.ToLower())).ToList();
                    _appointments.Clear();
                    foreach(var appointment in filteredAppointments)
                    {
                        _appointments.Add(appointment);
                    }
                }
                else
                {
                    _appointments.Clear();
                    foreach (var appointment in _appointmentService.GetAllByPatient(_patient.Id).Values)
                    {
                        var anamnesis = _anamnesisService.GetByAppointment(appointment.Id);
                        _appointments.Add(new PatientAnamnesisViewModel(anamnesis, _doctorService, _appointmentService));
                    }
                }
            }
        }
    }
}
