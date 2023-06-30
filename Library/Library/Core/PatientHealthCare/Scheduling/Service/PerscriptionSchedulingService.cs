using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.Service.ScheduleService
{
    public class PerscriptionSchedulingService : IPerscriptionSchedulingService
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IPerscriptionService _perscriptionService;
        private readonly IAppointmentService _appointmentSrevice;
        public PerscriptionSchedulingService(ISchedulingService schedulingService, IDrugPerscribingService drugPerscribingService, IPerscriptionService perscriptionService, IAppointmentService appointmentService)
        {
            _schedulingService = schedulingService;
            _perscriptionService = perscriptionService;
            _appointmentSrevice = appointmentService;
        }


        // TODO: Move room id inside this function, delete from arguments when you make GetFirstFreeRoom function in SchedulingService.
        public void ScheduleWithPerscription(int perscriptionId, int roomId, TimeSlot timeSlot)
        {
            var perscription = _perscriptionService.Get(perscriptionId);
            var lastAppointment = _appointmentSrevice.Get(perscription.AppointmentId);
            _schedulingService.Schedule(new Appointment(lastAppointment.DoctorId, lastAppointment.PatientId, roomId, timeSlot, lastAppointment.IsOperation));
        }
    }
}
