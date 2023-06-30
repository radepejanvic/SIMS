using System;
using System.Collections.Generic;
using Library.Model;
using Library.Model.Checkup;

namespace Library.Service.HospitalTreatmentService.Interface;

public interface IHospitalTreatmentService
{
    Dictionary<int, PatientAndRoom> GetAllPatientsOnHospitalTreatment();
    Dictionary<int, Room> GetAllUnderoccupiedRooms();
    bool IsFull(int roomId);
    bool IsPlaced(int patientId);
    void StartHospitaltreatment(int hospitalRefferalId, int roomId);
}