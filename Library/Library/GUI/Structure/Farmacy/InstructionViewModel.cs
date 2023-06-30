using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel.Structure.Farmacy
{
    public class InstructionViewModel : ViewModelBase
    {
        private readonly Instruction _instruction;

        public int TimesPerDay => _instruction.TimesPerDay;
        public int AmountPerDay => _instruction.AmountPerDose;
        public string AdditionalComments => _instruction.AdditionalComments;
        public MedicationIntakeTime IntakeTime => IntakeTime;

        public InstructionViewModel(Instruction instruction)
        {
            _instruction = instruction;
        }   
    }
}
