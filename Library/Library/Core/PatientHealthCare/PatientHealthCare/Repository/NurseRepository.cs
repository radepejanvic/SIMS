using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class NurseRepository : INurseRepository
    {
        private ICRUDRepository<Nurse> _repo;

        public NurseRepository(ICRUDRepository<Nurse> repo)
        {
            _repo = repo;
        }

        public void Add(Nurse nurse)
        {
            _repo.Add(nurse);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Update(Nurse nurse)
        {
            _repo.Update(nurse);
        }

        public Nurse Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, Nurse> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, Nurse> GetAll(List<int> ids)
        {
            return _repo.GetAll().Values
                .Where(patient => ids.Contains(patient.Id))
                .ToDictionary(patient => patient.Id, patient => patient);
        }
    }
}
