using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class CustomNotificationConfiguration : ISerializable
    {
        public int Id { get; set; }
        private int _patientId;
        private int _duration;
        public int PatientId
        {
            get => _patientId; set => _patientId = value;
        }
        public int Duration
        {
            get => _duration; set => _duration = value;
        }

        public CustomNotificationConfiguration() { }
        public CustomNotificationConfiguration(int patientId, int duration)
        {
            _patientId = patientId;
            _duration = duration;
        }
    }
}
