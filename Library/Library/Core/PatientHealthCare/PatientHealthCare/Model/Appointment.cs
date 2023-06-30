using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model.Refferal;
using Library.Serializer;

namespace Library.Model
{
    public class Appointment: ISerializable
    {
        public int Id { get; set; }
        public int DoctorId;
        public int PatientId;
        public int RoomId;
        public TimeSlot TimeSlot;
        public bool IsOperation;
        public int ChangeCount;
        public bool IsCanceled;
        public DateTime CreatedAt;

        public Appointment()
        {
        }

        public Appointment(int doctorId, int patientId, int roomId, TimeSlot timeSlot, bool isOperation)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            RoomId = roomId;
            TimeSlot = timeSlot;
            IsOperation = isOperation;
            IsCanceled = false;
            ChangeCount = 0;
            CreatedAt = DateTime.Now;
        }

        public Appointment(DoctorRefferal doctorRefferal, int roomId, TimeSlot timeSlot)
        {
            DoctorId = doctorRefferal.DoctorId;
            PatientId = doctorRefferal.PatientId;
            RoomId = roomId;
            TimeSlot = timeSlot;
            IsOperation = doctorRefferal.IsOperation;
            IsCanceled = false;
            ChangeCount = 0;
            CreatedAt = DateTime.Now;
        }

        public Appointment(int doctorId, DoctorRefferal doctorRefferal, int roomId, TimeSlot timeSlot)
        {
            DoctorId = doctorId;
            PatientId = doctorRefferal.PatientId;
            RoomId = roomId;
            TimeSlot = timeSlot;
            IsOperation = doctorRefferal.IsOperation;
            IsCanceled = false;
            ChangeCount = 0;
            CreatedAt = DateTime.Now;
        }
    }
}
