using System;
using Library.Serializer;

namespace Library.Model.Refferal;

public class PatientPlacement : ISerializable
{
    public DateOnly EndDate;

    public int PatientId;
    public int RoomId;

    public PatientPlacement()
    {
    }

    public PatientPlacement(int patientId, int roomId, DateOnly endDate)
    {
        PatientId = patientId;
        RoomId = roomId;
        EndDate = endDate;
    }

    public int Id { get; set; }
}