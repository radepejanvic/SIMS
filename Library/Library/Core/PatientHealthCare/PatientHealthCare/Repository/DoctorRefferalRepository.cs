using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Refferal;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DoctorRefferalRepository : IDoctorRefferalRepository
    {
        private ICRUDRepository<DoctorRefferal> _repo;

        public DoctorRefferalRepository(ICRUDRepository<DoctorRefferal> repo)
        {
            _repo = repo;
        }

        public void Add(DoctorRefferal doctorRefferal)
        {
            _repo.Add(doctorRefferal);
        }

        public void Update(DoctorRefferal doctorRefferal)
        {
            _repo.Update(doctorRefferal);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public DoctorRefferal Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, DoctorRefferal> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, DoctorRefferal> GetAll(int patientId)
        {
            return _repo.GetAll().Values
                .Where(doctorRefferal => doctorRefferal.PatientId == patientId && doctorRefferal.IsValid is true)
                .ToDictionary(doctorRefferal => doctorRefferal.Id, doctorRefferal => doctorRefferal);
        }
    }
}
