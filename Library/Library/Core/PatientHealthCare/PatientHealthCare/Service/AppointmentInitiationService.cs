using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Library.Model;
using Library.Service.AppointmentService.Interface;

namespace Library.Service.AppointmentService
{
    public class AppointmentInitiationService: IAppointmentInitiationService
    {
        private IAppointmentService _appointmentService;

        public AppointmentInitiationService(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public List<Appointment> GetAllByTime(int doctorId)
        {
            return _appointmentService.GetAll().Values
                .Where(appointment => appointment.DoctorId == doctorId && 
                        appointment.TimeSlot.GetDate() == DateOnly.FromDateTime(DateTime.Now) && 
                        IsAppointmentWithinThreshold(DateTime.Now, appointment.TimeSlot.From))
                .ToList(); 
        }

        public bool IsAppointmentWithinThreshold(DateTime currentTime, DateTime start)
        {
            var timeSlot = new TimeSlot(currentTime, start);
            return currentTime <= start && timeSlot.GetDuration() <= 15;
        }

    }
}
