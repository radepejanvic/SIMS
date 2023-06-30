using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class RoomRenovationRepository : IRoomRenovationRepository
    {
        private ICRUDRepository<RoomRenovation> _repo;

        public RoomRenovationRepository(ICRUDRepository<RoomRenovation> repo)
        {
            _repo = repo;
        }
        public void Add(RoomRenovation roomRenovation)
        {
            _repo.Add(roomRenovation);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }
        public void Update(RoomRenovation roomRenovation)
        {
            _repo.Update(roomRenovation);
        }

        public RoomRenovation Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<RoomRenovation> GetAll()
        {
            return _repo.GetAll().Values.ToList();
        }
        public List<RoomRenovation> GetUnfinishedRoomRenovation()
        {
            return _repo.GetAll().Values.Where(r => !r.IsRequestCompleted() && r.IsTimeLessThanNow()).ToList();
        }

        public bool CheckAvailability(int id)
        {
            var roomRon = GetAll().Where(o => !o.IsRequestCompleted() && o.RoomID == id).ToList();
            if (roomRon.Any())
                return false;
            return true;
        }

    }
}
