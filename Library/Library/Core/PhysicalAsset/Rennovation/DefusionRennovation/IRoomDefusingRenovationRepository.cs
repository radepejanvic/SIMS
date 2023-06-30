using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IRoomDefusingRenovationRepository
    {
        void Add(RoomDefusingRenovation roomDefusingRenovation);
        bool CheckAvailability(int id);
        RoomDefusingRenovation Get(int id);
        IEnumerable<RoomDefusingRenovation> GetAll();
        List<RoomDefusingRenovation> GetUnfinishedRoomDefusingRenovation();
        void Remove(int id);
        void Update(RoomDefusingRenovation roomDefusingRenovation);
    }
}