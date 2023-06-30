using System.Collections.Generic;
using Library.Model.Checkup;
using Library.Model.Enum;

namespace Library.Service.HospitalTreatmentService.Interface;

public interface IPatientCheckupService
{
    void Add(PatientCheckup patientCheckup);
    PatientCheckup Get(int id);
    Dictionary<int, PatientCheckup> GetAll();
    bool HasBeenDone(int placementId, TimeOfCheckup timeOfCheckup);
    void Remove(int id);
}