using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.TehnicalService.Interface;

namespace Library.Service.FarmaceuticalService
{
    public class DrugPerscribingService : IDrugPerscribingService
    {
        private readonly IPerscriptionService _perscriptionService;
        private readonly IDrugService _drugService;
        private readonly IPatientService _patientService;
        private readonly ICustomNotificationService _customNotificationService;

        public DrugPerscribingService(IPerscriptionService perscriptionService, IDrugService drugService, IPatientService patientService, ICustomNotificationService customNotificationService)
        {
            _perscriptionService = perscriptionService;
            _drugService = drugService;
            _patientService = patientService;
            _customNotificationService = customNotificationService;
        }

        public void PerscribeTherapy( int appointmentId, int patientId, int drugId, Instruction instruction)
        {
            PerscribeDrug(drugId);
            var perscription = new Perscription(appointmentId, patientId, drugId, instruction, CalculateDaysUntilRefill(drugId, instruction));
            _perscriptionService.Add(perscription);
            _customNotificationService.Add(perscription.PatientId, perscription.DispensingDate, 
                perscription.DispensingDate.AddDays(perscription.DaysUntilRefill), perscription.Instruction.TimesPerDay, 
                "Pij lek " + _drugService.Get(perscription.DrugId));
        }

        public void ExtendPerscription(int perscriptionId)
        {
            var perscription = _perscriptionService.Get(perscriptionId);
            PerscribeDrug(perscription.DrugId);
            perscription.Extend();
            _perscriptionService.Update(perscription);
        }

        // TODO: Think about renaming this function and possibly moving it to DWS.
        public void PerscribeDrug(int drugId)
        {
            var drug = _drugService.Get(drugId);
            drug.Perscribe();
            _drugService.Update(drug);
        }

        public bool IsExtendable(int perscriptionId)
        {
            return _perscriptionService.Get(perscriptionId).GetDueDate().AddDays(-1) <= DateOnly.FromDateTime(DateTime.Now);
        }

        public int CalculateDaysUntilRefill(int drugId, Instruction instruction)
        {
            return _drugService.Get(drugId).NumberOfTablets / (instruction.TimesPerDay * instruction.AmountPerDose);
        }

        public bool IsPatientAlergic(int drugId, int patientId)
        {
            return _drugService.Get(drugId).Alergens.Any
                (alergen => _patientService.Get(patientId).MedicalRecord.Alergies.Contains(alergen));
        }
    }
}
