using Library.Model.Refferal;

namespace Library.Model.Checkup;

public class PatientAndRoom
{
    public string FirstName;
    public string LastName;
    public int PatientId;
    public int PatientPlacementId;
    public int RoomId;

    public PatientAndRoom(Patient patient, PatientPlacement patientPlacement)
    {
        PatientPlacementId = patientPlacement.Id;
        PatientId = patient.Id;
        FirstName = patient.FirstName;
        LastName = patient.LastName;
        RoomId = patientPlacement.RoomId;
    }
}