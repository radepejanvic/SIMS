using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository;
using Library.Repository.Interface;
using Library.Service.AppointmentService.Interface;

namespace Library.Service.AppointmentService
{
    public class AnamnesisService : IAnamnesisService
    {
        private IAnamnesisRepository _repo;

        public AnamnesisService(IAnamnesisRepository repo)
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
            return _repo.GetByAppointment(appointmentId);
        }

        public Dictionary<int, Anamnesis> GetAll(int patientId)
        {
            return _repo.GetAll(patientId);
        }
    }
}
