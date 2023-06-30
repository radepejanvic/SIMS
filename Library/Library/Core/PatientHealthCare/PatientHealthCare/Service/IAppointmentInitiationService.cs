using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Service.AppointmentService.Interface
{
    public interface IAppointmentInitiationService
    {
        public List<Appointment> GetAllByTime(int doctorId);
        public bool IsAppointmentWithinThreshold(DateTime currentTime, DateTime start);
    }
}
