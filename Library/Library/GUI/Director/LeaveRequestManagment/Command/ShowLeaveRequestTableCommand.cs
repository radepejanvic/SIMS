using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository.Interface;
using Library.Service.AppointmentService.Interface;
using Library.Service.LeaveRequestService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class ShowLeaveRequestTableCommand : CommandBase
    {
        private ILeaveRequestService _leaveRequestService;
        private IDoctorService _doctorService;
        private IAppointmentNotificationService _appointmentNotificationRepository;
        private IDoctorScheduleService _doctorScheduleService;
        private ISchedulingService _schedulingService;
        private IAppointmentService _appointmentServic;
        public ShowLeaveRequestTableCommand(ILeaveRequestService leaveRequestService, IDoctorService doctorService, IAppointmentNotificationService appointmentNotificationRepository,
            IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentService _appointmentServic)
        {
            this._leaveRequestService = leaveRequestService;
            _leaveRequestService = leaveRequestService;
            _doctorService = doctorService;
            _appointmentNotificationRepository = appointmentNotificationRepository;
                _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            this._appointmentServic = _appointmentServic;
        }

        public override void Execute(object? parameter)
        {
            var leaveRequestTableView = new LeaveRequestTableView();
            leaveRequestTableView.DataContext = new LeaveRequestTableViewModel(_leaveRequestService,_doctorService,_appointmentNotificationRepository,_doctorScheduleService,_schedulingService,_appointmentServic);
            leaveRequestTableView.Show();
        }
    }
}
