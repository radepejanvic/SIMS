using System;
using Library.Model.Enum;
using Library.Serializer;

namespace Library.Model.Checkup;

public class PatientCheckup : ISerializable
{
    public DateOnly DateOfCheckup;
    public int DiastolicPressure;
    public string Observations;

    public int PatientId;
    public int PatientPlacementId;
    public int SystolicPressure;
    public float Temperature;
    public TimeOfCheckup TimeOfCheckup;

    public PatientCheckup()
    {
    }

    public PatientCheckup(int patientId, int patientPlacementId, TimeOfCheckup timeOfCheckup, int systolicPressure,
        int diastolicPressure, float temperature, string observations)
    {
        PatientId = patientId;
        PatientPlacementId = patientPlacementId;
        TimeOfCheckup = timeOfCheckup;
        SystolicPressure = systolicPressure;
        DiastolicPressure = diastolicPressure;
        Temperature = temperature;
        Observations = observations;
        DateOfCheckup = DateOnly.FromDateTime(DateTime.Today);
    }

    public int Id { get; set; }
}