using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class RoomFusingRenovationRepository : IRoomFusingRenovationRepository
    {
        private ICRUDRepository<RoomFusingRenovation> _repo;

        public RoomFusingRenovationRepository(ICRUDRepository<RoomFusingRenovation> repo)
        {
            _repo = repo;
        }
        public void Add(RoomFusingRenovation roomFusingRenovation)
        {
            _repo.Add(roomFusingRenovation);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public RoomFusingRenovation Get(int id)
        {
            return _repo.Get(id);
        }
        public void Update(RoomFusingRenovation roomFusingRenovation)
        {
            _repo.Update(roomFusingRenovation);
        }

        public IEnumerable<RoomFusingRenovation> GetAll()
        {
            return _repo.GetAll().Values.ToList();
        }
        public List<RoomFusingRenovation> GetUnfinishedRoomFusingRenovation()
        {
            return _repo.GetAll().Values.Where(r => !r.IsRequestCompleted() && r.IsTimeLessThanNow()).ToList();
        }

        public bool CheckAvailability(int id)
        {
            var roomRon = GetAll().Where(o => !o.IsRequestCompleted() && o.RoomID == id || o.SecondRoomID == id).ToList();
            if (roomRon.Any())
                return false;
            return true;
        }
    }
}
