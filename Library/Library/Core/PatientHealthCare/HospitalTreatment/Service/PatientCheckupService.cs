using System.Collections.Generic;
using Library.Model.Checkup;
using Library.Model.Enum;
using Library.Repository.Interface;
using Library.Service.HospitalTreatmentService.Interface;

namespace Library.Service.HospitalTreatmentService;

public class PatientCheckupService : IPatientCheckupService
{
    private readonly IPatientCheckupRepository _repo;

    public PatientCheckupService(IPatientCheckupRepository repo)
    {
        _repo = repo;
    }

    public void Add(PatientCheckup patientCheckup)
    {
        _repo.Add(patientCheckup);
    }

    public void Remove(int id)
    {
        _repo.Remove(id);
    }

    public PatientCheckup Get(int id)
    {
        return _repo.Get(id);
    }

    public Dictionary<int, PatientCheckup> GetAll()
    {
        return _repo.GetAll();
    }

    public bool HasBeenDone(int placementId, TimeOfCheckup timeOfCheckup)
    {
        return _repo.HasBeenDone(placementId, timeOfCheckup);
    }
}