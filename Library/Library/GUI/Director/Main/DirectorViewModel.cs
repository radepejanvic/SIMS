
using System.Windows.Input;
using Library.Commands;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.SurveyService;
using Library.Commands.Survey;
using Library.Service.PersonService.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Repository.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.ViewModel
{
    public class DirectorViewModel:ViewModelBase
    {
        public ICommand ShowStaticEquipmentQuantityTable { get; }
        public ICommand ShowDynamicalEquipmentTable { get; }

        public ICommand ShowDynamicalEquipmentRedistributionTable { get; }
        public ICommand ShowStaticEquipmentRedistributionTable { get; }
        public ICommand ShowRoomRenovationFrom { get; }
        public ICommand ShowFusingRoomRenovationFrom { get; }
        public ICommand ShowDefusingRoomRenovationFrom { get; }
        public ICommand ShowHospitalSurvey { get; }
        public ICommand ShowDoctorSurvey { get; }

        public ICommand ShowLeaveRequets { get; }
        public DirectorViewModel(IRoomService roomService, IEquipmentService equipmentService, IRenovationService renovationService,
            IRoomScheduleService roomScheduleService,IHospitalSurveyService hospitalSurveyService,IDoctorSurveyService doctorSurveyService, IPatientService _patientService, 
            IDoctorService doctorService, IAppointmentService appointmentService, ILeaveRequestService _leaveRequestService, IDoctorScheduleService doctorScheduleService,
            IAppointmentNotificationService appointmentNotificationRepository, ISchedulingService schedulingService)
        {
            ShowStaticEquipmentQuantityTable = new ShowStaticEquipmentQuantityTableCommand(roomService);
            ShowDynamicalEquipmentTable = new ShowDynamicalEquipmentTableCommand(equipmentService);
            ShowDynamicalEquipmentRedistributionTable = new ShowDynamicalEquipmentRedistributionTableCommand(equipmentService);
            ShowStaticEquipmentRedistributionTable = new ShowStaticEquipmentRedistributionTableCommand(equipmentService);
            ShowRoomRenovationFrom = new ShowRoomRenovationFormCommand(roomService, renovationService, roomScheduleService);
            ShowFusingRoomRenovationFrom = new ShowFusingRoomRenovationFromCommand(roomService, renovationService, roomScheduleService);
            ShowDefusingRoomRenovationFrom = new ShowDefusingRoomRenovationFromCommand(roomService, renovationService, roomScheduleService);
            ShowHospitalSurvey = new ShowHospitalSurveyCommand(hospitalSurveyService,_patientService);
            ShowDoctorSurvey = new ShowDoctorSurveyTableCommand(doctorSurveyService,doctorService,appointmentService);
            ShowLeaveRequets = new ShowLeaveRequestTableCommand(_leaveRequestService,doctorService,appointmentNotificationRepository,doctorScheduleService,schedulingService,appointmentService);
        }
    }
}
