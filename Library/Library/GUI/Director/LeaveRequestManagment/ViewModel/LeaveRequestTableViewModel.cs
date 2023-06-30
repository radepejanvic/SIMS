using System.Collections.ObjectModel;
using System.Linq;
using Library.Commands;
using Library.Repository;
using Library.Repository.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Table
{
    public class LeaveRequestTableViewModel:ViewModelBase
    {
		private ObservableCollection<LeaveRequestDtoViewModel> _leaveRequests;
		public ObservableCollection<LeaveRequestDtoViewModel> LeaveRequest
        {
			get
			{
				return _leaveRequests;
			}
			set
			{
                _leaveRequests = value;
				OnPropertyChanged(nameof(LeaveRequest));
			}
		}
		private LeaveRequestDtoViewModel _selectedLeaveRequest;
		public LeaveRequestDtoViewModel SelectedLeaveRequest
		{
			get
			{
				return _selectedLeaveRequest;
			}
			set
			{
				_selectedLeaveRequest = value;
				OnPropertyChanged(nameof(SelectedLeaveRequest));
			}
		}
		public CommandBase AcceptLeaveRequestCommand { get; }
		public CommandBase NotAcceptLeaveRequestCommand { get; }
        public LeaveRequestTableViewModel(ILeaveRequestService leaveRequestService, IDoctorService doctorService, IAppointmentNotificationService appointmentNotificationRepository,
            IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentService _appointmentServic)
        {
			_leaveRequests = new ObservableCollection<LeaveRequestDtoViewModel>( leaveRequestService.GetAll().Values.Where(g=>g.Status== "NA CEKANJU")
				.Select(o=> new LeaveRequestDtoViewModel(o,doctorService.Get(o.DoctorId).FirstName+" "+ doctorService.Get(o.DoctorId).LastName, o.TimeSlot)));
			AcceptLeaveRequestCommand = new AcceptLeaveRequestCommand(leaveRequestService, schedulingService, this, appointmentNotificationRepository, doctorScheduleService,_appointmentServic);
			NotAcceptLeaveRequestCommand = new NotAcceptLeaveRequestCommand(leaveRequestService, this);
        }
    }
}