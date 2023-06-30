using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IAnamnesisRepository
    {
        void Add(Anamnesis anamnesis);
        Anamnesis Get(int id);
        Dictionary<int, Anamnesis> GetAll();
        Dictionary<int, Anamnesis> GetAll(int patientId);
        Anamnesis? GetByAppointment(int appointmentId);
        void Remove(int id);
    }
}