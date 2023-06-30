using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enum;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private ICRUDRepository<Doctor> _repo;

        public DoctorRepository(ICRUDRepository<Doctor> repo)
        {
            _repo = repo;
        }

        public void Add(Doctor doctor)
        {
            _repo.Add(doctor);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Doctor Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Doctor> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Doctor> GetAll(Specialization specialization)
        {
            return _repo.GetAll().Values
                .Where(doctor => doctor.Specialization == specialization)
                .ToDictionary(doctor => doctor.Id, doctor => doctor);
        }
    }
}
