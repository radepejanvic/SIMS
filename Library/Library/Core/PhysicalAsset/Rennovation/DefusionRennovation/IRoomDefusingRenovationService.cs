using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRoomDefusingRenovationService
    {
        void Add(RoomDefusingRenovation roomDefusingRenovation);
        bool CheckAvailability(int id);
        RoomDefusingRenovation Get(int id);
        IEnumerable<RoomDefusingRenovation> GetAll();
        List<RoomDefusingRenovation> GetUnfinishedRoomDefusingRenovation();
        void Remove(int id);
        void UpdateCompletedRoomDefusingRenovation(List<RoomDefusingRenovation> roomDefusingRenovations);
    }
}