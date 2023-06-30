using System;
using System.Collections.Generic;
using Library.Model.Refferal;

namespace Library.Repository.Interface;

public interface IPatientPlacementRepository
{
    void Add(PatientPlacement drug);
    PatientPlacement Get(int id);
    Dictionary<int, PatientPlacement> GetAll();
    Dictionary<int, PatientPlacement> GetAll(DateOnly treatmentDate);
    int GetNumberOfPatients(int roomId);
    void Remove(int id);
    void Update(PatientPlacement drug);
}