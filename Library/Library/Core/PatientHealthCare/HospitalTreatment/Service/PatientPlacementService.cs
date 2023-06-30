using System;
using System.Collections.Generic;
using Library.Model.Refferal;
using Library.Repository.Interface;
using Library.Service.HospitalTreatmentService.Interface;

namespace Library.Service.HospitalTreatmentService;

public class PatientPlacementService : IPatientPlacementService
{
    private readonly IPatientPlacementRepository _repo;

    public PatientPlacementService(IPatientPlacementRepository repo)
    {
        _repo = repo;
    }

    public void Add(PatientPlacement patientPlacement)
    {
        _repo.Add(patientPlacement);
    }

    public void Update(PatientPlacement patientPlacement)
    {
        _repo.Update(patientPlacement);
    }

    public void Remove(int id)
    {
        _repo.Remove(id);
    }

    public PatientPlacement Get(int id)
    {
        return _repo.Get(id);
    }

    public Dictionary<int, PatientPlacement> GetAll()
    {
        return _repo.GetAll();
    }

    public Dictionary<int, PatientPlacement> GetAll(DateOnly treatmentDate)
    {
        return _repo.GetAll(treatmentDate);
    }

    public int GetNumberOfPatients(int roomId)
    {
        return _repo.GetNumberOfPatients(roomId);
    }
}