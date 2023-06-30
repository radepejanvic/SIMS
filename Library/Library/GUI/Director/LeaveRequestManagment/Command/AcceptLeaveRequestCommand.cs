using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Repository.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel;
using Library.ViewModel.Table;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.Model;
using Library.Service.AppointmentService.Interface;

namespace Library.Commands
{
    public class AcceptLeaveRequestCommand : CommandBase
    {
        private ILeaveRequestService _leaveRequestService;
        private ISchedulingService _schedulingService;
        private LeaveRequestTableViewModel _leaveRequestTableViewModel;
        private IDoctorScheduleService _doctorScheduleService;
        private IAppointmentNotificationService _appointmentNotificationService;
        private IAppointmentService _appointmentService;
        public AcceptLeaveRequestCommand(ILeaveRequestService leaveRequestService, ISchedulingService schedulingService,
            LeaveRequestTableViewModel leaveRequestTableViewModel, IAppointmentNotificationService appointmentNotificationService,
            IDoctorScheduleService doctorScheduleService,IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            _doctorScheduleService= doctorScheduleService;
            _leaveRequestService=leaveRequestService;
            _appointmentNotificationService = appointmentNotificationService;
            _schedulingService = schedulingService;
            _leaveRequestTableViewModel = leaveRequestTableViewModel;
            _leaveRequestTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leaveRequestTableViewModel.SelectedLeaveRequest is not null;
        }

        public override void Execute(object? parameter)
        {
            var doctor = _leaveRequestTableViewModel.SelectedLeaveRequest.DoctorId;
            var timeslot = _leaveRequestTableViewModel.SelectedLeaveRequest.TimeSlot;
            if (!_schedulingService.IsAvaliableForVacation(doctor, timeslot))
            {
                _doctorScheduleService.Get(doctor).GetAllAppointmentsFor(timeslot).
                    ForEach(o => { _schedulingService.Unschedule(_appointmentService.Get(o));
                        var appointemnt = _appointmentService.Get(o);
                        _appointmentNotificationService.Add(new AppointmentNotification(doctor,appointemnt.PatientId,appointemnt.TimeSlot,new TimeSlot())); });
                Accept();
            }
            else
            {
                Accept();
            }
            
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_leaveRequestTableViewModel.SelectedLeaveRequest))
            {
                OnCanExecutedChanged();
            }
        }
        public void Accept()
        {
            var leaveRequets = _leaveRequestTableViewModel.SelectedLeaveRequest._leaveRequest;
            leaveRequets.Status = "PRIHVACENA";
            _leaveRequestService.Update(leaveRequets);
            _leaveRequestTableViewModel.LeaveRequest.Remove(_leaveRequestTableViewModel.SelectedLeaveRequest);
        }
    }
}
