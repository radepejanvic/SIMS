using System.Collections.Generic;
using Library.Model;

namespace Library.Repository.Interface
{
    public interface IRoomRenovationRepository
    {
        void Add(RoomRenovation roomRenovation);
        bool CheckAvailability(int id);
        RoomRenovation Get(int id);
        IEnumerable<RoomRenovation> GetAll();
        List<RoomRenovation> GetUnfinishedRoomRenovation();
        void Remove(int id);
        void Update(RoomRenovation roomRenovation);
    }
}