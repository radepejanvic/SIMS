using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class LeaveRequest : ISerializable
    {
        public int Id { get; set; }
        public int DoctorId;
        public TimeSlot TimeSlot;
        public string LeaveReason;
        public string Status { get; set; }

        public LeaveRequest()
        {

        }

        public LeaveRequest(int doctorId, TimeSlot timeSlot, string leaveReason)
        {
            DoctorId = doctorId;
            TimeSlot = timeSlot;
            LeaveReason = leaveReason;
            Status = "NA CEKANJU";
        }

    }
}
