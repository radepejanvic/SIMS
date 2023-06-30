using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class Perscription : ISerializable
    {
        public int Id { get; set; }
        public int AppointmentId;
        public int PatientId;
        public int DrugId;
        public Instruction Instruction;
        public DateOnly DispensingDate;
        public int DaysUntilRefill;
        public int Refills;

        public Perscription()
        {
            
        }

        public Perscription(int appointmentId, int patientId, int drugId, Instruction instruction, int daysUntilRefll)
        {
            DrugId = drugId;
            PatientId = patientId;
            AppointmentId = appointmentId;
            Instruction = instruction;
            DispensingDate = DateOnly.FromDateTime(DateTime.Now);
            DaysUntilRefill = daysUntilRefll;
            Refills = 0;
        }

        public DateOnly GetDueDate()
        {
            return DispensingDate.AddDays(DaysUntilRefill);
        }

        public void Extend()
        {
            DispensingDate = DateOnly.FromDateTime(DateTime.Now);
            Refills++;
        }
    }
}
