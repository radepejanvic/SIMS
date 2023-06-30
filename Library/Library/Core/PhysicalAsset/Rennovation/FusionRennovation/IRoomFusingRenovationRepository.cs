using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IRoomFusingRenovationRepository
    {
        void Add(RoomFusingRenovation roomFusingRenovation);
        bool CheckAvailability(int id);
        RoomFusingRenovation Get(int id);
        IEnumerable<RoomFusingRenovation> GetAll();
        List<RoomFusingRenovation> GetUnfinishedRoomFusingRenovation();
        void Remove(int id);
        void Update(RoomFusingRenovation roomFusingRenovation);
    }
}