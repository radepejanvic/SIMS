using System.Collections.Generic;
using Library.Model;

namespace Library.Service.AppointmentService.Interface
{
    public interface IAnamnesisService
    {
        void Add(Anamnesis anamnesis);
        Anamnesis Get(int id);
        Dictionary<int, Anamnesis> GetAll();
        Dictionary<int, Anamnesis> GetAll(int patientId);
        Anamnesis? GetByAppointment(int appointmentId);
        void Remove(int id);
    }
}