using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository.Interface;

namespace Library.Repository
{
    public class RoomDefusingRenovationRepository : IRoomDefusingRenovationRepository
    {
        private ICRUDRepository<RoomDefusingRenovation> _repo;

        public RoomDefusingRenovationRepository(ICRUDRepository<RoomDefusingRenovation> repo)
        {
            _repo = repo;
        }
        public void Add(RoomDefusingRenovation roomDefusingRenovation)
        {
            _repo.Add(roomDefusingRenovation);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }
        public void Update(RoomDefusingRenovation roomDefusingRenovation)
        {
            _repo.Update(roomDefusingRenovation);
        }

        public RoomDefusingRenovation Get(int id)
        {
            return _repo.Get(id);
        }

        public IEnumerable<RoomDefusingRenovation> GetAll()
        {
            return _repo.GetAll().Values.ToList();
        }
        public List<RoomDefusingRenovation> GetUnfinishedRoomDefusingRenovation()
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
