using Library.Model;

namespace Library.Service.FarmaceuticalService.Interface
{
    public interface IDrugPerscribingService
    {
        int CalculateDaysUntilRefill(int drugId, Instruction instruction);
        void ExtendPerscription(int perscriptionId);
        bool IsExtendable(int perscriptionId);
        void PerscribeDrug(int drugId);
        void PerscribeTherapy(int appointmentId, int patientId, int drugId, Instruction instruction);
        bool IsPatientAlergic(int drugId, int patientId);
    }
}