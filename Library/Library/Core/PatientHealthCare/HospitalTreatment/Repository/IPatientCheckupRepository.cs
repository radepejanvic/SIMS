using System.Collections.Generic;
using Library.Model.Checkup;
using Library.Model.Enum;

namespace Library.Repository.Interface;

public interface IPatientCheckupRepository
{
    void Add(PatientCheckup anamnesis);
    PatientCheckup Get(int id);
    Dictionary<int, PatientCheckup> GetAll();
    bool HasBeenDone(int placementId, TimeOfCheckup timeOfCheckup);
    void Remove(int id);
}