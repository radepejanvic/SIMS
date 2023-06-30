using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private ICRUDRepository<Patient> _repo;

        public PatientRepository(ICRUDRepository<Patient> repo)
        {
            _repo = repo;
        }

        public void Add(Patient patient)
        {
            _repo.Add(patient);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Update(Patient patient)
        {
            _repo.Update(patient);
        }

        public Patient Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Patient> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Patient> GetAll(List<int> ids)
        {
            return _repo.GetAll().Values
                .Where(patient => ids.Contains(patient.Id))
                .ToDictionary(patient => patient.Id, patient => patient);
        }
    }
}
