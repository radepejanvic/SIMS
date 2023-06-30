using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private ICRUDRepository<Perscription> _repo;

        public PrescriptionRepository(ICRUDRepository<Perscription> repo)
        {
            _repo = repo;
        }

        public void Add(Perscription drug)
        {
            _repo.Add(drug);
        }

        public void Update(Perscription drug)
        {
            _repo.Update(drug);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public Perscription Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Perscription> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Perscription> GetAll(int patientId)
        {
            return _repo.GetAll().Values
                .Where(perscription => perscription.PatientId == patientId)
                .ToDictionary(perscription => perscription.Id, perscription => perscription) ?? new Dictionary<int, Perscription>();
        }
    }
}
