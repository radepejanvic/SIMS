using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Model.Refferal;

namespace Library.ViewModel.Structure
{
    public class LeaveRequestViewModel:ViewModelBase
    {
        public readonly LeaveRequest _leaveRequest;

        public int Id => _leaveRequest.Id;
        public int DoctorId => _leaveRequest.DoctorId;
        public TimeSlot TimeSlot => _leaveRequest.TimeSlot;
        public string LeaveReason => _leaveRequest.LeaveReason;
        public string Status => _leaveRequest.Status;

        public LeaveRequestViewModel(LeaveRequest leaveRequest)
        {
            _leaveRequest = leaveRequest;
        }
    }
}
