using System;
using System.Collections.Generic;
using System.Linq;
using Library.Model;
using Library.Model.Checkup;
using Library.Model.Enum;
using Library.Model.Refferal;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.PhysicalAssetService.Interface;
using Library.Service.RefferalService.Interface;

namespace Library.Service.HospitalTreatmentService;

public class HospitalTreatmentService : IHospitalTreatmentService
{
    private readonly IHospitalRefferalService _hospitalRefferalService;
    private readonly IPatientService _patientService;
    private readonly IPatientPlacementService _placementService;
    private readonly IRoomService _roomService;

    public HospitalTreatmentService(IPatientPlacementService placementService,
        IHospitalRefferalService hospitalRefferalService, IRoomService roomService, IPatientService patientService)
    {
        _placementService = placementService;
        _hospitalRefferalService = hospitalRefferalService;
        _roomService = roomService;
        _patientService = patientService;
    }

    public bool IsFull(int roomId)
    {
        return _placementService.GetNumberOfPatients(roomId) == 3;
    }

    public void StartHospitaltreatment(int hospitalRefferalId, int roomId)
    {
        var hospitalRefferal = _hospitalRefferalService.Get(hospitalRefferalId);
        _placementService.Add(new PatientPlacement(hospitalRefferal.PatientId, roomId,
            CalculateEndDate(hospitalRefferal)));
        hospitalRefferal.UseRefferal();
        _hospitalRefferalService.Update(hospitalRefferal);
    }

    public Dictionary<int, Room> GetAllUnderoccupiedRooms()
    {
        return _roomService.GetAll(RoomType.ROOM_FOR_THE_PATIENT).Values
            .Where(room => !IsFull(room.Id))
            .ToDictionary(room => room.Id, room => room);
    }

    public Dictionary<int, PatientAndRoom> GetAllPatientsOnHospitalTreatment()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _placementService.GetAll(today).Values
            .ToDictionary(placement => placement.PatientId,
                placement => new PatientAndRoom(_patientService.Get(placement.PatientId), placement));
    }

    private DateOnly CalculateEndDate(HospitalRefferal hospitalRefferal)
    {
        return DateOnly.FromDateTime(DateTime.Today.AddDays(hospitalRefferal.Duration));
    }

    public bool IsPlaced(int patientId)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        return _placementService.GetAll(today).Values
            .Where(patientPlacement => patientPlacement.PatientId == patientId)
            .Count() == 1;
    }
}