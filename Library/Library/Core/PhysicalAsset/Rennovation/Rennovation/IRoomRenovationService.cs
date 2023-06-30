using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.Service.PhysicalAssetService.Interface
{
    public interface IRoomRenovationService
    {
        void Add(RoomRenovation roomRenovation);
        bool CheckAvailability( int id);
        RoomRenovation Get(int id);
        IEnumerable<RoomRenovation> GetAll();
        List<RoomRenovation> GetUnfinishedRoomRenovation();
        void Remove(int id);
        void UpdateCompletedRoomRenovation(List<RoomRenovation> roomRenovations);
    }
}