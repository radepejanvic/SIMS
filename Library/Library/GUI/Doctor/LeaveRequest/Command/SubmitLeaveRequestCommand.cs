using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service.LeaveRequestService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.ScheduleService;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class SubmitLeaveRequestCommand : CommandBase
    {
        private LeaveRequestFormViewModel _leaveRequestFormViewModel;

        public Doctor Doctor;

        private ILeaveRequestService _leaveRequestService;
        private ISchedulingService _schedulingService;

        public SubmitLeaveRequestCommand(LeaveRequestFormViewModel leaveRequestFormViewModel, Doctor doctor, ISchedulingService schedulingService,
            ILeaveRequestService leaveRequestService)
        {
            Doctor = doctor;

            _schedulingService = schedulingService;
            _leaveRequestService = leaveRequestService;

            _leaveRequestFormViewModel = leaveRequestFormViewModel;
            _leaveRequestFormViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leaveRequestFormViewModel.Duration is not null &&
                _leaveRequestFormViewModel.LeaveReason is not null &&
                (_leaveRequestFormViewModel.Date - DateTime.Now).Days >= 2 &&
                _schedulingService.IsAvaliableForVacation(Doctor.Id, GetTimeSlot());
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var leaveRequest = new LeaveRequest(Doctor.Id, GetTimeSlot(), _leaveRequestFormViewModel.LeaveReason);
                _leaveRequestService.Add(leaveRequest);
                OnExecutionCompleted(true, "Uspešno su zakazani slobodni dani.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom zakazivanja slobodnih dana.");
            }

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_leaveRequestFormViewModel.LeaveReason)) ||
            (e.PropertyName == nameof(_leaveRequestFormViewModel.Duration)) ||
            (e.PropertyName == nameof(_leaveRequestFormViewModel.Date)))
            {
                OnCanExecutedChanged();
            }
        }

        private TimeSlot GetTimeSlot()
        {
            var to = _leaveRequestFormViewModel.Date.AddDays(int.Parse(_leaveRequestFormViewModel.Duration));
            return new TimeSlot(_leaveRequestFormViewModel.Date, to);
        }
    }
}
