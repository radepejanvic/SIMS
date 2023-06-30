using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.View;
using Library.View.Form;
using Library.ViewModel.Table;
using Library.ViewModel.Form;
using Library.View.Table;
using Library.Service;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.Service.TehnicalService;
using Library.ViewModel.Form.Survey;
using Library.View.Form.Survey;
using Library.ViewModel.Table.Survey;
using Library.View.Table.Survey;
using Library.Service.SurveyService;
using Library.View.Table.Chat;
using Library.ViewModel.Table.Chat;
using Library.Service.MessageService;

namespace Library.ViewModel
{
    public class PatientMainViewModel : ViewModelBase
    {
        public ICommand PatientAppointmetsCommand { get;  }
        public ICommand SchedulingRecommendationCommand { get; }
        public ICommand OpenPatientMedicalRecordCommand { get; }
        public ICommand DoctorSearchCommand { get; }
        public ICommand OpenNotificationCommand { get; }
        public ICommand OpenChatCommand { get; }
        public ICommand OpenSurveyCommand { get; }
        private Patient _patient;
        private IPatientService _patientService;
        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        private IDoctorService _doctorService;
        private IAppointmentService _appointmentService;
        private IAnamnesisService _anamnesisService;
        private ICustomNotificationService _customNotificationService;
        private ICustomNotificationConfigurationService _customNotificationConfigurationService;
        private IHospitalSurveyService _hospitalSurveyService;
        private IDoctorSurveyService _doctorSurveyService;
        private IMessageService _messageService;
        private INurseService _nurseService;
        public PatientMainViewModel(Patient patient, ISchedulingService schedulingService,IAppointmentService appointmentService, IDoctorScheduleService doctorScheduleService, 
            IPatientService patientService, IDoctorService doctorService, IAnamnesisService anamnesisService,
            ICustomNotificationService customNotificationService, ICustomNotificationConfigurationService customNotificationConfigurationService, IHospitalSurveyService hospitalSurveyService, 
            IDoctorSurveyService doctorSurveyService, IMessageService messageService, INurseService nurseService)
        {
            _doctorService = doctorService;
            _patient = patient;
            _schedulingService = schedulingService;
            _doctorScheduleService = doctorScheduleService;
            _patientService = patientService;
            _appointmentService = appointmentService;
            _customNotificationService = customNotificationService;
            _customNotificationConfigurationService = customNotificationConfigurationService;
            _hospitalSurveyService = hospitalSurveyService;
            _doctorSurveyService = doctorSurveyService;
            PatientAppointmetsCommand = new RelayCommand(OpenAppointments, CanClick);
            SchedulingRecommendationCommand = new RelayCommand(OpenSchedulingRecommendation, CanClick);
            OpenPatientMedicalRecordCommand = new RelayCommand(OpenPatientMedicalRecord, CanClick);
            DoctorSearchCommand = new RelayCommand(OpenDoctorSearch, CanClick);
            OpenNotificationCommand = new RelayCommand(OpenNotification, CanClick);
            OpenChatCommand = new RelayCommand(OpenChat, CanClick);
            OpenSurveyCommand = new RelayCommand(OpenSurvey, CanClick);
            _doctorService = doctorService;
            _anamnesisService = anamnesisService;
            _messageService = messageService;
            _nurseService = nurseService;
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenAppointments()
        {
            var patientAppointments = new PatientAppoinmentsView();
            patientAppointments.DataContext = new PatientAppointmentTableViewModel(_patient, _schedulingService,_appointmentService, _doctorScheduleService, _patientService, _doctorService);
            patientAppointments.ShowDialog();
        }
        public void OpenSchedulingRecommendation()
        {
            var schedulingRecommendation = new PatientAdvancedAppointmentScheduilingView();
            schedulingRecommendation.DataContext = new Form.PatientMedicalRecordTableViewModel(_patient, schedulingRecommendation, _doctorScheduleService, _schedulingService, _patientService, _doctorService);
            schedulingRecommendation.ShowDialog();
        }

        public void OpenPatientMedicalRecord()
        {
            var patiendMedicalRecord = new PatientMedicalRecordTableView();
            patiendMedicalRecord.DataContext = new Table.PatientMedicalRecordTableViewModel(patiendMedicalRecord, _patient, _doctorService, _appointmentService, _anamnesisService);
            patiendMedicalRecord.ShowDialog();
        }

        public void OpenDoctorSearch()
        {
            var patientDoctorSearchTableView = new PatientDoctorSearchTableView();
            patientDoctorSearchTableView.DataContext = new Table.PatientDoctorSearchTableViewModel(patientDoctorSearchTableView, _patient, _doctorService, _schedulingService, _doctorScheduleService, _patientService);
            patientDoctorSearchTableView.ShowDialog();
        }

        public void OpenNotification()
        {
            var notificationView = new PatientNotificationTableView();
            notificationView.DataContext = new PatientNotificationTableViewModel(notificationView, _patient, _customNotificationService, _customNotificationConfigurationService);
            notificationView.ShowDialog();
        }

        public void OpenChat()
        {
            var chatView = new RecipientMessageTableView();
            chatView.DataContext = new RecipientMessageTableViewModel(chatView, _patient, _messageService, _nurseService, _doctorService);
            chatView.ShowDialog();
        }

        public void OpenSurvey()
        {
            var patientSurveyTableView = new PatientSurveyTableView();
            patientSurveyTableView.DataContext = new PatientSurveyTableViewModel(patientSurveyTableView, _patient, _hospitalSurveyService, _doctorSurveyService, _appointmentService, _doctorService, _patientService);
            patientSurveyTableView.ShowDialog();
        }
    }
}
