using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRoomFusingRenovationService
    {
        void Add(RoomFusingRenovation roomFusingRenovation);
        bool CheckAvailability(int id);
        RoomFusingRenovation Get(int id);
        IEnumerable<RoomFusingRenovation> GetAll();
        List<RoomFusingRenovation> GetUnfinishedRoomFusingRenovation();
        void Remove(int id);
        void UpdateCompletedRoomFusingRenovation(List<RoomFusingRenovation> roomFusingRenovations);
    }
}