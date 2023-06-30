namespace Library.Model.Refferal;

public class HospitalRefferal : Refferal
{
    public bool AdditionalAnalysis;

    // NOTE: Quesitonable ?
    public int AppointmentId;
    public int Duration;

    public HospitalRefferal()
    {
    }

    public HospitalRefferal(int patientId, int duration, int appointmentId, bool additionalAnalysis) : base(patientId)
    {
        Duration = duration;
        AppointmentId = appointmentId;
        AdditionalAnalysis = additionalAnalysis;
    }
}