using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;
using Library.Model;
using Library.ViewModel.Table;
using Library.ViewModel;
using System.Windows;
using System.Security.AccessControl;
using System.Data.SqlTypes;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.FarmaceuticalService;
using System.Timers;
using Library.Repository.Interface;
using Library.Service.SurveyService;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.MessageService;
using Library.Service.LeaveRequestService.Interface;

namespace Library.Service.TehnicalService
{
    public class LoginService : ILoginService
    {
        // TODO: Remove ICRUD.
        private ICRUDRepository<Director> _directorRepository;
        private ICRUDRepository<Nurse> _nurseRepository;
        private IRoomService _roomService;
        // TODO: Uncomment IUserService when it's implemented.
        //private IUserService _userService;

        private readonly IAppointmentInitiationService _appointmentInitiationService;
        private readonly IDoctorService _doctorService;
        private readonly IDoctorScheduleService _doctorScheduleService;
        private readonly ISchedulingService _schedulingService;
        private readonly IPatientService _patientService;
        private readonly IEquipmentService _equipmentService;
        private readonly IAppointmentNotificationService _notificationService;
        private readonly IAppointmentService _appointmentService;
        private readonly IAnamnesisService _anamnesisService;
        private readonly IPerscriptionService _perscriptionService;
        private readonly IDrugService _drugService;
        private readonly IDrugPerscribingService _drugPerscribingService;
        private readonly IDrugOrderService _drugOrderService;
        private readonly IDrugWarehouseService _drugWarehouseService;
        private readonly IRefferalSchedulingService _refferalSchedulingService;
        private readonly IPerscriptionSchedulingService _perscriptionSchedulingService;
        private readonly IRoomScheduleService _roomScheduleService;
        private readonly IRenovationService _renovationService;
        private readonly IDoctorRefferalService _doctorRefferalService;
        private readonly IHospitalRefferalService _hospitalRefferalService;
        private readonly IHospitalTreatmentService _hospitalTreatmentService;
        private readonly IPatientCheckupService _patientCheckupService;

        private readonly ICustomNotificationService _customNotificationService;
        private readonly ICustomNotificationConfigurationService _customNotificationConfigurationService;
        private readonly IHospitalSurveyService _hospitalSurveyService;
        private readonly IDoctorSurveyService _doctorSurveyService;
        private readonly IMessageService _messageService;
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly INurseService _nurseService;
        public LoginService(ICRUDRepository<Director> directorRepository, ICRUDRepository<Nurse> nurseRepository, IDoctorService doctorService, IPatientService patientService, 
            IRoomService roomService, IEquipmentService equipmentService, IAppointmentNotificationService notificationService, IDoctorScheduleService doctorScheduleService, 
            ISchedulingService schedulingService, IAppointmentService appointmentService, IAnamnesisService anamnesisService, IDoctorRefferalService doctorRefferalService, 
            IHospitalRefferalService hospitalRefferalService, IPerscriptionService perscriptionService, IDrugService drugService, IDrugPerscribingService drugPerscribingService, 
            IDrugOrderService drugOrderService, IDrugWarehouseService drugWarehouseService, IRefferalSchedulingService refferalSchedulingService, 
            ICustomNotificationService customNotificationService, ICustomNotificationConfigurationService customNotificationConfigurationService, IPerscriptionSchedulingService perscriptionSchedulingService,
            IRenovationService renovationService, IRoomScheduleService roomScheduleService, IAppointmentInitiationService appointmentInitiationService, IHospitalSurveyService hospitalSurveyService, 
            IHospitalTreatmentService hospitalTreatmentService, IPatientCheckupService patientCheckupService, IDoctorSurveyService doctorSurveyService, IMessageService messageService,
            ILeaveRequestService leaveRequestService, INurseService nurseService)
        {
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _directorRepository = directorRepository;
            _nurseRepository = nurseRepository;
            _doctorService = doctorService;
            _patientService = patientService;
            _roomService = roomService;
            _equipmentService = equipmentService;
            _notificationService = notificationService;
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _appointmentService = appointmentService;
            _anamnesisService = anamnesisService;
            _doctorRefferalService = doctorRefferalService;
            _hospitalRefferalService = hospitalRefferalService;
            _perscriptionService = perscriptionService;
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;
            _drugOrderService = drugOrderService;
            _drugWarehouseService = drugWarehouseService;
            _refferalSchedulingService = refferalSchedulingService;
            _perscriptionSchedulingService = perscriptionSchedulingService;
            _roomScheduleService = roomScheduleService;
            _renovationService = renovationService;
            _hospitalTreatmentService = hospitalTreatmentService;
            _patientCheckupService = patientCheckupService;
            _appointmentInitiationService = appointmentInitiationService;
            _customNotificationService = customNotificationService;
            _customNotificationConfigurationService = customNotificationConfigurationService;
            _hospitalSurveyService = hospitalSurveyService;
            _doctorSurveyService = doctorSurveyService;
            _messageService = messageService;
            _leaveRequestService = leaveRequestService;
            _nurseService = nurseService;
        }

        public void Login(string username, string password, MainViewModel mainViewModel)
        {
            if (IsValidPassword(IsDoctor(username), password))
            {
                LoginDoctor(mainViewModel, username);

            }
            else if (IsValidPassword(IsPatient(username), password))
            {
                LoginPatient(mainViewModel, username);

            }
            else if (IsValidPassword(IsNurse(username), password))
            {
                LoginNurse(mainViewModel);

            }
            else if (IsValidPassword(IsDirector(username), password))
            {
                LoginDirector(mainViewModel);
            }
            else
            {
                MessageBox.Show("Lose uneti podaci");
            }
        }

        private Doctor? IsDoctor(string username)
        {
            return _doctorService.GetAll().Values.FirstOrDefault(o => o.Username == username);
        }

        private Patient? IsPatient(string username)
        {
            return _patientService.GetAll().Values.FirstOrDefault(o => o.Username == username);
        }

        private Nurse? IsNurse(string username)
        {
            return _nurseRepository.GetAll().Values.FirstOrDefault(o => o.Username == username);
        }

        private Director? IsDirector(string username)
        {
            return _directorRepository.GetAll().Values.FirstOrDefault(o => o.Username == username);
        }

        // TODO: Move to UserSrevice.
        private bool IsValidPassword(Person? user, string password)
        {
            return user is not null && user.Password == password;
        }

        public void LoginDoctor(MainViewModel mainViewModel, string username)
        {
            var user = _doctorService.GetAll().Values.FirstOrDefault(o => o.Username == username);
            _notificationService.NotifyDoctor(user.Id);
            mainViewModel.CurrentViewModel = new DoctorMainViewModel(user, _schedulingService, _doctorScheduleService, _patientService, _appointmentService, _doctorService, _anamnesisService, _appointmentInitiationService, _doctorRefferalService, _drugService, _drugPerscribingService, _hospitalRefferalService, _leaveRequestService);
        }
        public void LoginPatient(MainViewModel mainViewModel, string username)
        {
            var user = _patientService.GetAll().Values.FirstOrDefault(o => o.Username == username);
            _notificationService.NotifyPatient(user.Id);
            StartTimer(user.Id);
            mainViewModel.CurrentViewModel = new PatientMainViewModel(user, _schedulingService, _appointmentService, _doctorScheduleService, _patientService, _doctorService, _anamnesisService, _customNotificationService, _customNotificationConfigurationService, _hospitalSurveyService, _doctorSurveyService, _messageService, _nurseService);
        }
        private static Timer _timer;

        private void StartTimer(int patientId)
        {
            _timer = new Timer(10000);
            _timer.Elapsed += (sender, e) => _customNotificationService.TimerElapsed(sender, e, patientId);
            _timer.AutoReset = true;
            _timer.Start();
        }
        public void LoginNurse(MainViewModel mainViewModel)
        {
            mainViewModel.CurrentViewModel = new PatientTableViewModel(_patientService, _doctorService, _doctorScheduleService, _schedulingService, _notificationService, _appointmentService, 
                _doctorRefferalService, _hospitalRefferalService, _perscriptionService, _drugService, _drugPerscribingService, _drugWarehouseService, _refferalSchedulingService,
                _perscriptionSchedulingService, _hospitalTreatmentService, _patientCheckupService);
        }
        public void LoginDirector(MainViewModel mainViewModel)
        {
            mainViewModel.CurrentViewModel = new DirectorViewModel(_roomService, _equipmentService,_renovationService,_roomScheduleService,
                _hospitalSurveyService,_doctorSurveyService,_patientService,_doctorService,_appointmentService,_leaveRequestService,_doctorScheduleService, _notificationService,_schedulingService);
        }
    }
}
