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
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.Service.SurveyService;
using Library.View.Form.Survey;
using Library.ViewModel.Form.Survey;

namespace Library.ViewModel.Table.Survey
{
    public class PatientSurveyTableViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AppointmentViewModel> _appointments;
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
        public ICommand OpenHospitalSurveyCommand { get; }
        public ICommand OpenDoctorSurveyCommand { get; }
        public ICommand CloseCommand { get; }
        private Patient _patient;
        private IHospitalSurveyService _hospitalSurveyService;
        private IDoctorSurveyService _doctorSurveyService;
        private IAppointmentService _appointmentService;
        private IDoctorService _doctorService;
        private IPatientService _patientService;
        public PatientSurveyTableViewModel(Window window, Patient patient, IHospitalSurveyService hospitalSurveyService, IDoctorSurveyService doctorSurveyService, IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService)
        {
            _patient = patient;
            _hospitalSurveyService = hospitalSurveyService;
            _doctorSurveyService = doctorSurveyService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
            _appointments = new ObservableCollection<AppointmentViewModel>();
            LoadAppointments();
            OpenHospitalSurveyCommand = new RelayCommand(OpenHospitalSurvey);
            OpenDoctorSurveyCommand = new RelayCommand(OpenDoctorSurvey, CanOpenDoctorSurvey);
            CloseCommand = new CloseCommand(window);
        }

        public void OpenHospitalSurvey()
        {
            var patientHospitalSurveyFormView = new PatientHospitalSurveyFormView();
            patientHospitalSurveyFormView.DataContext = new PatientHospitalSurveyFormViewModel(patientHospitalSurveyFormView, _patient,  _hospitalSurveyService);
            patientHospitalSurveyFormView.ShowDialog();
        }
        public bool CanOpenDoctorSurvey()
        {
            return SelectedAppointment != null;
        }
        public void OpenDoctorSurvey()
        {
            var patientDoctorSurveyFormView = new PatientDoctorSurveyFormView();
            patientDoctorSurveyFormView.DataContext = new PatientDoctorSurveyFormViewModel(patientDoctorSurveyFormView, SelectedAppointment, _doctorSurveyService);
            patientDoctorSurveyFormView.ShowDialog();
        }

        public void LoadAppointments()
        {
            foreach (var appointment in _appointmentService.GetAllFinished(_patient.Id))
            {
                _appointments.Add(new AppointmentViewModel(appointment, _patientService, _doctorService));
            }
        }
    }
}
