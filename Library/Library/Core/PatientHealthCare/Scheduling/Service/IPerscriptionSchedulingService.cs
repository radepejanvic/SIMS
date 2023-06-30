using Library.Model;

namespace Library.Service.ScheduleService.Interface
{
    public interface IPerscriptionSchedulingService
    {
        void ScheduleWithPerscription(int perscriptionId, int roomId, TimeSlot timeSlot);
    }
}