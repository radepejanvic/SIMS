using System;
using System.Collections.Generic;
using System.Linq;
using Library.Model.Refferal;
using Library.Repository.Interface;

namespace Library.Repository;

public class PatientPlacementRepository : IPatientPlacementRepository
{
    private readonly ICRUDRepository<PatientPlacement> _crud;

    public PatientPlacementRepository(ICRUDRepository<PatientPlacement> crud)
    {
        _crud = crud;
    }

    public void Add(PatientPlacement patientPlacement)
    {
        _crud.Add(patientPlacement);
    }

    public void Update(PatientPlacement patientPlacement)
    {
        _crud.Update(patientPlacement);
    }

    public void Remove(int id)
    {
        _crud.Remove(id);
    }

    public PatientPlacement Get(int id)
    {
        return _crud.Get(id);
    }

    public Dictionary<int, PatientPlacement> GetAll()
    {
        return _crud.GetAll();
    }

    public Dictionary<int, PatientPlacement> GetAll(DateOnly treatmentDate)
    {
        return _crud.GetAll().Values
            .Where(patientPlacement => patientPlacement.EndDate >= treatmentDate)
            .ToDictionary(patientPlacement => patientPlacement.Id, patientPlacement => patientPlacement);
    }

    public int GetNumberOfPatients(int roomId)
    {
        return _crud.GetAll().Values
            .Where(patientPlacement => patientPlacement.RoomId == roomId &&
                                       patientPlacement.EndDate >= DateOnly.FromDateTime(DateTime.Today))
            .Count();
    }
}