using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;

namespace Library.Model
{
    public class Instruction
    {
        public int TimesPerDay;
        public int AmountPerDose;
        public string AdditionalComments;
        public MedicationIntakeTime IntakeTime;

        public Instruction(int timesPerDay, int amountPerDose, string additionalComments, MedicationIntakeTime intakeTime)
        {
            TimesPerDay = timesPerDay;
            AmountPerDose = amountPerDose;
            AdditionalComments = additionalComments;
            IntakeTime = intakeTime;
        }
    }
}
