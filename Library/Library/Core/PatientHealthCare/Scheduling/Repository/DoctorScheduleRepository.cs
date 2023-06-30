using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private ICRUDRepository<DoctorSchedule> _repo;

        public DoctorScheduleRepository(ICRUDRepository<DoctorSchedule> repo)
        {
            _repo = repo;
        }

        public void Add(DoctorSchedule doctorSchedule)
        {
            _repo.Add(doctorSchedule);
        }

        public void Update(DoctorSchedule doctorSchedule)
        {
            _repo.Update(doctorSchedule);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public DoctorSchedule Get(int id)
        {
            return _repo.Get(id);
        }

        public Dictionary<int, DoctorSchedule> GetAll()
        {
            return _repo.GetAll();
        }

        public Dictionary<int, DoctorSchedule> GetAll(Dictionary<int, Doctor> doctors)
        {
            return _repo.GetAll().Values
                .Where(doctorSchedule => doctors.ContainsKey(doctorSchedule.Id))
                .ToDictionary(doctorSchedule => doctorSchedule.Id, doctorSchedule => doctorSchedule);
        }
    }
}
