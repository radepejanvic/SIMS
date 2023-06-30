using System;
using System.Collections.Generic;
using Library.Model.Refferal;

namespace Library.Service.HospitalTreatmentService.Interface;

public interface IPatientPlacementService
{
    void Add(PatientPlacement patientPlacement);
    PatientPlacement Get(int id);
    Dictionary<int, PatientPlacement> GetAll();
    Dictionary<int, PatientPlacement> GetAll(DateOnly treatmentDate);
    int GetNumberOfPatients(int roomId);
    void Remove(int id);
    void Update(PatientPlacement patientPlacement);
}