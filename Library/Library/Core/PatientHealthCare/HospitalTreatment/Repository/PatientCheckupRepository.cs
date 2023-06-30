using System;
using System.Collections.Generic;
using System.Linq;
using Library.Model.Checkup;
using Library.Model.Enum;
using Library.Repository.Interface;

namespace Library.Repository;

public class PatientCheckupRepository : IPatientCheckupRepository
{
    private readonly ICRUDRepository<PatientCheckup> _crud;

    public PatientCheckupRepository(ICRUDRepository<PatientCheckup> crud)
    {
        _crud = crud;
    }

    public void Add(PatientCheckup checkup)
    {
        _crud.Add(checkup);
    }

    public void Remove(int id)
    {
        _crud.Remove(id);
    }

    public PatientCheckup Get(int id)
    {
        return _crud.Get(id);
    }

    public Dictionary<int, PatientCheckup> GetAll()
    {
        return _crud.GetAll();
    }

    public bool HasBeenDone(int placementId, TimeOfCheckup timeOfCheckup)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        return _crud.GetAll().Values
            .Where(checkup => checkup.PatientPlacementId == placementId &&
                              checkup.DateOfCheckup == today &&
                              checkup.TimeOfCheckup == timeOfCheckup)
            .Count() != 0;
    }

    public Dictionary<int, PatientCheckup> GetAll(int patientPlacementId)
    {
        return _crud.GetAll().Values
            .Where(checkup => checkup.PatientPlacementId == patientPlacementId)
            .ToDictionary(checkup => checkup.Id, checkup => checkup);
    }
}