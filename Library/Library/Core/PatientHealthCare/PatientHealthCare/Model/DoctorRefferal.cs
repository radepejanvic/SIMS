using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model.Refferal
{
    public class DoctorRefferal : Refferal
    {
        public int DoctorId;
        public bool IsOperation;
        public int Duration;
        public Specialization? Specialization;

        public DoctorRefferal()
        {

        }

        public DoctorRefferal(int doctorId, int patientId, bool isOperation, int duration) : base(patientId)
        {
            DoctorId = doctorId;
            IsOperation = isOperation;
            Duration = duration;
        }

        public DoctorRefferal(Specialization specialization, int patientId, bool isOperation, int duration) : base(patientId)
        {
            Specialization = specialization;
            IsOperation = isOperation;
            Duration = duration;
        }


    }
}
