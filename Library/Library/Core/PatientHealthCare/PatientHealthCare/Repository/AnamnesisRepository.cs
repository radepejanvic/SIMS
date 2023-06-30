using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class AnamnesisRepository : IAnamnesisRepository
    {
        private ICRUDRepository<Anamnesis> _repo;

        public AnamnesisRepository(ICRUDRepository<Anamnesis> repo)
        {
            _repo = repo;
        }

        public void Add(Anamnesis anamnesis)
        {
            _repo.Add(anamnesis);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Anamnesis Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Anamnesis> GetAll()
        {
            return _repo.GetAll();
        }

        public Anamnesis? GetByAppointment(int appointmentId)
        {
            return _repo.GetAll().Values
                .FirstOrDefault(anamnesis => anamnesis.AppointmentId == appointmentId);
        }

        public Dictionary<int, Anamnesis> GetAll(int patientId)
        {
            return _repo.GetAll().Values
                .Where(anamnesis => anamnesis.PatientId == patientId)
                .ToDictionary(anamnesis => anamnesis.Id, anamnesis => anamnesis);
        }
    }
}
