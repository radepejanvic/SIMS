using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Model.Refferal;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.Service.ScheduleService
{
    public class RefferalSchedulingService : IRefferalSchedulingService
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IDoctorRefferalService _doctorRefferalService;
        private readonly IHospitalRefferalService _hospitalRefferalService;
        public RefferalSchedulingService(ISchedulingService schedulingService, IDoctorRefferalService doctorRefferalService, IHospitalRefferalService hospitalRefferalService)
        {
            _schedulingService = schedulingService;
            _doctorRefferalService = doctorRefferalService;
            _hospitalRefferalService = hospitalRefferalService;
        }

        // TODO: Instead of sending roomId as an argument, use the function GetFirstAvaliableRoom() from SchedulingService.
        public void ScheduleWithDoctorRefferal(int doctorRefferalId, int roomId, TimeSlot timeSlot)
        {
            var doctorRefferal = _doctorRefferalService.Get(doctorRefferalId);
            _schedulingService.Schedule(new Appointment(doctorRefferal, roomId, timeSlot));
            doctorRefferal.IsValid = false;
            _doctorRefferalService.Update(doctorRefferal);
        }

        public void ScheduleWithSpecializationRefferal(int doctorRefferalId, int roomId, TimeSlot timeSlot)
        {
            var doctorRefferal = _doctorRefferalService.Get(doctorRefferalId);
            var doctorId = _schedulingService.GetFirstAvaliableDoctor((Specialization)doctorRefferal.Specialization, timeSlot);
            _schedulingService.Schedule(new Appointment(doctorId, doctorRefferal, roomId, timeSlot));
            doctorRefferal.IsValid = false;
            _doctorRefferalService.Update(doctorRefferal);
        }

        public void ScheduleWithHospitalRefferal(HospitalRefferal hospitalRefferal)
        {
            throw new NotImplementedException();
        }
    }
}
