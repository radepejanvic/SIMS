using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class RoomScheduleRepository : IRoomScheduleRepository
    {
        private ICRUDRepository<RoomSchedule> _repo;

        public RoomScheduleRepository(ICRUDRepository<RoomSchedule> repo)
        {
            _repo = repo;
        }
        public void Add(RoomSchedule roomSchedule)
        {
            _repo.Add(roomSchedule);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Update(RoomSchedule roomSchedule)
        {
            _repo.Update(roomSchedule);
        }
        public RoomSchedule Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<RoomSchedule> GetAll()
        {
            return _repo.GetAll().Values.ToList();
        }
        public bool CheckAvailability(DateTime begin, DateTime end, int id)
        {
            var appointments = Get(id).Appointments.Where(o => o.Key >= DateOnly.FromDateTime(begin) && o.Key <= DateOnly.FromDateTime(end)).ToList();
            foreach (var tu in appointments)
            {
                if (tu.Value.Count != 0)
                    return false;
            }
            return true;
        }
    }
}
