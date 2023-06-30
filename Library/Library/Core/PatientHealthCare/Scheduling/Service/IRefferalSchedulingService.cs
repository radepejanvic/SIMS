using Library.Model;
using Library.Model.Refferal;

namespace Library.Service.ScheduleService.Interface
{
    public interface IRefferalSchedulingService
    {
        void ScheduleWithDoctorRefferal(int doctorRefferalId, int roomId, TimeSlot timeSlot);
        void ScheduleWithHospitalRefferal(HospitalRefferal hospitalRefferal);
        void ScheduleWithSpecializationRefferal(int doctorRefferalId, int roomId, TimeSlot timeSlot);
    }
}