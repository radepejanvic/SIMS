using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;
using Library.Service;

namespace Library.Model
{
    public class Anamnesis : ISerializable
    {

        public int Id { get; set; }
        // NOTE: Talk this trough with the team.
        public int PatientId;
        // NOTE: Add AppointmentId to the constructor.
        public int AppointmentId;
        public string Sympthoms;
        public string Observations;
        public string Conclusions;

        public Anamnesis()
        {
            
        }

        public Anamnesis(string symptoms, string observations, string conclusions)
        {
            Sympthoms = symptoms;
            Observations = observations;
            Conclusions = conclusions;
        }

        public Anamnesis(string symptoms, string observations, string conclusions, int patientId, int appointmentId)
        {
            Sympthoms = symptoms;
            Observations = observations;
            Conclusions = conclusions;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }
    }
}
