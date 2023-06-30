using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRenovationService
    {
        void Add(RoomRenovation roomRenovation);
        void Add(RoomDefusingRenovation roomDefusingRenovation);
        void Add(RoomFusingRenovation roomFusingRenovation);
        bool CheckAvailability(int id);
        void ProcessRoomDefusingRenovation(IRoomService roomService);
        void ProcessRoomFusingRenovation(IRoomService roomService);
        void ProcessRoomRenovation(IRoomService roomService);
        void UpdateCompletedRoomRenovation(List<RoomRenovation> roomRenovations, List<RoomFusingRenovation> roomFusingRenovations, List<RoomDefusingRenovation> roomDefusingRenovations);
    }
}