using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public abstract class Notification : ISerializable
    {
        public int Id { get; set; }
        public int PatientId;

        public Notification() { }
        public Notification(int patientId)
        {
            PatientId = patientId;
        }
    }
}
