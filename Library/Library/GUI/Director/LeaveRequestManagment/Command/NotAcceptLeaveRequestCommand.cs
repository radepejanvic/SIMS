using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.AppointmentService.Interface;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class NotAcceptLeaveRequestCommand : CommandBase
    {
        private ILeaveRequestService _leaveRequestService;
        private LeaveRequestTableViewModel _leaveRequestTableViewModel;

        public NotAcceptLeaveRequestCommand(ILeaveRequestService leaveRequestService,LeaveRequestTableViewModel leaveRequestTableViewModel)
        {
            _leaveRequestService = leaveRequestService;
            _leaveRequestTableViewModel = leaveRequestTableViewModel;
            _leaveRequestTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override bool CanExecute(object? parameter)
        {
            return _leaveRequestTableViewModel.SelectedLeaveRequest is not null;
        }

        public override void Execute(object? parameter)
        {
            var leaveRequets = _leaveRequestTableViewModel.SelectedLeaveRequest._leaveRequest;
            _leaveRequestTableViewModel.LeaveRequest.Remove(_leaveRequestTableViewModel.SelectedLeaveRequest);
            leaveRequets.Status = "ODBIJENA";
            _leaveRequestService.Update(leaveRequets);
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_leaveRequestTableViewModel.SelectedLeaveRequest))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
