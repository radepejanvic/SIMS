using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Model;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.LeaveRequestService;
using Library.Service.LeaveRequestService.Interface;
using Library.Service.PersonService;
using Library.Service.RefferalService;
using Library.Service.ScheduleService;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Structure;

namespace Library.ViewModel.Form
{
    public class LeaveRequestFormViewModel : ViewModelBase
    {
        public Doctor Doctor;
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string _duration;
        public string Duration
        {
            get
            {
                return _duration;

            }
            set
            {
                if (Regex.IsMatch(value, "^[0-9]+$"))
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        private string _leaveReason;
        public string LeaveReason
        {
            get
            {
                return _leaveReason;
            }
            set
            {
                _leaveReason = value;
                OnPropertyChanged(nameof(LeaveReason));
            }
        }

        public CommandBase SubmitLeaveRequest { get; }
        public LeaveRequestFormViewModel(Doctor doctor, ISchedulingService schedulingService, ILeaveRequestService leaveRequestService)
        {
            Doctor = doctor;

            Date = DateTime.Now;
            Duration = "0";
            SubmitLeaveRequest = new SubmitLeaveRequestCommand(this, Doctor, schedulingService, leaveRequestService);
            SubmitLeaveRequest.ExcecutionCompleted += ExecutionCompleted;
        }

    }
}
