using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class AppointmentNotification: Notification
    {
        public int DoctorID;
        public TimeSlot Initial;
        public TimeSlot Delayed;
        public AppointmentNotification()
        {

        }
        public AppointmentNotification(int doctorID, int patientID, TimeSlot initial, TimeSlot delayed) : base(patientID)
        {
            DoctorID = doctorID;
            Initial = initial;
            Delayed = delayed;
        }
    }
}
