using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.FarmaceuticalService.Interface;

namespace Library.ViewModel.Structure.Farmacy
{
    public class PerscriptionViewModel : ViewModelBase
    {
        private readonly string _drugName;

        private readonly Perscription _perscription;
        public int Id => _perscription.Id;
        public int AppointmentId => _perscription.AppointmentId;
        public int DrugId => _perscription.DrugId;
        public string DrugName => _drugName;
        public InstructionViewModel Instruction => new(_perscription.Instruction);
        public DateOnly DispensingDate => _perscription.DispensingDate;
        public int NumberOfRefills => _perscription.Refills;
        public DateOnly RefillDate => _perscription.GetDueDate();

        public PerscriptionViewModel(Perscription perscription, IDrugService drugService)
        {
            _perscription = perscription;
            _drugName = drugService.Get(_perscription.DrugId).Name;
        }
    }
}
